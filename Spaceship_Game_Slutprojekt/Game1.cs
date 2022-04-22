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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Globals
        public static Random slump = new Random();

        // Sprite
        Texture2D spaceShipPic;
        Texture2D spaceShipPicNoThrust;

        Texture2D bulletPic;

        Texture2D MonsterPic1;
        Texture2D MonsterPic2;

        // Sprite Instances
        SpaceShip ship;

        // Scene
        enum scenes
        {
            mainMenu = 1,
            inGame,
        }
        private int currentScene = (int)scenes.inGame;

        // Input vars
        KeyboardState tang;
        KeyboardState oldTang;
        MouseState mus;
        MouseState oldMus;

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

            ship = new SpaceShip(spaceShipPic, spaceShipPicNoThrust, _spriteBatch, _graphics, bulletPic);
            ship.SpawnInMem();
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

            ship.Update(tang, oldTang, mus, oldMus, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            switch (currentScene)
            {
                case (int)scenes.inGame:
                    DrawInGameScene();
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
            ship.Draw();
        }
    }
}
