using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
     where T : IComparable<T>
{
    public Box()
    {
        this.items = new List<T>();
    }

    public List<T> items { get; private set; }

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public T Remove(int index)
    {
        var removedItem = items[index];
        this.items.RemoveAt(index);
        return removedItem;
    }

    public bool Contains(T element)
    {
        if (this.items.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void Swap(int firsIndex, int secondIndex)
    {
        var temp = items[firsIndex];
        this.items[firsIndex] = items[secondIndex];
        this.items[secondIndex] = temp;
    }

    public int CountGreaterThan(T valueToCompare)
    {
        var count = 0;

        for (int i = 0; i < this.items.Count; i++)
        {
            if (items[i].CompareTo(valueToCompare) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        var result = this.items.Max();
        return result;
    }

    public T Min()
    {
        var result = this.items.Min();
        return result;
    }

    public void Print()
    {
        foreach (var item in this.items)
        {
            Console.WriteLine(item);
        }
    }
}

