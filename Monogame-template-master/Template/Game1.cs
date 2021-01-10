using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle screen;
        Random rnd;
        Fruit fruit;
        Snake head, tail;
        List<Snake> snake;

        int screenWidth = 1280;
        int screenHeight = 720;
        public static int SnakeSize = 20;

        float timer = 0;
        float delay = 200;

        bool isGameOver = false;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //skärmstorlek på spelet
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            screen = new Rectangle(0, 0, screenWidth, screenHeight);
            rnd = new Random();
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


            fruit = new Fruit(Content.Load<Texture2D>("+1apple"), new Vector2(rnd.Next(0,
                (screenWidth / SnakeSize) * SnakeSize), rnd.Next(0, 
                (screenHeight / SnakeSize) * SnakeSize)), Direction.None, screen);

            snake = new List<Snake>();

            head = new Snake(Content.Load<Texture2D>("snakesquare"), new Vector2(rnd.Next(0,
                (screenWidth / SnakeSize) * SnakeSize), rnd.Next(0,
                (screenHeight / SnakeSize) * SnakeSize)), Direction.Right, screen);

            snake.Add(head);
            
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

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(isGameOver == false)
            {
                if (timer > delay)
                {
                    timer = 0;

                    foreach (Snake s in snake)
                    {
                        s.Update(gameTime);
                    }

                    for (int i = snake.Count - 1; i > 0; i--)
                    {
                        snake[i].Direction = snake[i - 1].Direction;
                    }

                    snake[0].InputKeyboard();

                    if (snake[0].SpriteBox.Intersects(fruit.SpriteBox))
                    {
                        fruit.Position = new Vector2(rnd.Next(0,
                            (screenWidth / SnakeSize) * SnakeSize), rnd.Next(0,
                            (screenHeight / SnakeSize) * SnakeSize));

                        Snake tail = new Snake(Content.Load<Texture2D>("snakesquare"),
                            new Vector2(snake[snake.Count - 1].Position.X,
                            snake[snake.Count - 1].Position.Y), snake[snake.Count - 1].Direction, screen);

                        switch (snake[snake.Count - 1].Direction)
                        {
                            case Direction.Up:
                                tail.Position = new Vector2(tail.Position.X, tail.Position.Y + SnakeSize);
                                break;
                            case Direction.Down:
                                tail.Position = new Vector2(tail.Position.X, tail.Position.Y - SnakeSize);
                                break;
                            case Direction.Left:
                                tail.Position = new Vector2(tail.Position.X + SnakeSize, tail.Position.Y);
                                break;
                            case Direction.Right:
                                tail.Position = new Vector2(tail.Position.X - SnakeSize, tail.Position.Y);
                                break;
                            case Direction.None:
                                break;
                        }

                        snake.Add(tail);
                    }

                    for(int i = 1; i < snake.Count-1; i++)
                    {
                        if (snake[0].SpriteBox.Intersects(snake[i].SpriteBox))
                            isGameOver = true;
                    }
                }

                if (isGameOver)
                    Exit();

            }
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

            fruit.Draw(spriteBatch);

            foreach (Snake s in snake)
            {
                s.Draw(spriteBatch);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}
