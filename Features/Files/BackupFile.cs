#nullable disable

namespace Features.Files;

public enum ItemType {
    File,
    Directory
}

public class BackupFile
{
    public required int BackUpId { get; init; }
    public required string FileName { get; set; }
    public ItemType ItemType { get; set; }
    //TODO: convert to path here maybe?
    public required string FilePath { get; set; }
    public required DateTime LastModified { get; set; }
    public required DateTime DateAdded { get; init; }
    //TODO: maybe better way to do this. This should be the file Hash
    // to check if we have to copy a file over or not to help save
    // some cpu cycles
    // TODO: also have to do some hash validation here methinks
    public required string FileHash {get; set; }
}

public class BackUpAudit(bool success)
{
    public required DateTime BackUpTime { get; init; } = DateTime.Now;
    public required bool Success { get; set; } = success;
}


