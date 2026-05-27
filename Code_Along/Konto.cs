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
            Console.ReadKey(true);
        }

        public void Deposit(int beløp)
        {
            var input = Console.ReadLine();
            beløp = input;
            Saldo += beløp;
            Console.WriteLine($"Du har satt inn: {beløp}. Ny saldo er: {Saldo}.");
            Console.ReadKey(true);
        }

        public void Withdraw(int beløp)
        {
            var input = Console.ReadLine();
            beløp = input;
            Saldo -= beløp;
            Console.WriteLine($"Du har tatt ut: {beløp}. Ny saldo er: {Saldo}.");
            Console.ReadKey(true);
        }

        public void Transfer(Konto til, int beløp)
        {
            var input = Console.ReadLine();
            beløp = input;
            Saldo -= beløp;
            til.KontoNr = til;
            til.Saldo += beløp;

            Console.WriteLine($"Du har overført: {beløp} Fra: {KontoNr} Til: {til.KontoNr} \nNy Saldo: {Saldo}");
            Console.ReadKey(true);
        }

    }
}
