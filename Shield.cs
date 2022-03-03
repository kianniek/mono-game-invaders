using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal class Shield : GameObject
    {
        public Shield()
        {
            texture = Global.content.Load<Texture2D>("spr_Shield");
            Reset();
        }

        public override void Reset()
        {
            position = new Vector2(-texture.Width, -texture.Height);
        }
    }
}
