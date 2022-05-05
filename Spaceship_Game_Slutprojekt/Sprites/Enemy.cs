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
        public bool IsDead = false;
        double LastFlap = 0;
        int FlapState = Utility.slump.Next(0, 2);
        int FlapInterval = Utility.slump.Next(200, 600);

        public Enemy(Texture2D pic, Texture2D secondPic)
            :base(pic){
            FlyStates.Add(pic);
            FlyStates.Add(secondPic);
        }

        public override void SpawnInMem()
        {
            Rect = new Rectangle(Utility.slump.Next(0, _graphics.PreferredBackBufferWidth - 100), Utility.slump.Next(0, _graphics.PreferredBackBufferHeight - 100), Pic.Width / 6, Pic.Height / 6);
            Speed = new Vector2(Utility.RandomNumExept0(-4, 4), Utility.RandomNumExept0(-4, 4));
        }

        public void Update(GameTime gameTime, SpaceShip player1)
        {
            _gameTime = gameTime;
            FlapWings();
            CheckIfDead(player1);
            CheckCollision();
            Move();
        }

        private void Move()
        {
            Rect.X += (int)Speed.X;
            Rect.Y += (int)Speed.Y;
        }

        private void FlapWings()
        {
            LastFlap += _gameTime.ElapsedGameTime.TotalMilliseconds;
            if (LastFlap >= FlapInterval)
            {
                FlapState++;
                if (FlapState == FlyStates.Count)
                {
                    FlapState = 0;
                }
                Pic = FlyStates[FlapState];
                LastFlap = 0;
            }
        }

        private void CheckIfDead(SpaceShip player1)
        {
            var bulletCol = player1.ShotBullets;
            foreach (var bullet in bulletCol)
            {
                if (Rect.Intersects(bullet.Hitbox))
                {
                    bulletCol.Remove(bullet);
                    IsDead = true;
                    player1.Points++;
                    break;
                }
            }
        }

        private void CheckCollision()
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
