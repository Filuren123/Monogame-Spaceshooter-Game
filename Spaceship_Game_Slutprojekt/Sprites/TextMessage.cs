using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spaceship_Game_Slutprojekt.Interfaces;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    class TextMessage : IDraw
    {
        private int _score = 0;
        private string _message;
        private Vector2 Pos;

        SpriteBatch _spriteBatch = Game1._spriteBatch;
        GraphicsDeviceManager _grapics = Game1._graphics;

        public void Draw()
        {
            _message = "Poäng: " + _score.ToString();
            _spriteBatch.DrawString()
        }
    }
}
