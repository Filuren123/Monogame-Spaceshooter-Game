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

        public Enemy(Texture2D pic, Texture2D secondPic)
            :base(pic){
            FlyStates.Add(pic);
            FlyStates.Add(secondPic);
        }

        public override void SpawnInMem()
        {
            Rect = new Rectangle(Utility.slump.Next(0, _graphics.PreferredBackBufferWidth - 100), Utility.slump.Next(0, _graphics.PreferredBackBufferHeight - 100), Pic.Width / 10, Pic.Height / 10);
            Speed = new Vector2(Utility.RandomNumExept0(-4, 4), Utility.RandomNumExept0(-4, 4));
        }

        public void Update(GameTime gametime)
        {
            CheckCollision();
            Move();
        }

        public void Move()
        {
            Rect.X += (int)Speed.X;
            Rect.Y += (int)Speed.Y;
        }

        public void CheckCollision()
        {
            if (Rect.Left < 0 || Rect.Right > _graphics.PreferredBackBufferWidth)
            {
                Speed.X *= -1;
            }
            if (Rect.Top < 0 || Rect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                Speed.Y *= -1;
            }
        }
    }
}
