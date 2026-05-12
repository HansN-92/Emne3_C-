using System.ComponentModel.Design;

namespace moodle2
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            DicePlayer player = new DicePlayer("Player", 0);
            DicePlayer computer = new DicePlayer("Computer", 0);

            int playerScore = player.Score;
            int computerScore = computer.Score;
            int roundNumber = 0;
            bool play = true;

            while (play)
            {
                int playerRoll = player.Roll();
                int computerRoll = computer.Roll();

                Console.WriteLine($"Player Roll: {playerRoll}");
                Console.WriteLine($"Computer Roll: {computerRoll}");

                if (playerRoll > computerRoll)
                {
                    playerScore += 1;
                    Console.WriteLine($"Player WINS! \nPlayer: {playerScore} \nComputer: {computerScore} \nRound: {roundNumber}");
                }
                else if (playerRoll < computerRoll)
                {
                    computerScore += 1;
                    Console.WriteLine($"Computer WINS! \nPlayer: {playerScore} \nComputer: {computerScore} \nRound: {roundNumber}");
                }

                else
                {
                    Console.WriteLine($"Draw! \nPlayer: {playerScore} \nComputer: {computerScore} \nRound: {roundNumber}");
                }

                if (playerScore == 3 || computerScore == 3)
                {
                    play = false;
                }

                Console.ReadLine();
                roundNumber += 1;
            }

            
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
