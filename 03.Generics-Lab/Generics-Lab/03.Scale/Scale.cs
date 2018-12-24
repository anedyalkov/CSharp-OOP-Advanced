namespace GenericScale
{
    using System;

    public class Scale<T>
        where T: IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            int comparisonResult = this.left.CompareTo(this.right);

            if (comparisonResult > 0)
            {
                return this.left;
            }
            else if (comparisonResult < 0)
            {
                return this.right;
            }
            else
            {
                return default(T);
            }
        }
    }
}
