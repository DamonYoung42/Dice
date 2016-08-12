using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Player
    {
        public string name;
        public int score;

        public Player(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public void TakeTurn(List<Dice> dice)
        {
            List<int> diceResult = new List<int> { };
            //roll dice
            diceResult = RollDice(dice);

            int turnScore = diceResult.Sum(); //set player's turn score
            this.score += turnScore; //add turnscore to player's total score
            Console.WriteLine("{0} rolled {1} for {2} points in this round for a game score of {3}", this.name, getRolledDice(diceResult), turnScore, this.score);
            Console.WriteLine("Hit any key for next player's turn.");
            Console.ReadKey();
            //check for 6-number sequence
        }

        public List<int> RollDice(List<Dice> rolledDice)
        {
            List<int> rollresult = new List<int> { };
            Random diceValue = new Random(DateTime.Now.Millisecond);

            foreach (Dice item in rolledDice)
            {
                rollresult.Add(diceValue.Next(1, item.name + 1));   
            }
            return rollresult;
        }

        public string getRolledDice(List<int> result)
        {
            return string.Join("+", result);
        }

    }
}
