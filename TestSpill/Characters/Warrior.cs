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
                UseSkill(target);
            }
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            ConsoleKeyInfo selectedSkill = Console.ReadKey(true);
            switch (selectedSkill.Key)
            {
                case ConsoleKey.D1:
                    SkillBlock(target);
                    break;

                case ConsoleKey.D2:
                    SkillStrongAttack(target);
                    break;

                case ConsoleKey.D3:
                    SkillShieldSlam(target);
                    break;
                default:
                    UseSkill(target);
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
