namespace Code_Along
{
    internal class Konto
    {
        public int Saldo { get; set; }
        public string KontoEier { get; set; }
        public string TypeKonto { get; set; }
        public int KontoNr { get; set; }

        public Konto(int saldo, string kontoEier, string typeKonto, int kontoNr)
        {
            Saldo = saldo;
            KontoEier = kontoEier;
            TypeKonto = typeKonto;
            KontoNr = kontoNr;
        }

        public void ShowKontoInfo()
        {
            Console.WriteLine($"Konto: {KontoNr} | Type: {TypeKonto} | Saldo: {Saldo} kr");
        }

        public void Deposit()
        {
            Console.WriteLine($"Sett inn på {TypeKonto} \n Skriv Beløp:");
            if (!int.TryParse(Console.ReadLine(), out int beløp)) return;
            Saldo += beløp;
            Console.WriteLine($"Du har satt inn: Kr {beløp},- Ny saldo: Kr {Saldo},-");
            Console.ReadKey(true);
        }

        public void Withdraw()
        {
            Console.WriteLine($"Ta ut fra {TypeKonto} \n Skriv Beløp:");
            if (!int.TryParse(Console.ReadLine(), out int beløp)) return;
            if (beløp <= Saldo)
            {
                Saldo -= beløp;
                Console.WriteLine($"Du har tatt ut: Kr {beløp},- Ny saldo: Kr {Saldo},-");
                Console.ReadKey(true);

            }
            else
            {
                Console.WriteLine($"Ikke nok på {TypeKonto} Saldo: Kr {Saldo},-");
                Withdraw();
            }
        }

        public void Transfer(Konto til)
        {
            Console.WriteLine($"Overfør fra {TypeKonto} til {til.TypeKonto} \n Skriv Beløp:");
            if (!int.TryParse(Console.ReadLine(), out int beløp)) return;
            if (beløp <= Saldo)
            {
                Saldo -= beløp;
                til.Saldo += beløp;

                Console.WriteLine($"Du har overført: Kr {beløp},- Fra: {TypeKonto} Til: {til.TypeKonto} \nNy Saldo: {TypeKonto} Kr: {Saldo},- \nNy Saldo: {til.TypeKonto} Kr: {til.Saldo},-");
                Console.ReadKey(true);

            }
            else
            {
                Console.WriteLine($"Ikke nok på {TypeKonto} Saldo: Kr {Saldo},-");
                Withdraw();
            }
        }

    }
}
