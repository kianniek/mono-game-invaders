using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders
{
    class Bullet : GameObject
    {
        public bool isFired = false;
        public float speed = 3;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("spr_bullet");
            Reset();
        }

        public override void Reset()
        {
            velocity = Vector2.Zero;
            position = new Vector2(-texture.Width, -texture.Height);
        }

        public override bool Update()
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
            return true;
        }


        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                position = startPosition;
                isFired = true;
            }
        }

    }
}
