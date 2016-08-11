using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Dice
    {
        public int name;
        public int[] sides;

        public Dice(int numOfSides)
        {
            name = numOfSides;
            sides = new int[numOfSides];
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i] = i + 1;
            }
        }
    }
}
