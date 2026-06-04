namespace Bibliotek
{
    internal class Menu
    {
        public static void ShowMain(Library library)
        {
            Console.WriteLine("Bibliotek \n Hva vil du gjøre? " +
                              "\n  1. Se alle Bøker" +
                              "\n  2. Søk" +
                              "\n  3. Legg til Bok" +
                              "\n  4. Slett Bok " +
                              "\n  Q. Exit ");

            ConsoleKeyInfo mainChoice = Console.ReadKey(true);
            switch (mainChoice.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    foreach (Book book in library.ShowAllBooks())
                        ShowBook(book);
                    Pause(library);
                    break;

                case ConsoleKey.D2:
                    SearchMenu(library);
                    break;

                case ConsoleKey.D3:
                    AddBookMenu(library);
                    break;

                case ConsoleKey.D4:
                    DeleteMenu(library);
                    break;

                case ConsoleKey.Q:
                    ExitConfirm(library);
                    break;

                default:
                    ShowMain(library);
                    break;

            }

        }

        private static void SearchMenu(Library library)
        {
            Console.Clear();
            Console.WriteLine("Søk:");
            string input = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowMain(library);
                return;
            }

            List<Book> results = library.SearchBooks(input);
            Console.Clear();

            if (results.Count == 0)
            {
                Console.WriteLine("Ingen treff");
            }
            else
            {
                foreach (Book book in results)
                {
                    ShowBook(book);
                }

            }

            Pause(library);
        }

        private static void DeleteMenu(Library library)
        {
            Console.Clear();
            Console.WriteLine("Søk etter bok for sletting:");
            string input = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowMain(library);
                return;
            }

            List<Book> results = library.SearchBooks(input);
            Console.Clear();

            if (results.Count == 0)
            {
                Console.WriteLine("Ingen treff");
                Pause(library);
                return;
            }
            
            foreach (Book book in results)
            {
                ShowBook(book);
            }

            Console.WriteLine("\nSkriv inn ID på boken du vil slette (0 = avbryt):");
            if (!int.TryParse(Console.ReadLine(), out int id) || id == 0)
            {
                ShowMain(library);
                return;
            }

            Book toDelete = library.FindBookId(id);
            if (toDelete == null)
            {
                Console.WriteLine("Fant ikke bok med den ID-en.");
                Pause(library);
                return;
            }

            Console.WriteLine($"\nEr du sikker på at du vil slette?");
            ShowBook(toDelete);
            Console.WriteLine(" Y / N ");

            ConsoleKeyInfo confirm = Console.ReadKey(true);
            if (confirm.Key == ConsoleKey.Y)
            {
                library.RemoveBook(id);
                Console.WriteLine("Bok slettet");
            }
            else
                Console.WriteLine("Sletting avbrutt");

            Pause(library);

        }

        private static void AddBookMenu(Library library)
        {
            Console.Clear();

            string title;
            do
            {
                Console.WriteLine("Tittel:");
                title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                    Console.WriteLine("Tittel kan ikke være tom.");
            } 
            while (string.IsNullOrWhiteSpace(title));

            string author;
            do
            {
                Console.WriteLine("Forfatter:");
                author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(author))
                    Console.WriteLine("Forfatter kan ikke være tom.");
            } 
            while (string.IsNullOrWhiteSpace(author));

            int year;
            string input;
            do
            {
                Console.WriteLine("År:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out year))
                    Console.WriteLine("År må være et gyldig tall.");
            } 
            while (!int.TryParse(input, out year));

            string genre;
            do
            {
                Console.WriteLine("Sjanger:");
                genre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(genre))
                    Console.WriteLine("Sjanger kan ikke være tom.");
            } 
            while (string.IsNullOrWhiteSpace(genre));

            string location;
            do
            {
                Console.WriteLine("Plassering:");
                location = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(location))
                    Console.WriteLine("Plassering kan ikke være tom.");
            } 
            while (string.IsNullOrWhiteSpace(location));

            library.AddBook(new Book(title, year, author, genre, location));
            Console.WriteLine($"Bok lagt til i bibliotek med plassering: {location}");
            Pause(library);
        }

        private static void ExitConfirm(Library library)
        {
            Console.Clear();
            Console.WriteLine("Er du sikker på at du vil avslutte?  Y / N ");
            ConsoleKeyInfo confirm = Console.ReadKey(true);
            if (confirm.Key == ConsoleKey.Y)
                Environment.Exit(0);
            else
                ShowMain(library);
        }

        private static void Pause(Library library)
        {
            Console.WriteLine("\nTrykk Enter for å gå til Main");
            Console.ReadLine();
            Console.Clear();
            ShowMain(library);
        }

        private static void ShowBook(Book book)
        {
            Console.WriteLine($"[{book.Id}] {book.Title} - {book.Author} ({book.ReleaseYear}) | {book.Genre} | {book.Location}");
        }

    }
}
