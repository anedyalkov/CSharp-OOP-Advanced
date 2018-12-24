namespace _01.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator<T>
    {
        private int internalIndex;

        private List<T> data;

        public ListIterator(T[] commandArgs)
        {
            internalIndex = 0;
            data = new List<T>(commandArgs);
        }
        public bool HasNext()
        {
            bool result = internalIndex < this.data.Count - 1;
            return result;
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }

            this.internalIndex++;
            return true;
        }

        public T Print()
        {
            if (!this.data.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.data[internalIndex];
        }
    }
}
