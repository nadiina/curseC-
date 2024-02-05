var numbers = new int[0];
var firstElem = GetFirstElement(numbers);
Console.WriteLine(firstElem);

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }

    throw new Exception(); 
}