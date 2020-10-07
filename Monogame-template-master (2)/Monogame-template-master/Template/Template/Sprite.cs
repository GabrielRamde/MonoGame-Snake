using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Template
{
    class Sprite
    {
        private Texture2D _texture;
        private Vector2 position;
        private Input input;
        private float speed = 10f;

        public Vector2 Position { get { return position; } set { position = value; } } //gör så man kan använda private variablar
        public Input Input { get { return input; } set { input = value; } }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        private void Move()
        {
            if (input == null)
                return;
            //vad mina knappar ska göra
            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                position.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                position.X += speed;
            }
        }
    }
}