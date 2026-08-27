namespace MtgCsWriter;

internal class Program
{
    public static void Main()
    {
        
    }
}

public record SetObject
{
    public required string Name;
    public required string Code;
    public required string ScryfallUri;
    public required string ReleasedAt;
    public required string IconSvgUri;
}

public record ListObject
{
    public required string Object;
    public required bool HasMore;
    public required List<SetObject> Data;
}