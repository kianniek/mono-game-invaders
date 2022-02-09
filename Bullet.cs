using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed = 10;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("spr_bullet");
        }

        public void Reset()
        {
        }

        public void Update()
        {
            velocity = Vector2.Multiply(Vector2.UnitY, -speed);
            position += velocity;

            if (position.Y < 0) {
                Console.WriteLine("bullet went offscreen1");
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {  
            position = startPosition;
        }

    }
}
