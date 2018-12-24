namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator<T> : IEnumerable<T>
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

        public void Print()
        {
            if (!this.data.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[internalIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < this.data.Count; index++)
            {
                yield return this.data[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
