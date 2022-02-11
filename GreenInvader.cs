using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal class GreenInvader : Invader
    {
        public GreenInvader() : base("spr_green_invader")
        {

        }
        public override void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            velocity.X = 3.0f;
            velocity.Y = 0.1f;
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
