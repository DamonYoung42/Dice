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

        public List<int> TakeTurn(List<Dice> dice)
        {
            List<int> diceResult = new List<int> { };
            diceResult = RollDice(dice);

            this.score += diceResult.Sum();
            return diceResult;

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

    }
}
