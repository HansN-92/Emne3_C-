namespace Code_Along
{
    internal class Kunde
    {
        public string BrukerNavn { get; set; }
        private string Passord { get; set; }
        public string Name { get; set; }
        public List<Konto> Kontoer { get; set; } = new List<Konto>();

        public Kunde(string name, List<Konto> kontoer)
        {
            Name = name;
            Kontoer = kontoer;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n--- {Name} sine kontoer ---");
            foreach (var k in Kontoer)
            {
                k.ShowKontoInfo();
            }
        }
    }
}
