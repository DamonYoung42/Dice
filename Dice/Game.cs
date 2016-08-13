using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Game
    {
        public bool gameOver;
        public bool playerRolledSequence;
        public int round;
        public int numOfPlayers;
        public int maxScore;
        public List<Player> roster;
        public List<Dice> dice;

        public Game()
        {
            roster = new List<Player> { };
            dice = new List<Dice> { };
            gameOver = false;
            playerRolledSequence = false;
            round = 0;
            numOfPlayers = 0;
            maxScore = 0;

        }

        public void SetupGame()
        {
            IntroduceGame();

            InitializePlayers();

            if (numOfPlayers != 1)
            {
                AddComputerPlayer();
            }

            VerifyPlayers();

            InitializeDice();

            Console.WriteLine("Press any key to begin:");
            Console.ReadKey();

        }

        public void IntroduceGame()
        {
            Console.WriteLine("So you want to play this dice game? You can play against your friends or the computer.");
            Console.WriteLine("The rules are simple: There are six dice, one each with four, six, eight, 10, 12 and 20 sides.");
            Console.WriteLine("During a player's turn, the six dice will be rolled. Add up the total number of points. The first player to reach a defined point total wins.");
            Console.WriteLine("If a player rolls a sequence of six straight numbers (i.e. 1-2-3-4-5-6), that player automatically wins.");
            Console.WriteLine("Good Luck!");
        }

        public void InitializePlayers()
        {
            Console.WriteLine("How many players for this game?");

            while (!Int32.TryParse(Console.ReadLine(), out numOfPlayers) || numOfPlayers < 1)
            {
                Console.WriteLine("Please enter a number greater than 0:");
            }

            Console.WriteLine("How many points will determine the winner? (50-1,000)");
            while (!Int32.TryParse(Console.ReadLine(), out maxScore) || (maxScore <= 49 || maxScore > 1000))
            {
                Console.WriteLine("Please enter a number between 50 and 1,000:");
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Enter a player name:");
                string input = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid player name:");
                    input = Console.ReadLine();
                }
                Player player = new Player(input);
                roster.Add(player);

            }

            if (numOfPlayers == 1)
            {
                Player computer = new Player("Computer");
                roster.Add(computer);
            }

        }

        public void AddComputerPlayer()
        {
            string input;

            do
            {
                Console.WriteLine("Would you like to add the computer as a player? Y/N");
                input = Console.ReadLine().ToUpper();
            }
            while (input != "Y" && input != "N");

            if (input == "Y")
            {
                Player computer = new Player("Computer");
                roster.Add(computer);
            }
            else
            {
                Console.WriteLine("The computer will not play this time.");
            }
        }

        public void VerifyPlayers()
        {
            Console.WriteLine("OK, here's the lineup:");
            foreach (Player player in roster)
            {
                {
                    Console.WriteLine(player.name);
                }
            }
        }

        public void InitializeDice()
        {
            Dice fourSided = new Dice(4);
            Dice sixSided = new Dice(6);
            Dice eightSided = new Dice(8);
            Dice tenSided = new Dice(10);
            Dice twelveSided = new Dice(12);
            Dice twentySided = new Dice(20);

            dice.Add(fourSided);
            dice.Add(sixSided);
            dice.Add(eightSided);
            dice.Add(tenSided);
            dice.Add(twelveSided);
            dice.Add(twentySided);
        }

        public void PlayGame()
        {
            List<int> turnResult;

            SetupGame();

            while (!gameOver)
            {
                foreach (Player player in roster)
                {
                    turnResult = player.TakeTurn(dice);
                    Console.WriteLine("{0} rolled {1} for {2} points in this round for a game score of {3}", player.name, getRolledDice(turnResult), turnResult.Sum(), player.score);
                    if (IsSequence(turnResult))
                    {
                        Console.WriteLine("{0} rolled a six-number sequence -- {1} -- to automatically win!", player.name, getRolledDice(turnResult));
                        Console.WriteLine("Thanks for playing. Goodbye.");
                        gameOver = true;
                        playerRolledSequence = true;
                        break;
                    }

                    if (player.score > maxScore)
                    {
                        gameOver = true;
                        //break;
                    }

                    if ((!gameOver) || ((gameOver) && (roster.IndexOf(player) != (roster.Count-1))))
                    {
                        Console.WriteLine("Press any key to take next player's turn.");
                        Console.ReadKey();
                    }

                }
                if (gameOver && !playerRolledSequence)
                {
                    DetermineWinner();
                }

            }

        }

        public string getRolledDice(List<int> result)
        {
            return string.Join("+", result);
        }

        public void DetermineWinner()
        {
            int highestScore = 0;
            List<Player> winner = new List<Player> { };
            string winnerName;

            foreach (Player player in roster)
            {
                highestScore = Math.Max(highestScore, player.score);
            }

            winner = roster.FindAll(item => item.score == highestScore);
            if (winner.Count > 1)
            {
                Console.WriteLine("{0} players are tied ... Press any key to continue playing:", winner.Count);
                Console.ReadKey();
                gameOver = false;
                roster.RemoveAll(item => item.score != highestScore);
            }
            else
            {
                winnerName = roster.Find(item => item.score == highestScore).name;
                Console.WriteLine("{0} wins!!!", winnerName);
            }



        }

        public bool IsSequence(List<int> rolledDice)
        {
            rolledDice.Sort();

            var rangeSequence = Enumerable.Range(rolledDice.Min(), rolledDice.Max() - rolledDice.Min() + 1);
            return rolledDice.SequenceEqual(rangeSequence);
        }
    }
}
