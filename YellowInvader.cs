using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal class YellowInvader : Invader
    {
        public YellowInvader() : base("spr_yellow_invader")
        {
        }
        public override bool Update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }
            return true;
        }
    }
}
