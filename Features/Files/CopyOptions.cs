namespace Features.Files;

public class CopyOptions {
    public bool Overwrite { get; init; } = true;
    public bool Recursive { get; init; } = true;
    public bool CreateParentDirectory { get; init; } = true;
    public required string InputPath { get; init; }
    public required string OutputPath {get; init; }
}

