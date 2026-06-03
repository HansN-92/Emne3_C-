namespace Bibliotek
{
    internal class App
    {

        public static void Run()
        {
            Library library = new Library();

            library.AddBook(new Book(
            "The Fellowship of the Ring",
            1954,
            "J.R.R. Tolkien",
            "Fantasy",
            "Shelf A1"));

            library.AddBook(new Book(
            "The Two Towers",
            1954,
            "J.R.R. Tolkien",
            "Fantasy",
            "Shelf A1"));

            library.AddBook(new Book(
            "The Return of the King",
            1955,
            "J.R.R. Tolkien",
            "Fantasy",
            "Shelf A1"));

            library.AddBook(new Book(
            "The Hobbit",
            1937,
            "J.R.R. Tolkien",
            "Fantasy",
            "Shelf A1"));

            library.AddBook(new Book(
            "The Silmarillion",
            1977,
            "J.R.R. Tolkien",
            "Fantasy",
            "Shelf A2"));

            library.AddBook(new Book(
            "The Firm",
            1991,
            "John Grisham",
            "Legal Thriller",
            "Shelf B1"));

            library.AddBook(new Book(
            "1984",
            1949,
            "George Orwell",
            "Dystopian Fiction",
            "Shelf B2"));

            library.AddBook(new Book(
            "The Art of War",
            -500,
            "Sun Tzu",
            "Military Strategy",
            "Shelf C1"));

            library.AddBook(new Book(
            "Dracula",
            1897,
            "Bram Stoker",
            "Gothic Horror",
            "Shelf C2"));

            library.AddBook(new Book(
            "Frankenstein",
            1818,
            "Mary Shelley",
            "Gothic Horror",
            "Shelf C2"));

            //bool libraryRunning = true;

            //while (libraryRunning)
            //{
            //}

            Menu.ShowMain(library);

        }
    }
}
