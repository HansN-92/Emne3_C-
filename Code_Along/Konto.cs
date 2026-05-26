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

        public void ShowInfo()
        {
            Console.WriteLine($"Konto: {KontoNr} | Type: {TypeKonto} | Saldo: {Saldo} kr");
        }
        
    }
}
