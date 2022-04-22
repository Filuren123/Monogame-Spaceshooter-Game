using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    class Enemy : Sprite
    {
        List<Texture2D> FlyStates = new List<Texture2D>();

        public Enemy(Texture2D pic, Texture2D secondPic, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
            :base(pic, spriteBatch, graphics){
            FlyStates.Add(pic);
            FlyStates.Add(secondPic);
        }

        public override void SpawnInMem()
        {
            Rect = new Rectangle(Game1.slump.Next(0, _graphics.PreferredBackBufferWidth - 100), Game1.slump.Next(0, _graphics.PreferredBackBufferHeight - 100), Pic.Width / 10, Pic.Height / 10);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
