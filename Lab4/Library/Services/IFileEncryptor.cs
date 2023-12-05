using Library.Models;
using Library.Models.Events;

namespace Library.Services;

public interface IFileEncryptor
{
    event EventHandler<EncryptionProgressChangedEventArgs>? EncryptionProgressChanged;
    event EventHandler<EncryptionProgressChangedEventArgs>? DecryptionProgressChanged;

    Task<EncryptionReport> EncryptFile(FileInfo file, string encryptionKey, WaitingToken waitingToken);

    Task<EncryptionReport> DecryptFile(FileInfo file, string encryptionKey, WaitingToken waitingToken);
}
