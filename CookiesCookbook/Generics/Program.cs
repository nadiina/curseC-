
var numbers = new SimpleList<int>();
numbers.Add(10);

var words = new SimpleList<string>();
words.Add("a");
public class SimpleList<T>
{
    private T[] _items = new T[4];
    private int _size = 0;

    
    public void Add(T item)
    {
        if(_size == _items.Length)
        {
            var newItems = new T[_items.Length*2];

            for(int i = 0; i < newItems.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        _items[_size] = item;
        ++_size;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside");
        }

        --_size;

        for(int i = index; i< _size; i++)
        {
            _items[i] = _items[i +1];
        }
        _items[_size] = default;
    }

    public T GetAtIndex (int index)
    {

        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside");
        }
        return _items[index];
    }
}