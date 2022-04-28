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
            var slumpen = 0;
            while (slumpen == 0)
            {
                slumpen = slump.Next(upperLimit, lowerLimit);
            }
            return slumpen;
        }
    }
}
