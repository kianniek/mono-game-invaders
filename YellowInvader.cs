using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal class YellowInvader : Invader
    {
        //has moved up/down in its pattern
        bool moved = false;
        int frameCount;
        public YellowInvader() : base("spr_yellow_invader")
        {
        }
        public override void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            velocity.X = 3.0f;
            velocity.Y = texture.Height/2;
        }
        public override bool Update()
        {
            frameCount++;
            if (frameCount % 10 == 0)
            {
                if (moved)
                {
                    position.Y += velocity.Y;
                    moved = false;
                }
                else
                {
                    position.Y -= velocity.Y;
                    moved = true;
                }
            }
            position.X += velocity.X;

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
