#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Features.Files;

public class BackupFile
{
    [Key]
    public required int? BackUpId { get; init; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required DateTime LastModified { get; set; }
    public required DateTime DateAdded { get; init; }
    public required string FileHash {get; set; }
    public required bool IsDirectory {get; set; }
}

public class BackUpAudit(bool success)
{
    [Key]
    public required int BackUpAuditId { get; init; }
    public required DateTime BackUpTime { get; init; } = DateTime.Now;
    public required bool Success { get; set; } = success;
}


