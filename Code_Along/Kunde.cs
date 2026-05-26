namespace Code_Along
{
    internal class kunde
    {
        public string BrukerNavn { get; set; }
        private string Passord { get; set; }
        public string Name { get; set; }
        public List<Konto> Kontoer { get; set; } = new List<Konto>();

        public kunde(string name)
        {
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n--- {Name} sine kontoer ---");
            foreach (var k in Kontoer)
            {
                k.ShowInfo();
            }
        }
    }
}
