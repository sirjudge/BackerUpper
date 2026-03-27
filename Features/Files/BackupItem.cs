#nullable disable

namespace Features.Files;

public enum ItemType {
    File,
    Directory
}

public class BackupFile
{
    public required string FileName { get; init; }
    public ItemType ItemType { get; set; }
    //TODO: convert to path here maybe?
    public required string  FilePath { get; init; }
    public required DateTime LastModified { get; init; }
    public required DateTime DateAdded { get; init; }
    //TODO: maybe better way to do this. This should be the file Hash
    // to check if we have to copy a file over or not to help save
    // some cpu cycles
    public required HashCode FileHash {get; init; }
}

public class BackUpAudit(bool success)
{
    public required DateTime BackUpTime { get; init; } = DateTime.Now;
    public required bool Success { get; set; } = success;
}
