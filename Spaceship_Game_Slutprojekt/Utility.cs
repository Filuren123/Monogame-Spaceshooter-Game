using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceship_Game_Slutprojekt
{
    sealed class Utility
    {
        public static Random slump = new Random();

        public static int RandomNumExept0(int upperLimit, int lowerLimit)
        {
            return slump.Next(upperLimit, lowerLimit);
        }
    }
}
