using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    private Input keyinput;
    class Snake : Sprite
    {
        public Snake(Texture2D texture, Vector2 position, Direction direction) : base(texture, position, direction)
        {

        }
        private void InputKeyboard()
        {
            //vad mina knappar ska göra
            if (Keyboard.GetState().IsKeyDown(input.Up))
                if (direction != Direction.Down)
                    Direction = Direction.Up;
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
