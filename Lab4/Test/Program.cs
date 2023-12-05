using Library.Services;

const string SrcFile = @"D:\input.txt";
const string EncrFile = @"D:\encr\input.enc";

string key = "your_secret_key";

IFileEncryptor fileEncryptor = new FileEncryptor();

fileEncryptor.EncryptionProgressChanged += (_, args) => Console.WriteLine($"{args.ProcessedBytes}/{args.TotalBytes}");
fileEncryptor.DecryptionProgressChanged += (_, args) => Console.WriteLine($"{args.ProcessedBytes}/{args.TotalBytes}");

var result1 = fileEncryptor.EncryptFile(new FileInfo(SrcFile), key);

Console.WriteLine(result1);
Console.WriteLine();

var result2 = fileEncryptor.DecryptFile(new FileInfo(EncrFile), key);
Console.WriteLine(result2);
