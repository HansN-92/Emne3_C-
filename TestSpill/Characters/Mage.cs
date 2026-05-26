namespace TestSpill.Characters
{
    internal class Mage : GameCharacter
    {
        public Mage(string name) : base(name)
        {
            MaxHealth = 70;
            Health = 70;
            Strength = 25;
            MaxStrength = 25;
            Skills = new List<string> { "Fireball", "Magic Missile", "Weaken" };
        }

        public void UseSkillFireball(GameCharacter target)
        {
            Random rand = new Random();
            if (target.TryDodge()) return;
            int damage = rand.Next(15, 30);
            int rawDamage = damage + Strength;
            int damageDealt = rawDamage - target.Block / 2;
            if (damageDealt < 0) damageDealt = 0;
            target.Block -= rawDamage * 2;
            if (target.Block < 0) target.Block = 0;
            target.Health -= damageDealt;
            Console.WriteLine($"{Name} cast Fireball for {damageDealt}");
        }
        public void UseSkillMagicMissile(GameCharacter target)
        {
            Random rand = new Random();
            int missiles = rand.Next(2, 5);
            int missileDmg = Strength / 3;
            target.Health -= missiles * missileDmg;
            Console.WriteLine($"{Name} cast Magic Missile and HIT {missiles} for {missileDmg} each");
        }
        public void UseSkillWeaken(GameCharacter target)
        {
            if (target.Strength == target.MaxStrength)
            {
                target.Strength -= target.MaxStrength /4;
                Console.WriteLine($"{Name} cast Weaken on {target.Name} reducing Str to {target.Strength}");
            }
            else
                UseSkill(target);
        }

        public override void UseSkill(GameCharacter target)
        {
            ShowSkillMenu();
            ConsoleKeyInfo selectedSkill = Console.ReadKey(true);
            switch (selectedSkill.Key)
            {
                case ConsoleKey.D1:
                    UseSkillFireball(target);
                    break;

                case ConsoleKey.D2:
                    UseSkillMagicMissile(target);
                    break;

                case ConsoleKey.D3:
                    UseSkillWeaken(target);
                    break;
                default:
                    UseSkill(target);
                    break;
            }
        }

        public override void TakeTurn(GameCharacter target)
        {
            if (target.Block > 50)
            {
                UseSkillMagicMissile(target);
            }
            else if (target.Strength > 50)
            {
                UseSkillWeaken(target);
            }
            else
                UseSkillFireball(target);
        }
    }
}
