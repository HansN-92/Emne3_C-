namespace TestSpill.Characters
{
    internal class Warrior : GameCharacter
    {
        public Warrior(string name) : base(name)
        {
            MaxHealth = 180;
            Health = 180;
            Strength = 20;
            MaxStrength = 20;
            Skills = new List<string> { "Block", "Strong Attack", "Shield Slam" };
        }

        public void SkillBlock(GameCharacter target)
        {
            Random rand = new Random();
            int blockedDmg = rand.Next(20, 40);
            Block = blockedDmg;
            Console.WriteLine($"{Name} Gain {Block} Block");
        }

        public void SkillStrongAttack(GameCharacter target)
        {
            Random rand = new Random();
            if (target.TryDodge()) return;
            int damage = rand.Next(15, 35);
            int damageDealt = damage + Strength;
            target.Health -= damageDealt;
            Console.WriteLine($"{Name} HIT {target.Name} for {damageDealt} DMG");
        }

        public void SkillShieldSlam(GameCharacter target)
        {
            if (Block > 0)
            {
                if (target.TryDodge()) return;
                int slamDmg = Block * 2;
                int rawDamage = slamDmg + Strength;
                int slamDamageDealt = rawDamage - target.Block;
                if (slamDamageDealt < 0) slamDamageDealt = 0;
                target.Block -= rawDamage;
                if (target.Block < 0) target.Block = 0;
                target.Health -= slamDamageDealt;

                Console.WriteLine($"{Name} use Shield Slam for {slamDamageDealt} DMG");
            }
            else
            {
                Console.WriteLine($"{Name} has {Block} Block");
            }
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) return;
            string selectedSkill = Skills[choice - 1];
            switch (selectedSkill)
            {
                case "Block":
                    SkillBlock(target);
                    break;

                case "Strong Attack":
                    SkillStrongAttack(target);
                    break;

                case "Shield Slam":
                    SkillShieldSlam(target);
                    break;
            }
        }

        public override void TakeTurn(GameCharacter target)
        {
            if ((double)Health / MaxHealth < 0.5 && Block < 20)
            {
                SkillBlock(target);
            }
            else if (Block > 50)
            {
                SkillShieldSlam(target);
            }
            else
                SkillStrongAttack(target);
        }
    }
}
