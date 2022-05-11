using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Spaceship_Game_Slutprojekt.Sprites;

namespace Spaceship_Game_Slutprojekt
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        private Color _backgroundColor = Color.Black;

        double TimeSinceLastEnemySpawn = 0;

        // Sprite Textures
        Texture2D spaceShipPic;
        Texture2D spaceShipPicNoThrust;

        Texture2D bulletPic;

        Texture2D MonsterPic1;
        Texture2D MonsterPic2;

        // Sprite Instances
        SpaceShip player1;
        List<Enemy> enemies = new List<Enemy>();

        // Fonts
        public static SpriteFont Font_Georgia;

        // Scene
        enum scenes
        {
            mainMenu = 1,
            inGame,
        }
        private int currentScene = (int)scenes.inGame;

        // Input vars
        public static KeyboardState tang;
        public static KeyboardState oldTang;
        public static MouseState mus;
        public static MouseState oldMus;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth *= 2;
            _graphics.PreferredBackBufferHeight *= 2;
            _graphics.ApplyChanges();
            
            tang = Keyboard.GetState();
            oldTang = tang;
            mus = Mouse.GetState();
            oldMus = mus;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spaceShipPic = Content.Load<Texture2D>("ship");
            spaceShipPicNoThrust = Content.Load<Texture2D>("ship_no_thrust");
            bulletPic = Content.Load<Texture2D>("bullet");
            MonsterPic1 = Content.Load<Texture2D>("monster_fly1");
            MonsterPic2 = Content.Load<Texture2D>("monster_fly2");
            Font_Georgia = Content.Load<SpriteFont>("system_fet");


            player1 = new SpaceShip(spaceShipPic, spaceShipPicNoThrust, bulletPic);
            player1.SpawnInMem();

            for (int i = 0; i < 15; i++)
            {
                SpawnEnemy();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update input
            tang = Keyboard.GetState();
            oldTang = tang;
            mus = Mouse.GetState();
            oldMus = mus;

            switch (currentScene)
            {
                case (int)scenes.inGame:
                    UpdateInGameScene(gameTime);
                    break;
                case (int)scenes.mainMenu:
                    UpdateMainMenu();
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            _spriteBatch.Begin();

            switch (currentScene)
            {
                case (int)scenes.inGame:
                    DrawInGameScene();
                    break;
                case (int)scenes.mainMenu:
                    DrawMainMenu();
                    break;
                default:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // All scence
        private void DrawInGameScene()
        {
            foreach (var enemy in enemies)
            {
                enemy.Draw();
            }

            player1.Draw();
        }

        private void UpdateInGameScene(GameTime gameTime)
        {
            player1.Update(gameTime);

            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime, player1);
                if (enemy.IsDead)
                {
                    enemies.Remove(enemy);
                    break;
                }
            }

            TimeSinceLastEnemySpawn += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Utility.slump.Next(1, 60) == 2)
            {
                SpawnEnemy();
                TimeSinceLastEnemySpawn = 0;
            }
        }

        private void SpawnEnemy()
        {
            var tempEnemy = new Enemy(MonsterPic1, MonsterPic2);
            tempEnemy.SpawnInMem();

            enemies.Add(tempEnemy);
        }

        private void DrawMainMenu()
        {

        }

        private void UpdateMainMenu()
        {

        }
    }
}
