using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class Game
    {
        public bool gameOver;
        public int round;
        public int numOfPlayers;
        public int winningPointTotal;
        public List<string> roster;

        public Game()
        {
            roster = new List<string> { };
            gameOver = false;
            round = 0;
            numOfPlayers = 0;
            winningPointTotal = 0;

            Setup();
        }

        public void Run()
        {
                    }

        public void Setup()
        {
            Console.WriteLine("So you want to play this dice simulation game? You can play by yourself, against your friends or against the computer.");
            Console.WriteLine("The rules are simple: There are six dice, one each with four, six, eight, 10, 12 and 20 sides.");
            Console.WriteLine("During a player's turn, the six dice will be rolled. Add up the total number of points. The first player to reach a defined point total wins.");
            Console.WriteLine("If a player rolls a sequence of six straight numbers (i.e. 1-2-3-4-5-6), that player automatically wins.");
            Console.WriteLine("Good Luck!");

            Console.WriteLine("How many players for this game?");
            numOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many points will determine the winner?");
            winningPointTotal = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Enter a player name:");
                roster.Add(Console.ReadLine());
            }

            Console.WriteLine("Would you like to add the computer as a player? Y/N");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                roster.Add("Computer");
            }
            else
            {
                Console.WriteLine("The computer will not play this time.");
            }
        }



    }
}
