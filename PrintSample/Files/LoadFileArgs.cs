namespace PrintSample.Files
{
    public record LoadSpreadsheetArgs(string FilePath, string SheetName);
    public record LoadPdfFileArgs(string FilePath);
}