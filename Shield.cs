using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal class Shield
    {
        public Vector2 position;
        public Texture2D texture;
        public Shield()
        {
            texture = Global.content.Load<Texture2D>("spr_Shield");
            Reset();
        }

        public void Reset()
        {
            position = new Vector2(-texture.Width, -texture.Height);
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
