using System.Security.Cryptography;
using Library.Models;
using Library.Models.Events;

namespace Library.Services;

public class FileEncryptor : IFileEncryptor
{
    private const string EncryptionFolder = @"D:\encr\";
    private const string DecryptionFolder = @"D:\decr\";

    private const string EncryptionExtension = ".enc";
    private const string DecryptionExtension = ".txt";

    private const int BitsInByte = 8;

    public event EventHandler<EncryptionProgressChangedEventArgs>? EncryptionProgressChanged;
    public event EventHandler<EncryptionProgressChangedEventArgs>? DecryptionProgressChanged;

    public async Task<EncryptionReport> EncryptFile(FileInfo file, string encryptionKey, WaitingToken waitingToken)
    {
        var cspp = new CspParameters
        {
            KeyContainerName = encryptionKey
        };

        var rsa = new RSACryptoServiceProvider(cspp)
        {
            PersistKeyInCsp = true,
        };

        using var aes = Aes.Create();

        ICryptoTransform transform = aes.CreateEncryptor();

        byte[] keyEncrypted = rsa.Encrypt(aes.Key, false);

        int lenKey = keyEncrypted.Length;
        int lenIV = aes.IV.Length;

        byte[] byteLenK = BitConverter.GetBytes(lenKey);
        byte[] byteLenIV = BitConverter.GetBytes(lenIV);

        string outFile = Path.Combine(
            EncryptionFolder,
            Path.ChangeExtension(file.Name, EncryptionExtension));

        long outFileByteSize;

        using (var outFs = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
        {
            outFs.Write(byteLenK, 0, 4);
            outFs.Write(byteLenIV, 0, 4);
            outFs.Write(keyEncrypted, 0, lenKey);
            outFs.Write(aes.IV, 0, lenIV);

            using (var outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
            {
                int count = 0;
                long bytesRead = 0;

                int blockSizeBytes = aes.BlockSize / BitsInByte;
                byte[] data = new byte[blockSizeBytes];

                using (var inFs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    long fileLength = inFs.Length;

                    do
                    {
                        if (waitingToken.IsCancellationRequested)
                        {
                            break;
                        }

                        while (waitingToken.IsPausedRequested)
                        {
                            await Task.Delay(1);
                        }

                        count = inFs.Read(data, 0, blockSizeBytes);
                        outStreamEncrypted.Write(data, 0, count);

                        bytesRead += count;


                        EncryptionProgressChanged?.Invoke(this, new EncryptionProgressChangedEventArgs(fileLength, bytesRead));
                    } while (count > 0);
                }

                outFileByteSize = outFs.Length;

                outStreamEncrypted.FlushFinalBlock();
            }
        }

        return new EncryptionReport(outFile, outFileByteSize);
    }

    public async Task<EncryptionReport> DecryptFile(FileInfo file, string encryptionKey, WaitingToken waitingToken)
    {
        var cspp = new CspParameters
        {
            KeyContainerName = encryptionKey
        };

        var rsa = new RSACryptoServiceProvider(cspp)
        {
            PersistKeyInCsp = true,
        };

        using Aes aes = Aes.Create();

        byte[] byteLenK = new byte[4];
        byte[] byteLenIV = new byte[4];

        string outFile = Path.Combine(
            DecryptionFolder,
            Path.ChangeExtension(file.Name, DecryptionExtension));

        long outFileByteSize;

        using (var inFs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
        {
            inFs.Seek(0, SeekOrigin.Begin);
            inFs.Read(byteLenK, 0, 3);

            inFs.Seek(4, SeekOrigin.Begin);
            inFs.Read(byteLenIV, 0, 3);

            int lenK = BitConverter.ToInt32(byteLenK, 0);
            int lenIV = BitConverter.ToInt32(byteLenIV, 0);

            int textStart = lenK + lenIV + 8;
            long lenText = inFs.Length - textStart;

            byte[] keyEncrypted = new byte[lenK];
            byte[] IV = new byte[lenIV];

            inFs.Seek(8, SeekOrigin.Begin);
            inFs.Read(keyEncrypted, 0, lenK);

            inFs.Seek(8 + lenK, SeekOrigin.Begin);
            inFs.Read(IV, 0, lenIV);

            byte[] keyDecrypted = rsa.Decrypt(keyEncrypted, false);

            ICryptoTransform transform = aes.CreateDecryptor(keyDecrypted, IV);

            using (var outFs = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                int count = 0;
                long bytesRead = 0;

                int blockSizeBytes = aes.BlockSize / BitsInByte;
                byte[] data = new byte[blockSizeBytes];

                inFs.Seek(textStart, SeekOrigin.Begin);

                using (var outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {
                    do
                    {
                        if (waitingToken.IsCancellationRequested)
                        {
                            break;
                        }

                        while (waitingToken.IsPausedRequested)
                        {
                            await Task.Delay(1);
                        }

                        count = inFs.Read(data, 0, blockSizeBytes);
                        outStreamDecrypted.Write(data, 0, count);

                        bytesRead += count;

                        DecryptionProgressChanged?.Invoke(this, new EncryptionProgressChangedEventArgs(lenText, bytesRead));

                    } while (count > 0);

                    outFileByteSize = outFs.Length;

                    outStreamDecrypted.FlushFinalBlock();
                }
            }
        }

        return new EncryptionReport(outFile, outFileByteSize);
    }
}
