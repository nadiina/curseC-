namespace ConsoleApp1.DataAccess;

public interface IStringslRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}
