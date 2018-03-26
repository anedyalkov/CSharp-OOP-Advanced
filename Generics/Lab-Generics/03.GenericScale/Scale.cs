using System;

public class Scale<T>:IScalable<T>
    where T: IComparable<T>
{
    public T Left { get; }

    public T Right { get; }


    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHeavier()
    {
        var result = this.Left.CompareTo(this.Right);
        if (result > 0 )
        {
            return this.Left;
        }
        else if (result < 0)
        {
            return this.Right;
        }

        return default(T);
    }
}

