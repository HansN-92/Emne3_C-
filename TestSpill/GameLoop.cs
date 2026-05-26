using TestSpill.Characters;
namespace TestSpill
{
    internal class GameLoop
    {
        public static void Run()
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
            GameCharacter player;
            GameCharacter computer;

            PlayerClassChoice();
            void PlayerClassChoice()
            {
                Console.WriteLine(
                    $"Select Class: \n1 = Warrior \n HP: {tempWarrior.Health} Str: {tempWarrior.Strength} \n  Skills: {string.Join(", ", tempWarrior.Skills)}" +
                    $"\n2 = Mage \n HP: {tempMage.Health} Str: {tempMage.Strength} \n  Skills: {string.Join(", ", tempMage.Skills)}" +
                    $"\n3 = Rogue \n HP: {tempRogue.Health} Str: {tempRogue.Strength} \n  Skills: {string.Join(", ", tempRogue.Skills)}");

                ConsoleKeyInfo classChoice = Console.ReadKey(true);

                switch (classChoice.Key)
                {
                    case ConsoleKey.D1:
                        player = new Warrior(inputName);
                        break;

                    case ConsoleKey.D2:
                        player = new Mage(inputName);
                        break;

                    case ConsoleKey.D3:
                        player = new Rogue(inputName);
                        break;
                    default:
                        PlayerClassChoice();
                        break;
                }
            }

            Console.WriteLine($"\n{player.Name} Selected Class {player.GetType().Name}");
            ComputerClassChoice();

            void ComputerClassChoice()
            {
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

                Console.WriteLine($"{computer.Name} Selected Class {computer.GetType().Name}");

                Console.WriteLine(
                    $"{player.Name} HP: {player.Health} Str: {player.Strength} Block:{player.Block}\n{computer.Name} HP: {computer.Health} Str: {computer.Strength} Block:{computer.Block}");
                Console.ReadLine();
                Console.Clear();
            }

            while (fightActive)
            {
                roundNumber += 1;
                player.TickPoison();
                computer.TickPoison();

                if (computer.Health <= 0)
                {
                    Console.WriteLine($"\n{player.Name} WIN");
                    fightActive = false;
                    break;
                }


                if (player.Health <= 0)
                {
                    Console.WriteLine($"\n{computer.Name} WIN");
                    fightActive = false;
                    break;
                }

                PlayerTurn();
                void PlayerTurn()
                {
                    Console.WriteLine($"Round: {roundNumber}");
                    Console.WriteLine("1 = Attack \n2 = Skill \n3 = Heal");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    switch (choice.Key)
                    {
                        case ConsoleKey.D1:
                            player.Attack(computer);
                            break;

                        case ConsoleKey.D2:
                            player.UseSkill(computer);
                            break;

                        case ConsoleKey.D3:
                            player.SkillHeal(player);
                            break;
                        default:
                            PlayerTurn();
                            break;
                    }
                }

                if (computer.Health <= 0)
                {
                    Console.WriteLine($"\n{player.Name} WIN");
                    fightActive = false;
                    break;
                }

                Console.WriteLine();
                // Console.ReadLine();

                computer.TakeTurn(player);

                if (player.Health <= 0)
                {
                    Console.WriteLine($"\n{computer.Name} WIN");
                    fightActive = false;
                    break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
