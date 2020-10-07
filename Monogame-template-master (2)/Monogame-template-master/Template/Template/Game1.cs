using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int bredd;
        public static int hojd;

        private List<Sprite> _sprites;
        private float speed = 10f;

        private Texture2D background;
        private Vector2 backgroundpos = new Vector2(0, 0);

        private Texture2D _texture;
        private Texture2D _texturefood;
        private Texture2D _texturefood2;
        private Texture2D _texturefood3;
        private Vector2 _position;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //skärmstorlek på spelet
            hojd = graphics.PreferredBackBufferHeight = 720;
            bredd = graphics.PreferredBackBufferWidth = 1080;
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
            // TODO: Add your initialization logic here

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

            background = Content.Load<Texture2D>("backgroundpicture"); // Bakgrund till spelet
            _texture = Content.Load<Texture2D>("snakesquare");
            _texturefood = Content.Load<Texture2D>("+1apple");
            _texturefood2 = Content.Load<Texture2D>("-1apple");
            _texturefood3 = Content.Load<Texture2D>("deadmushroom");

            _sprites = new List<Sprite>()
            {
                new Sprite(_texture)
                {
                    Position = new Vector2(0, 300), //position
                    Input = new Input() //vilka knappar som är tillgängliga
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,
                    }
                },
            };
        }
                // TODO: use this.Content to load your game content here 

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(); //skriver ut hur stor min bakgrund ska vara och skärmen och hur den ska se ut
            Rectangle backgroundRec = new Rectangle();
            backgroundRec.Location = backgroundpos.ToPoint();
            backgroundRec.Size = new Point(bredd, hojd);
            spriteBatch.Draw(background, backgroundRec, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}
