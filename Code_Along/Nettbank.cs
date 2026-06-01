namespace Code_Along
{
    internal class Nettbank
    {
        public static void Run()
        {
            //Console.WriteLine($"Velkommen til Nettbanken \n\nVennligst logg inn: " +
            //                  $"\n\nBruker: {Console.ReadLine()} " +
            //                  $"\n\nPassord: {Console.ReadLine()}");

            Kunde bjarne = new Kunde("Bjarne", new List<Konto>
            {
                new (100000, "Bjarne", "Sparekonto", 123456789),
                new (10000, "Bjarne", "Brukskonto", 987654321),
                new (50000, "Bjarne", "Regningskonto", 111222333)
            });
            bool CustomerMenuUi = true;
            while (CustomerMenuUi)
            {
                Console.Clear();
                CustomerMenu();

                void CustomerMenu()
                {

                    Console.WriteLine(
                        $"Velkommen {bjarne.Name} \nValg: \n1: Se kontoer \n2: Innskudd \n3: Uttak \n4: Overfør");

                    ConsoleKeyInfo customerMenuChoice = Console.ReadKey(true);

                    switch (customerMenuChoice.Key)
                    {
                        case ConsoleKey.D1:
                            bjarne.ShowInfo();
                            Console.ReadLine();
                            break;

                        case ConsoleKey.D2:
                            DepositMenuUi();
                            break;

                        case ConsoleKey.D3:
                            WithdrawMenuUi();
                            break;

                        case ConsoleKey.D4:
                            TransferMenuUi();
                            break;

                        default:
                            CustomerMenu();
                            break;
                    }
                }

                void DepositMenuUi()
                {
                    bjarne.ShowInfo();
                    Console.WriteLine("Velg konto for innskudd 1-3:");
                    if (int.TryParse(Console.ReadLine(), out int valg) && valg >= 1 && valg <= bjarne.Kontoer.Count)
                    {
                        bjarne.Kontoer[valg - 1].Deposit();
                    }
                }
                
                void WithdrawMenuUi()
                {
                    bjarne.ShowInfo();
                    Console.WriteLine("Velg konto for uttak 1-3:");
                    if (int.TryParse(Console.ReadLine(), out int valg) && valg >= 1 && valg <= bjarne.Kontoer.Count)
                    {
                        bjarne.Kontoer[valg - 1].Withdraw();
                    }
                }
                
                void TransferMenuUi()
                {
                    bjarne.ShowInfo();
                    Console.WriteLine("Velg FRA konto for overføring 1-3:");
                    if (int.TryParse(Console.ReadLine(), out int valg) && valg >= 1 && valg <= bjarne.Kontoer.Count)
                    {
                        bjarne.ShowInfo();
                        Console.WriteLine("Velg TIL konto for overføring 1-3:");
                        if (int.TryParse(Console.ReadLine(), out int valgTil) && valgTil >= 1 && valgTil <= bjarne.Kontoer.Count)
                            if (valg == valgTil)
                            {
                                Console.WriteLine("Du har valgt samme konto Fra og Til. Overføring kan ikke gjennomføres.");
                                TransferMenuUi();
                                return;
                            }
                        bjarne.Kontoer[valg - 1].Transfer(bjarne.Kontoer[valgTil - 1]);
                    }
                }
            }
        }
    }
}
