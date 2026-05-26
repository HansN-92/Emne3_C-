namespace TestSpill.Characters
{
    internal class Rogue : GameCharacter
    {
        public Rogue(string name) : base(name)
        {
            MaxHealth = 110;
            Health = 110;
            Strength = 20;
            MaxStrength = 20;
            Dodge = 0;
            Skills = new List<string> { "Crit", "Poison Dagger", "Dodge" };
        }

        public void UseSkillCrit(GameCharacter target)
        {
            if ((double)target.Health / target.MaxHealth < 0.4)
            {
                Random rand = new Random();
                if (target.TryDodge()) return;
                int critMultiplier = rand.Next(2, 3);
                int damage = rand.Next(10, 30);
                int damageDealt = damage + Strength / 2 * critMultiplier;
                target.Health -= damageDealt;
                Console.WriteLine($"{Name} Crit *{critMultiplier} for {damageDealt}");
            }
            else
            {
                Console.WriteLine($"{target.Name} HP threshold not met");
                UseSkill(target);
            }
        }
        public void UseSkillPoisonDagger(GameCharacter target)
        {
            Random rand = new Random();
            if (target.TryDodge()) return;
            target.PoisonDamage = rand.Next(10, 16);
            target.PoisonRounds = rand.Next(2, 5);

            int rawDamage = target.PoisonDamage + Strength;
            int damageDealtRogue = rawDamage - target.Block;
            if (damageDealtRogue <= 0)
            {
                damageDealtRogue = 0;
                target.PoisonRounds = 0;
                target.PoisonDamage = 0;
            }
            target.Block -= rawDamage;
            if (target.Block < 0) target.Block = 0;
            target.Health -= damageDealtRogue;

            Console.WriteLine($"{Name} used PoisonDagger dealing {target.PoisonDamage} for {target.PoisonRounds}");
        }
        public void UseSkillDodge(GameCharacter target)
        {
            Random rand = new Random();
            int dodgeAmount = rand.Next(15, 35);
            AddDodge(dodgeAmount);
            Console.WriteLine($"{Name} used Dodge gaining {dodgeAmount}% dodge chance for a total chance of {Dodge}%");
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            ConsoleKeyInfo selectedSkill = Console.ReadKey(true);
            switch (selectedSkill.Key)
            {
                case ConsoleKey.D1:
                    UseSkillCrit(target);
                    break;

                case ConsoleKey.D2:
                    UseSkillPoisonDagger(target);
                    break;

                case ConsoleKey.D3:
                    UseSkillDodge(target);
                    break;
                default:
                    UseSkill(target);
                    break;
            }
        }

        public override void TakeTurn(GameCharacter target)
        {
            if ((double)target.Health / target.MaxHealth < 0.4)
            {
                UseSkillCrit(target);
            }
            else if ((double)target.Health / target.MaxHealth > 0.5 && target.PoisonRounds <= 1)
            {
                UseSkillPoisonDagger(target);
            }
            else if ((double)Health / MaxHealth < 0.5 && Dodge < 50)
            {
                UseSkillDodge(target);
            }
            else
            {
                Attack(target);
            }
        }
    }
}
