namespace Test
{
    internal class Program
    {
        static string GetRandomHobby()
        {
            string[] hobbies =
            {
                "a magician. Poof, magic!",
                "an official toad-licker. Sorry.",
                "a competitive napper. Zzz.",
                "a professional cloud-watcher.",
                "a salsa dancer. Ole!"
            };

            Random random = new Random();
            int index = random.Next(0, hobbies.Length);
            return hobbies[index];

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Who would like a new hobby? ");
                string name = Console.ReadLine();

                string hobby = GetRandomHobby();

                Console.WriteLine(name + " is now " + hobby);
                Console.WriteLine();
            }
        }
    }
}
