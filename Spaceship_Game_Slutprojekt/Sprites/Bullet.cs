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
        private Vector2 Speed;
        private float TangiVelo;
        private float Rotation;
        private Vector2 Origin;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;
        public bool BulletAlive = true;
        private Rectangle _hitbox;

        public Rectangle Hitbox { get { return _hitbox; } }

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
            _hitbox = new Rectangle((int) Pos.X, (int) Pos.Y, Pic.Width, Pic.Height);
            Origin.X = Pic.Width / 2;
            Origin.Y = Pic.Height / 2;
        }

        public void Draw()
        {
            Update();
            _spriteBatch.Draw(Pic, Pos, null, Color.White, Rotation, Origin, 1f, SpriteEffects.None, 0f);
        }

        private void PosisionHitbox()
        {
            _hitbox.X = (int)Pos.X;
            _hitbox.Y = (int)Pos.Y;
        }

        private void Update()
        {
            UpdateOrigin();
            CheckIfDead();
            PosisionHitbox();
            Pos += Speed;
        }

        private void CheckIfDead()
        {
            if (Pos.X < -40 || Pos.X > _graphics.PreferredBackBufferWidth + 40 || Pos.Y < -40 || Pos.Y > _graphics.PreferredBackBufferHeight + 40)
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
