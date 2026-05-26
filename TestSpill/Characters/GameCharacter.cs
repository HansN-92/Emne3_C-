namespace TestSpill.Characters
{
    internal class GameCharacter
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; } = 100;
        public int Health = 100;
        public int Strength = 15;
        public int MaxStrength = 15;
        public int Block = 0;
        public int Dodge = 0;
        public int PoisonDamage { get; set; } = 0;
        public int PoisonRounds { get; set; } = 0;
        public List<string> Skills { get; set; } = new List<string>();

        public GameCharacter(string name)
        {
            Name = name;
        }

        public void AddDodge(int amount)
        {
            Dodge = Math.Min(Dodge + amount, 75);
        }

        public bool TryDodge()
        {
            if (Dodge > 0)
            {
                Random rand = new Random();
                if (rand.Next(0, 100) < Dodge)
                {
                    Console.WriteLine($"{Name} Dodged");
                    Dodge = 0;
                    return true;
                }
            }

            return false;
        }

        public void TickPoison()
        {
            if (PoisonRounds > 0)
            {
                Health -= PoisonDamage;
                PoisonRounds -= 1;
                Console.WriteLine($"{Name} takes {PoisonDamage} poison DMG. {PoisonRounds} Rounds left");
                if (PoisonRounds == 0) PoisonDamage = 0;
            }
        }

        public void ShowSkillMenu()
        {
            Console.WriteLine("Select skill:");
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1} = {Skills[i]}");
            }
            Console.WriteLine();
        }

        public void Attack(GameCharacter target)
        {
            Random rand = new Random();

            if (target.TryDodge()) return;

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
            if ((double)Health / MaxHealth < 0.4)
            {
                int heal = rand.Next(15, 30);
                Health += heal;
                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
                Console.WriteLine($"{Name} Heals for {heal} HP Current HP {Health}");
            }
            else
            {
                Console.WriteLine($"{Name} HP above threshold");
                // PlayerTurn();
            }
        }

        public virtual void UseSkill(GameCharacter target)
        {
            Console.WriteLine($"{Name} has no available skills!");
        }

        public virtual void TakeTurn(GameCharacter target)
        {
            Attack(target);
        }
    }
}
