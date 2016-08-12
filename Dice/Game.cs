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
        public int round;
        public int numOfPlayers;
        public int winningPointTotal;
        public List<Player> roster;
        public List<Dice> dice;

        public Game()
        {
            roster = new List<Player> { };
            dice = new List<Dice> { };
            gameOver = false;
            round = 0;
            numOfPlayers = 0;
            winningPointTotal = 0;

            Setup();
        }

        public void Setup()
        {
            IntroduceGame();

            InitializePlayers();

            AddComputerPlayer();

            VerifyPlayers();

            InitializeDice();

        }

        public void IntroduceGame()
        {
            Console.WriteLine("So you want to play this dice simulation game? You can play by yourself, against your friends or against the computer.");
            Console.WriteLine("The rules are simple: There are six dice, one each with four, six, eight, 10, 12 and 20 sides.");
            Console.WriteLine("During a player's turn, the six dice will be rolled. Add up the total number of points. The first player to reach a defined point total wins.");
            Console.WriteLine("If a player rolls a sequence of six straight numbers (i.e. 1-2-3-4-5-6), that player automatically wins.");
            Console.WriteLine("Good Luck!");
        }

        public void InitializePlayers()
        {
            Console.WriteLine("How many players for this game?");
            numOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many points will determine the winner?");
            winningPointTotal = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Enter a player name:");
                Player player = new Player(Console.ReadLine());
                roster.Add(player);

            }

        }

        public void AddComputerPlayer()
        {
            Console.WriteLine("Would you like to add the computer as a player? Y/N");

            if (Console.ReadLine().ToUpper() == "Y")
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
            while (!gameOver)
            {
                foreach (Player player in roster)
                {
                    if (!player.TakeTurn(dice))
                    {
                        gameOver = true;
                        break;
                    }
                    else
                    {
                        if (player.score >= this.winningPointTotal)
                        {
                            gameOver = true;
                            DetermineWinner();
                            break;
                        }
                    }                                
                }
            }
        }

        public void DetermineWinner()
        {
            int highestScore = 0;
            string winner;

            foreach (Player player in roster)
            {
                highestScore = Math.Max(highestScore, player.score);
            }
            winner = roster.Find(item => item.score == highestScore).name;
            Console.WriteLine("{0} wins!!!", winner);
        }


    }
}
