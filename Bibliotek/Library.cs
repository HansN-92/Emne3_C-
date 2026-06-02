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
        
        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public void SearchBooks()
        {

        }        
        
        public void ShowAllBooks()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine($"{book}");
            }
        }
    }
}
