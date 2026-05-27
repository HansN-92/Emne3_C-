namespace Code_Along
{
    internal class Nettbank
    {
        public static void Run()
        {
            //Console.WriteLine($"Velkommen til Nettbanken \n\nVenligst logg inn: " +
            //                  $"\n\nBruker: {Console.ReadLine()} " +
            //                  $"\n\nPassord: {Console.ReadLine()}");

            CustomerMenu();
                void CustomerMenu()
                {
                    Kunde bjarne = new Kunde("Bjarne", new List<Konto>("BruksKonto, SpareKonto)");

                    Console.WriteLine($"Velkommen {bjarne.Name} \nValg: \n1: Se kontoer \n2: Innskudd \n3: Uttak \n4: Overfør");
                }
        }
    }
}
