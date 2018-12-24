namespace _01.Database
{
    using System;

    public class Database
    {
        private const int defaultCapacity = 16;

        private int[] data;
        private int currentIndex;

        private Database()
        {
            data = new int[defaultCapacity];
            currentIndex = 0;
        }
        public Database(params int[] inputValues)
            :this()
        {
            InitializeData(inputValues);
        }

        private void InitializeData(int[] inputValues)
        {
            // another way to initialize data
            Array.Copy(inputValues, data, inputValues.Length);
            this.currentIndex = inputValues.Length;
            //for (int i = 0; i < inputValues.Length; i++)
            //{
            //    data[i] = inputValues[i];
            //}
            //this.currentIndex = inputValues.Length;
        }

        public void Add(int element)
        {
            if (currentIndex >= data.Length)
            {
                throw new InvalidOperationException("Array is full.");
            }

            data[currentIndex] = element;
            currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            currentIndex--;
            data[currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            var newArray = new int[currentIndex];
            //Array.Copy(array, newArray, currentIndex);
            for (int i = 0; i < currentIndex; i++)
            {
                newArray[i] = data[i];
            }

            return newArray;
        }
    }
}
