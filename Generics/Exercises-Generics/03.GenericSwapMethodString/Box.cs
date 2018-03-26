using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    public Box()
    {
        this.items = new List<T>();
    }

    public List<T> items { get; set; }

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public void Swap(int firsIndex, int secondIndex)
    {
        T temp = items[firsIndex];
        items[firsIndex] = items[secondIndex];
        items[secondIndex] = temp;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in items)
        {
            sb.AppendLine($"{item.GetType().FullName}: {item}");
        }

        var result = sb.ToString().Trim();
        return result; 
    }
}

