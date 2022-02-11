using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{

    internal class BlueInvader : Invader
    {
        int frameCount;
        bool moved;
        public BlueInvader() : base("spr_blue_invader")
        {
        }
        public override void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            velocity.X = 3.0f;
            velocity.Y = texture.Height;
        }
        public override bool Update()
        {
            frameCount++;
            if (frameCount % 10 == 0)
            {
                velocity.Y = -velocity.Y;
            }

            position.X += velocity.X;
            position.Y += velocity.Y / 10;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
            return true;
        }
    }
}
