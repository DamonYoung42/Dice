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

        public bool TakeTurn(List<Dice> dice)
        {
            List<int> diceResult = new List<int> { };

            diceResult = RollDice(dice);

            if (IsSequence(diceResult))
            {
                Console.WriteLine("{0} rolled a six-number sequence -- {1} -- to automatically win!", this.name, this.getRolledDice(diceResult));

                return false;
            }

            this.score += diceResult.Sum();
            Console.WriteLine("{0} rolled {1} for {2} points in this round for a game score of {3}", this.name, getRolledDice(diceResult), diceResult.Sum(), this.score);
            //Console.WriteLine("Press any key to take next player's turn.");
            //Console.ReadKey();
            return true;

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

        public bool IsSequence(List<int> rolledDice)
        {
            rolledDice.Sort();

            var rangeSequence = Enumerable.Range(rolledDice.Min(), rolledDice.Max() - rolledDice.Min() + 1);
            return rolledDice.SequenceEqual(rangeSequence);
        }


    }
}
