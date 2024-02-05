namespace ConsoleApp1.DataAccess;

public class StringTextualRepository : StringRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringeToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return fileContents.Split(Separator).ToList();
    }
}
