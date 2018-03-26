using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
     where T : IComparable<T>
{
    public Box()
    {
        this.items = new List<T>();
    }

    public List<T> items { get; private set; }

    public int Count { get; private set; }

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public int CountGreaterValues(T valueToCompare)
    {

        for (int i = 0; i < this.items.Count; i++)
        {
            if (items[i].CompareTo(valueToCompare)> 0)
            {
                this.Count++;
            }
        }
        return this.Count;
    }
}

