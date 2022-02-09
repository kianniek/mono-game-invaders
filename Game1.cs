using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Bullet theBullet;
        MotherShip motherShip;
        private int nShields = 4;
        Shield[] shields;
        List<Invader> invaders = new List<Invader>();
        private int nInvaders = 16;

        //TODO: Add multiple invaders here

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();
            motherShip = new MotherShip();

            shields = new Shield[nShields];

            //add objects to list
            for (int iInvader = 0; iInvader < nInvaders; iInvader++)
            {
                Invader newInvader = new Invader();
                invaders.Add(newInvader);
            }
            for (int iShield = 0; iShield < nShields; iShield++)
            {
                shields[iShield] = new Shield();

                shields[iShield].position = new Vector2(((Global.width/nShields) * (iShield)) + shields[iShield].texture.Width, Global.height - shields[iShield].texture.Height * 2);
            }

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("spr_background");
            scanlines = Content.Load<Texture2D>("spr_scanlines");
            base.Initialize();
        }

        // Generic AABB collision detection using images as input
        bool overlaps(float x0, float y0, Texture2D texture0, float x1, float y1, Texture2D texture1)
        {
            int w0 = texture0.Width,
              h0 = texture0.Height,
              w1 = texture1.Width,
              h1 = texture1.Height;

            if (x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space) && !theBullet.isFired) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();
            motherShip.Update();
            for (int iInvader = 0; iInvader < invaders.Count; iInvader++)
            {
                Invader anInvader = invaders.ElementAt(iInvader);
                anInvader.Update();
            }

            // handling collision detection
            foreach (Invader anInvader in invaders)
            {
                if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, anInvader.position.X, anInvader.position.Y, anInvader.texture))
                {
                    theBullet.Reset();
                    anInvader.Reset();
                }
            }

            foreach (Shield anShield in shields)
            {
                if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, anShield.position.X, anShield.position.Y, anShield.texture))
                {
                    theBullet.Reset();
                    anShield.Reset();
                }
            }

            if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, motherShip.position.X, motherShip.position.Y, motherShip.texture))
            {
                motherShip.health--; 
                theBullet.Reset();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            theBullet.Draw();
            thePlayer.Draw();
            if (!motherShip.isDefeated)
            {
                motherShip.Draw();
            }

            for (int iInvader = 0; iInvader < invaders.Count; iInvader++)
            {
                invaders.ElementAt(iInvader).Draw();
            }
            for (int ishield = 0; ishield < shields.Length; ishield++)
            {
                shields[ishield].Draw();
            }

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
