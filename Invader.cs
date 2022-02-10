using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class Invader
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public Texture2D[] textureColors;

        public Invader()
        {
            textureColors = new Texture2D[4];
            textureColors[0] = Global.content.Load<Texture2D>("spr_red_invader");
            textureColors[1] = Global.content.Load<Texture2D>("spr_green_invader");
            textureColors[2] = Global.content.Load<Texture2D>("spr_blue_invader");
            textureColors[3] = Global.content.Load<Texture2D>("spr_yellow_invader");
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            float collectiveHeight = 

            velocity.X = 3.0f;
            velocity.Y = collectiveHeight;
        }

        public bool Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
            return true;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
