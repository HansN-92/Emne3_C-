
namespace moodle2
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

            DicePlayer player = new DicePlayer(inputName, 0);
            DicePlayer computer = new DicePlayer("Computer", 0);

            int playerScore = player.Score;
            string playerName = player.Navn;
            int computerScore = computer.Score;
            string computerName = computer.Navn;
            int roundNumber = 0;
            bool play = true;

            while (play)
            {
                roundNumber += 1;
                int playerRoll = player.Roll();
                int computerRoll = computer.Roll();

                Console.WriteLine($"{playerName} Roll: {playerRoll}");
                Console.WriteLine($"{computerName} Roll: {computerRoll}");

                if (playerRoll > computerRoll)
                {
                    playerScore += 1;
                    Console.WriteLine($"{playerName} WINS! \n{playerName} Score: {playerScore} \n{computerName} Score: {computerScore} \nRound: {roundNumber}");
                }
                else if (playerRoll < computerRoll)
                {
                    computerScore += 1;
                    Console.WriteLine($"{computerName} WINS! \n{playerName} Score: {playerScore} \n{computerName} Score: {computerScore} \nRound: {roundNumber}");
                }

                else
                {
                    Console.WriteLine($"Draw! \n{playerName} Score: {playerScore} \n{computerName} Score: {computerScore} \nRound: {roundNumber}");
                }

                if (playerScore == 3 || computerScore == 3)
                {
                    play = false;
                }

                Console.ReadLine();
                
            }
            if (playerScore > computerScore)
                Console.WriteLine($"{playerName} Wins {playerScore}-{computerScore}!");
            else
                Console.WriteLine($"{computerName} Wins {computerScore}-{playerScore}!");


        }
        
    }
    internal class DicePlayer
    {
        public string Navn { get; set; }
        public int Score { get; set; }

        public DicePlayer(string navn, int score)
        {
            Navn = navn;
            Score = score;
        }

        public int Roll()
        {
            Random dice = new Random();
            return dice.Next(1, 7);
        }
    }


}
