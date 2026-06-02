namespace Bibliotek
{
    internal class Book
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Id { get; private set; }
        public string Location { get; set; }


        public Book(string title, int releaseYear, string author, string genre, string location)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Author = author;
            Genre = genre;
            Location = location;
        }

        public void CreateBookId(int id)
        {
            Id = id;
        }
    }
}
