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

        public void TakeTurn()
        {
            //roll dice

            //Random diceValue = new Random();
            //this.score += [diceValue.Next(4)];
            
            //update score
            //check for 6-number sequence

        }
    }
}
