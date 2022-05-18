using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spaceship_Game_Slutprojekt.Sprites;

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

        public static bool LeftMouseClicked()
        {
            if (Game1.mus.LeftButton == ButtonState.Pressed && Game1.oldMus.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
