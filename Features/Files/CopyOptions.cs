using System.ComponentModel.DataAnnotations;

namespace Features.Files;

public enum Action {
    Backup = 1,
    Restore = 2
}

public class CopyOptions {
    [Key]
    public required int CopyOptionsId { get; init; }
    public bool Overwrite { get; init; } = true;
    public bool Recursive { get; init; } = true;
    public bool CreateParentDirectory { get; init; } = true;
    public required string InputPath { get; init; }
    public required string OutputPath {get; init; }
    public required Action Action { get; init; }
}

