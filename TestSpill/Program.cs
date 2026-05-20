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

            int roundNumber = 0;
            bool fightActive = true;

            Warrior tempWarrior = new Warrior("temp");
            Mage tempMage = new Mage("temp");
            Rogue tempRogue = new Rogue("temp");

            Console.WriteLine($"Select Class: \n1 = Warrior \n HP: {tempWarrior.Health} Str: {tempWarrior.Strength} Skill: {tempWarrior.Skills}" +
                                                  $"\n2 = Mage \n HP: {tempMage.Health} Str: {tempMage.Strength} Skill: {tempMage.Skills}" +
                                                  $"\n3 = Rogue \n HP: {tempRogue.Health} Str: {tempRogue.Strength} Skill: {tempRogue.Skills}");
            
            string classChoice = Console.ReadLine();

            GameCharacter player;

            switch (classChoice)
            {
                case "1":
                    player = new Warrior(inputName);
                    break;

                case "2":
                    player = new Mage(inputName);
                    break;

                case "3":
                    player = new Rogue(inputName);
                    break;
                default: 
                    player = new GameCharacter(inputName);
                    break;
            }

            Console.WriteLine($"Selected Class {player.GetType().Name}");
            Console.ReadLine();

            GameCharacter computer;
            Random rand = new Random();
            int computerClassChoice = rand.Next(1, 4);
            switch (computerClassChoice)
            {
                case 1:
                    computer = new Warrior("Computer");
                    break;

                case 2:
                    computer = new Mage("Computer");
                    break;

                case 3:
                    computer = new Rogue("Computer");
                    break;
                default:
                    computer = new GameCharacter("Computer");
                    break;
            }

            Console.WriteLine($"{player.Name} HP: {player.Health} Str: {player.Strength} Block:{player.Block}\n{computer.Name} HP: {computer.Health} Str: {computer.Strength} Block:{computer.Block}");
            Console.ReadLine();

            while (fightActive)
            {
                roundNumber += 1;
                Console.WriteLine($"Round: {roundNumber}");
                Console.WriteLine("1 = Attack \n2 = Skill \n3 = Heal");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.Attack(computer);
                        break;

                    case "2":
                        player.UseSkill(computer);
                        break;

                    case "3":
                        player.SkillHeal(player);
                        break;
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
        public int MaxHealth { get; set; } = 100;
        public int Health = 100;
        public int Strength = 30;
        public int Block = 0;
        public int Dodge = 0;
        public List<string> Skills { get; set; } = new List<string>();

        public GameCharacter(string name)
        {
            Name = name;
        }

        public void ShowSkillMenu()
        {
            Console.WriteLine("Select skill:");
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1} = {Skills[i]}");
            }
        }

        public void Attack(GameCharacter target)
        {
            Random rand = new Random();
            int damage = rand.Next(10, 20);
            int rawDamage = damage + Strength;
            int damageDealt = rawDamage - target.Block;
            if (damageDealt < 0) damageDealt = 0;
            target.Block -= rawDamage;
            if (target.Block < 0) target.Block = 0;
            target.Health -= damageDealt;

            Console.WriteLine($"{Name} HIT {target.Name} for {damageDealt} DMG");
            Console.WriteLine($"{Name} HP: {Health} Str: {Strength} Block:{Block} \n{target.Name} HP: {target.Health} Str: {target.Strength} Block:{target.Block}");
        }
        
        public void SkillHeal(GameCharacter target)
        {
            Random rand = new Random();
            int heal = rand.Next(10, 50);
            Health += heal;
            Console.WriteLine($"{Name} Heals {target.Name} for {heal} HP");
        }

        public virtual void UseSkill(GameCharacter target)
        {
            Console.WriteLine($"{Name} has no available skills!");
        }
    }

    internal class Warrior : GameCharacter
    {
        public Warrior(string name) : base(name)
        {
            MaxHealth = 150;
            Health = 150;
            Strength = 40;
            Skills = new List<string> { "Block", "StrongAttack", "Shield Slam" };
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) return;
            string selectedSkill = Skills[choice - 1];
            Random rand = new Random();
            switch (selectedSkill)
            {
                case "Block":
                    int blockedDmg = rand.Next(50, 120);
                    Block = blockedDmg;
                    Console.WriteLine($"{Name} Gain {target.Block} Block");
                    break;

                case "StrongAttack":
                    int damage = rand.Next(20, 50);
                    int damageDealt = damage + Strength;
                    target.Health -= damageDealt;
                    Console.WriteLine($"{Name} HIT {target.Name} for {damageDealt} DMG");
                    break;

                case "Shield Slam":
                    if (Block > 0)
                    {
                        int slamDmg = Block * 2 + Strength;
                        target.Health -= slamDmg;
                        Console.WriteLine($"{Name} use {selectedSkill} for {slamDmg} DMG");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} has {Block}");
                        ShowSkillMenu();
                    }
                    break;
            }
        }
    }
    internal class Mage : GameCharacter
    {
        public Mage(string name) : base(name)
        {
            MaxHealth = 80;
            Health = 80;
            Strength = 70;
            Skills = new List<string> { "Fireball", "Magic Missile", "Weaken" };
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) return;
            string selectedSkill = Skills[choice - 1];
            Random rand = new Random();
            switch (selectedSkill)
            {
                case "Fireball":
                    int damage = rand.Next(50, 100);
                    int dmgDealt = damage + Strength;
                    target.Health -= dmgDealt;
                    Console.WriteLine($"{Name} cast {selectedSkill} for {dmgDealt}");
                    break;

                case "Magic Missile":
                    int missiles = rand.Next(3, 10);
                    int missileDmg = Strength / 2;
                    target.Health -= missiles * missileDmg;
                    Console.WriteLine($"{Name} cast {selectedSkill} and HIT {missiles} for {missileDmg} each");
                    break;

                case "Weaken":
                    target.Strength /= 2;
                    Console.WriteLine($"{Name} cast {selectedSkill} on {target} reducing Str to {target.Strength}");
                    break;
            }
        }
    }
    internal class Rogue : GameCharacter
    {
        public Rogue(string name) : base(name)
        {
            MaxHealth = 100;
            Health = 100;
            Strength = 50;
            Dodge = 0;
            Skills = new List<string> { "Crit", "Poison Dagger", "Dodge" };
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) return;
            string selectedSkill = Skills[choice - 1];
            Random rand = new Random();
            switch (selectedSkill)
            {
                case "Crit":
                    if ((double)target.Health / target.MaxHealth < 0.5)
                    {
                        int critMultiplier = rand.Next(2, 5);
                        int damage = rand.Next(10, 30);
                        int damageDealt = damage + Strength / 2 * critMultiplier;
                        target.Health -= damageDealt;
                        Console.WriteLine($"{Name} used {selectedSkill}*{critMultiplier} for {damageDealt}");
                    }
                    else
                    {
                        Console.WriteLine($"{target.Name} HP threshold not met");
                        ShowSkillMenu();
                    }
                    break;

                case "Poison Dagger":
                    int psnDamage = rand.Next(10, 20);
                    int psnDuration = rand.Next(1, 5);
                    int psnDamageDealt = psnDamage;
                    target.Health -= psnDamageDealt;
                    
                    Console.WriteLine($"{Name} used {selectedSkill} dealing {psnDamageDealt} for {psnDuration}");
                    break;

                case "Dodge":
                    int dodgeChance = rand.Next(20, 50);
                    Dodge += dodgeChance;
                    Console.WriteLine($"{Name} used {selectedSkill} gaining {dodgeChance}");
                    break;
            }
        }
    }
}
