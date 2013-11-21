using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using xTile;
using xTile.Display;
using xTile.Tiles;

namespace PizzaGuy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        PizzaGuy pizzaguy;
        Ghost ghost;
        public Texture2D Spritesheet;
        Map map;
        IDisplayDevice xnaDisplayDevice;
        xTile.Dimensions.Rectangle viewport;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            IsMouseVisible = true;
            
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            xnaDisplayDevice = new xTile.Display.XnaDisplayDevice(Content, GraphicsDevice);
            viewport = new xTile.Dimensions.Rectangle(new xTile.Dimensions.Size(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Spritesheet = Content.Load<Texture2D>(@"SpriteSheet");
            
            map = Content.Load<Map>("Map1");
            map.LoadTileSheets(xnaDisplayDevice);



            pizzaguy = new PizzaGuy(new Vector2(32, 32), Spritesheet, new Rectangle(300, 300, 32, 32), Vector2.Zero, map.GetLayer("untitled layer"));
            ghost = new Ghost(new Vector2(32, 32*10), Spritesheet, new Rectangle(300, 300, 32, 32), Vector2.Zero, map.GetLayer("untitled layer"), pizzaguy);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MouseState ms = Mouse.GetState();
            int index = map.TileSheets[0].GetTileIndex(new xTile.Dimensions.Location(ms.X, ms.Y));
            Tile tile = map.GetLayer("untitled layer").Tiles[1, 1];

            Window.Title = index.ToString();

            // TODO: Add your update logic here
            pizzaguy.Update(gameTime);
            ghost.Update(gameTime);

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            map.Draw(xnaDisplayDevice, viewport);

            // TODO: Add your drawing code here
            //spriteBatch.Begin();
            //spriteBatch.Draw(background, mainFrame, Color.Wheat);
            //spriteBatch.End()
            spriteBatch.Begin();
            pizzaguy.Draw(spriteBatch);
            ghost.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}