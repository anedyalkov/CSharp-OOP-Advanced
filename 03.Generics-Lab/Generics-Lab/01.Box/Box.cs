using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;
        public Box()
        {
            data = new List<T>();
        }
        public int Count => data.Count;

        public IReadOnlyCollection<T> Data => data.AsReadOnly();

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            var lastItem = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return lastItem;
        }
    }
}
