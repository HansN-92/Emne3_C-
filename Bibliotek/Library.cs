namespace Bibliotek
{
    internal class Library
    {
        private List<Book> _books = new List<Book>();
        private int _nextId = 1;

        public void AddBook(Book book)
        {
            book.CreateBookId(_nextId++);
            _books.Add(book);
        }

        public bool RemoveBook(int id)
        {
            Book book = FindBookId(id);
            if (book == null) 
                return false;
            _books.Remove(book);
            return true;
        }

        public List<Book> SearchBooks(string searchInput)
        {
            List<Book> results = new List<Book>();
            foreach (Book book in _books)
            {
                if (book.Title.ToLower().Contains(searchInput) ||
                    book.Author.ToLower().Contains(searchInput) ||
                    book.Genre.ToLower().Contains(searchInput) ||
                    book.ReleaseYear.ToString().Contains(searchInput) ||
                    book.Location.ToLower().Contains(searchInput))
                {
                    results.Add(book);
                }
            }
            return results;
        }

        public List<Book> ShowAllBooks()
        {
            return new List<Book>(_books);
        }

        public Book FindBookId(int id)
        {
            foreach (Book book in _books)
                if (book.Id == id) 
                    return book;

            return null;
        }
    }
}
