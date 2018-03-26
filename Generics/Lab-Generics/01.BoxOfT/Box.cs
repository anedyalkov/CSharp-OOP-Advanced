using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove()
    {
        var element = items.Last();
        this.items.RemoveAt(items.Count - 1);
        return element;
    }

    public int Count => this.items.Count();
}

