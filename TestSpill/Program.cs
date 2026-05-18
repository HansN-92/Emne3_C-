using System.Linq.Expressions;

namespace TestSpill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name:");
            string inputName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputName))
            {
                inputName = "Player";
            }

            GameCharacter player = new GameCharacter(inputName);
            GameCharacter computer = new GameCharacter("Computer");
            bool fightActive = true;

            Console.WriteLine($"{player.Name} HP: {player.Health} Str: {player.Strength} Block:{player.Block}\n{computer.Name} HP: {computer.Health} Str: {computer.Strength} Block:{computer.Block}");
            Console.ReadLine();

            while (fightActive)
            {
                Console.WriteLine("1. Angrip  2. Skill");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.Attack(computer);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Select Skill: \n1 = Block \n2 = Unblockable Strong Attack \n3 = Heal");
                    string skillChoice = Console.ReadLine();
                    switch (skillChoice)
                    {
                        case "1":
                            Console.WriteLine($"{player.Name} used Block");
                            player.SkillBlock(player);
                            break;
                        case "2":
                            Console.WriteLine($"{player.Name} used Unblockable Strong Attack");
                            player.SkillStrongAttack(computer);
                            break;

                        case "3":
                            Console.WriteLine($"{player.Name} used Heal");
                            player.SkillHeal(player);
                            break;
                    }
                }

                if (computer.Health <= 0)
                {
                    Console.WriteLine($"\n{player.Name} WIN");
                    fightActive = false;
                    break;
                }
                Console.ReadLine();

                computer.Attack(player);

                if (player.Health <= 0)
                {
                    Console.WriteLine($"\n{computer.Name} WIN");
                    fightActive = false;
                    break;
                }
                Console.ReadLine();
            }
        }
    }

    internal class GameCharacter
    {
        public string Name { get; set; }
        public int Health = 100;
        public int Strength = 50;
        public int Block = 0;

        public GameCharacter(string name)
        {
            Name = name;
        }

        public void Attack(GameCharacter target)
        {
            Random rand = new Random();
            int Damage = rand.Next(10, 20);
            int DamageDealt = Damage + Strength - target.Block;
            if (DamageDealt < 0) DamageDealt = 0;
            target.Block -= DamageDealt;
            if (target.Block < 0) target.Block = 0;
            target.Health -= DamageDealt;

            Console.WriteLine($"{Name} HIT {target.Name} for {DamageDealt} DMG");
            Console.WriteLine($"{Name} HP: {Health} Str: {Strength} Block:{Block} \n{target.Name} HP: {target.Health} Str: {target.Strength} Block:{target.Block}");
        }

        public void SkillBlock(GameCharacter target)
        {
            Random rand = new Random();
            int blockedDMG = rand.Next(25, 50);
            target.Block = blockedDMG;
            Console.WriteLine($"{Name} Blocks: {target.Block} DMG");
        }
        
        public void SkillStrongAttack(GameCharacter target)
        {
            Random rand = new Random();
            int Damage = rand.Next(10, 50);
            int DamageDealt = Damage + Strength;
            target.Health -= DamageDealt;
            Console.WriteLine($"{Name} HIT {target.Name} for {DamageDealt} DMG");
        }
        
        public void SkillHeal(GameCharacter target)
        {
            Random rand = new Random();
            int Heal = rand.Next(10, 50);
            Health += Heal;
            Console.WriteLine($"{Name} Heals {target.Name} for {Heal} HP");
        }
    }
}
