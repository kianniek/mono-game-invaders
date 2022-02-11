using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    internal class MotherShip : GameObject
    {
        public int health = 2;
        public bool isDefeated;

        public MotherShip()
        {
            texture = Global.content.Load<Texture2D>("spr_enemy_ship");
            Reset();
        }

        public override void Reset()
        {
            position.X = Global.width / 2; // horizontal center on screen
            position.Y = texture.Height; // bottom of screen
            velocity.X = -1;
        }

        public override bool Update()
        {
            //if health is equal to zero
            if (health <= 0)
            {
                isDefeated = true;
            }

            position += velocity;
            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }


            // "clamp" the x-position to make sure it never goes out of screen bounds           
            position.X = MathHelper.Clamp(position.X, 0, Global.width - texture.Width);
            return true;
        }
    }
}
