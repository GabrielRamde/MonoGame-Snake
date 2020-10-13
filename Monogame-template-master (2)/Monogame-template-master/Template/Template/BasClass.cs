using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class BasClass
    {
        protected Vector2 position_;
        protected Texture2D texture_;

        public virtual void Update()
        {
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

