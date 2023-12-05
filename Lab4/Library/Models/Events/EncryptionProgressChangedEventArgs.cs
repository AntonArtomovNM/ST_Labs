namespace Library.Models.Events;

public class EncryptionProgressChangedEventArgs : EventArgs
{
    public long TotalBytes { get; }

    public long ProcessedBytes { get; }

    public EncryptionProgressChangedEventArgs(long totalBytes, long processedBytes)
    {
        TotalBytes = totalBytes;
        ProcessedBytes = processedBytes;
    }
}
