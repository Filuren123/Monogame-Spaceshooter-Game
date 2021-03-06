using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    class TextMessage
    {
        private int _score = 0;
        private string _messagePrefix;
        private string _message;
        public Vector2 Pos;

        public int Score { get { return _score; } set { _score = value; } }
        public string MessagePrefix { get { return _messagePrefix; } set { _messagePrefix = value; } }

        SpriteBatch _spriteBatch = Game1._spriteBatch;
        GraphicsDeviceManager _grapics = Game1._graphics;

        public void DrawScore()
        {
            _message = _messagePrefix + _score.ToString();
            _spriteBatch.DrawString(Game1.Font_Georgia, _message, Pos, Color.White);
        }

        public void DrawMessage()
        {
            _spriteBatch.DrawString(Game1.Font_Georgia, _messagePrefix, Pos, Color.White);
        }

        public void PosisionHeader()
        {
            Pos = new Vector2(Game1._graphics.PreferredBackBufferWidth / 2 - Game1.Font_Georgia_49.MeasureString(MessagePrefix).X / 2, 200);
        }
    }
}
