namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private IReadOnlyList<Book> books;

            private int index;

            public LibraryIterator(IReadOnlyList<Book> books)
            {
                this.books = books.ToList();
                this.index = -1;
            }
            public Book Current => this.books[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;
                return index < this.books?.Count;
            }

            public void Reset()
            {
                throw new System.NotSupportedException();
            }
        }
    }
}
