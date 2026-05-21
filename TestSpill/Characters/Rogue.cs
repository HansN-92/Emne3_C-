namespace TestSpill.Characters
{
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

        public void UseSkillCrit(GameCharacter target)
        {
            if ((double)target.Health / target.MaxHealth < 0.5)
            {
                Random rand = new Random();
                if (target.TryDodge()) return;
                int critMultiplier = rand.Next(2, 5);
                int damage = rand.Next(10, 30);
                int damageDealt = damage + Strength / 2 * critMultiplier;
                target.Health -= damageDealt;
                Console.WriteLine($"{Name} Crit *{critMultiplier} for {damageDealt}");
            }
            else
            {
                Console.WriteLine($"{target.Name} HP threshold not met");
                ShowSkillMenu();
            }
        }
        public void UseSkillPoisonDagger(GameCharacter target)
        {
            Random rand = new Random();
            if (target.TryDodge()) return;
            target.PoisonDamage = rand.Next(10, 20);
            target.PoisonRounds = rand.Next(2, 5);

            int rawDamage = target.PoisonDamage + Strength;
            int damageDealtRogue = rawDamage - target.Block;
            if (damageDealtRogue < 0)
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
            int dodgeAmount = rand.Next(20, 50);
            AddDodge(dodgeAmount);
            Console.WriteLine($"{Name} used Dodge gaining {dodgeAmount}% dodge chance for a total chance of {Dodge}%");
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) return;
            string selectedSkill = Skills[choice - 1];
            switch (selectedSkill)
            {
                case "Crit":
                    UseSkillCrit(target);
                    break;

                case "Poison Dagger":
                    UseSkillPoisonDagger(target);
                    break;

                case "Dodge":
                    UseSkillDodge(target);
                    break;
            }
        }

        public override void TakeTurn(GameCharacter target)
        {
            if ((double)target.Health / target.MaxHealth < 0.5)
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
