namespace Code_Along
{
    internal class Nettbank
    {
        public static void Run()
        {
            Console.WriteLine($"Velkommen til Nettbanken \n\nVenligst logg inn: " +
                              $"\n\nBruker: {Console.ReadLine()} " +
                              $"\n\nPassord: {Console.ReadLine()}");
            Console.ReadLine();
        }
    }
}
