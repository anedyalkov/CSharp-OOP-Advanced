namespace _08.CustomListSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomList<T> : ISortable
        where T : IComparable<T>
    {
        public CustomList()
        {
            this.data = new List<T>();
        }

        public List<T> data { get; private set; }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public T Remove(int index)
        {
            T elementToRemove = data[index];
            this.data.RemoveAt(index);
            return elementToRemove;
        }

        public bool Contains(T element)
        {
            if (this.data.Contains(element))
            {
                return true;
            }

            return false;
        }

        public void Swap(int firsIndex, int secondIndex)
        {
            var temp = data[firsIndex];
            this.data[firsIndex] = data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public int CountGreaterThan(T valueToCompare)
        {
            var count = 0;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (data[i].CompareTo(valueToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            var result = this.data.Max();
            return result;
        }

        public T Min()
        {
            var result = this.data.Min();
            return result;
        }

        public string Print()
        {
            var sb = new StringBuilder();
            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public void Sort()
        {
            this.data.Sort();
        }
    }
}
