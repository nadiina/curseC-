using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

var ints = CreateCollectionOfRandomLength<int>(60);
stopwatch.Stop();

Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");
Console.ReadKey();
IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new()
{
    //var length = new Random().Next(maxLength + 1);
    var length = 100000000;
    var res = new List<T>();

    for (int i = 0; i < length; i++)
    {
        res.Add(new T());
    }
    return res;
}