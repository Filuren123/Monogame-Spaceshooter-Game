using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    abstract class Sprite
    {
        // Sprite props
        protected Texture2D Pic;
        protected Vector2 Pos;
        protected Rectangle Rect;
        protected Vector2 Speed;
        protected float TangiVelocity;
        protected float Rotation;
        protected Vector2 Orgin;

        // Sprite utility
        protected SpriteBatch _spriteBatch;
        protected GraphicsDeviceManager _graphics;
        protected GameTime _gameTime;

        // Input vars
        protected KeyboardState tang;
        protected KeyboardState oldTang;
        protected MouseState mus;
        protected MouseState oldMus;

        public Sprite(Texture2D pic)
        {
            Pic = pic;
            _spriteBatch = Game1._spriteBatch;
            _graphics = Game1._graphics;
        }

        public virtual void Draw()
        {
            _spriteBatch.Draw(Pic, Rect, Color.White);
        }

        public abstract void SpawnInMem();
    }
}
