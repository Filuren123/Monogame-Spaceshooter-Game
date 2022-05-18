using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spaceship_Game_Slutprojekt.Sprites;

namespace Spaceship_Game_Slutprojekt
{
    class Menu
    {
        private Texture2D StartButton;
        private Rectangle StartButtonRect;

        public Menu(Texture2D startButton)
        {
            StartButton = startButton;
            StartButtonRect = new Rectangle(Game1._graphics.PreferredBackBufferWidth / 2 - StartButton.Width / 4, Game1._graphics.PreferredBackBufferHeight / 2 - StartButton.Height / 4, StartButton.Width / 2, StartButton.Height / 2);
        }

        private TextMessage Header = new TextMessage()
        {
            MessagePrefix = "The Space Shooter Game"
        };

        public void Update()
        {
            Header.PosisionHeader();
            if (Game1.mus.LeftButton == ButtonState.Pressed && Game1.oldMus.LeftButton == ButtonState.Released)
            {
                Game1.currentScene = (int)Game1.scenes.inGame;
            }
        }

        public void Draw()
        {
            Game1._spriteBatch.DrawString(Game1.Font_Georgia_49, Header.MessagePrefix, Header.Pos, Color.White);
            Game1._spriteBatch.Draw(StartButton, StartButtonRect, Color.White);
        }
    }
}
