using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    sealed class SpaceShip : Sprite
    {
        private float Friction = 0.08f;
        private Texture2D BulletPic;
        private Texture2D PicNoThrust;
        private Texture2D PicThrust;
        private float LastShootTime = 0;
        private List<Bullet> _shotBullets = new List<Bullet>();

        public List<Bullet> ShotBullets { get { return _shotBullets; } }

        public SpaceShip(Texture2D pic, Texture2D picNoThrust, Texture2D bulletPic)
            :base(pic){
            BulletPic = bulletPic;
            PicNoThrust = picNoThrust;
            PicThrust = pic;
            Pic = PicNoThrust;
        }

        public override void SpawnInMem()
        {
            Pos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            Rect = new Rectangle((int)Pos.X, (int)Pos.Y, Pic.Width, Pic.Height);
            Rotation = 0;
            Orgin = new Vector2(Pic.Width / 2, Pic.Height / 2);
            TangiVelocity = 0.2f;
        }

        public void Update(GameTime u_gameTime)
        {
            // Update input vars
            tang = Game1.tang;
            oldTang = Game1.oldTang;
            mus = Game1.mus;
            oldMus = Game1.oldMus;
            _gameTime = u_gameTime;

            // Run sprite methods
            PositionHitbox();
            Move();
            ExecuteWallWalking();
            TryShootBullet();
        }

        private void PositionHitbox()
        {
            Rect.X = (int)Pos.X;
            Rect.Y = (int)Pos.Y;
        }

        private void Move()
        {
            // Check rotation
            if (tang.IsKeyDown(Keys.D)) Rotation += 0.05f;
            if (tang.IsKeyDown(Keys.A)) Rotation -= 0.05f;

            // Move ship
            if (tang.IsKeyDown(Keys.W))
            {
                Speed.X += (float)Math.Cos(Rotation) * TangiVelocity;
                Speed.Y += (float)Math.Sin(Rotation) * TangiVelocity;

                Pic = PicThrust;
            }
            else if(Speed != Vector2.Zero)
            {
                Speed -= Friction * Speed;

                Pic = PicNoThrust;
            }
            Pos += Speed;            
        }

        private void TryShootBullet()
        {
            if (mus.LeftButton == ButtonState.Pressed)
            {
                float TimeBetweenShots = (float)_gameTime.TotalGameTime.TotalMilliseconds - LastShootTime;
                if (TimeBetweenShots > 0)
                {
                    LastShootTime = (float)_gameTime.TotalGameTime.TotalMilliseconds;
                    ShootBullet();
                }
            }

            void ShootBullet()
            {
                var newBullet = new Bullet(BulletPic, Pos, TangiVelocity, Rotation);
                _shotBullets.Add(newBullet);
            }
        }

        private void ExecuteWallWalking()
        {
            if (Rect.Y < -Pic.Height - 10) Pos.Y = _graphics.PreferredBackBufferHeight + Pic.Height + 5;
            if (Rect.Y > _graphics.PreferredBackBufferHeight + Pic.Height + 10) Pos.Y = -Pic.Height - 5;
            if (Rect.X < -Pic.Width - 10) Pos.X = _graphics.PreferredBackBufferWidth + Pic.Width + 5;
            if (Rect.X > _graphics.PreferredBackBufferWidth + Pic.Width + 10) Pos.X = -Pic.Width - 5;
        }

        public override void Draw()
        {
            foreach (var bullet in _shotBullets)
            {
                bullet.Draw();
            }
            foreach (var bullet in _shotBullets)
            {
                if (!bullet.BulletAlive)
                {
                    _shotBullets.Remove(bullet);
                    break;
                }
            }
            _spriteBatch.Draw(Pic, Pos, null, Color.White, Rotation, Orgin, 1f, SpriteEffects.None, 0f);
        }
    }
}
