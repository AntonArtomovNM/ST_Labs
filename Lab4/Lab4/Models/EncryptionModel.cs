using UI.Models.Enums;

namespace UI.Models;

public record EncryptionModel(FileInfo FileInfo, string EncryptionKey, OperationType OperationType);
