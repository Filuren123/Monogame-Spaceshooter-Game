using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship_Game_Slutprojekt.Sprites
{
    class Bullet
    {
        // Sprite props
        private Texture2D Pic;
        private Vector2 Pos;
        private Rectangle Rect;
        private Vector2 Speed;
        private float TangiVelo;
        private float Rotation;
        private Vector2 Origin;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;
        public bool BulletAlive = true;

        public Bullet(Texture2D pic, Vector2 pos, float tangiVelo, float rotation)
        {
            Pic = pic;
            Pos = pos;
            TangiVelo = tangiVelo + 30;
            Rotation = rotation;
            _spriteBatch = Game1._spriteBatch;
            _graphics = Game1._graphics;
            ShootBullet(Pos, Speed, Rotation);

            // Build speed
            Speed.X += (float)Math.Cos(Rotation) * TangiVelo;
            Speed.Y += (float)Math.Sin(Rotation) * TangiVelo;
        }

        public void ShootBullet(Vector2 pos, Vector2 speed, float rot)
        {
            Rect = new Rectangle((int) Pos.X, (int) Pos.Y, 100, 100);
            Origin.X = Pic.Width / 2;
            Origin.Y = Pic.Height / 2;
        }

        public void Draw()
        {
            Update();
            _spriteBatch.Draw(Pic, Pos, null, Color.White, Rotation, Origin, 1f, SpriteEffects.None, 0f);
        }

        private void Update()
        {
            UpdateOrigin();
            CheckIfDead();
            Pos += Speed;
            Rect.X = (int)Pos.X;
            Rect.Y = (int)Pos.Y;
        }

        private void CheckIfDead()
        {
            if (Pos.X < 0 || Pos.X > _graphics.PreferredBackBufferWidth || Pos.Y < 0 || Pos.Y > _graphics.PreferredBackBufferHeight)
            {
                BulletAlive = false;
            }
        }

        private void UpdateOrigin()
        {
            Origin.X = Pic.Width / 2;
            Origin.Y = Pic.Height / 2;
        }
    }
}
