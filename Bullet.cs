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
        public bool isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed = 3;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("spr_bullet");
            Reset();
        }

        public void Reset()
        {
            velocity = Vector2.Zero;
            position = new Vector2(-texture.Width, -texture.Height);
        }

        public void Update()
        {

            Console.Write("\r{0}%   ", position);
            if (position.Y < -texture.Height)
            {
                isFired = false;
            }
            else
            {
                velocity = Vector2.Multiply(Vector2.UnitY, -speed);
                position += velocity;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {
            position = startPosition;
            isFired = true;
        }

    }
}
