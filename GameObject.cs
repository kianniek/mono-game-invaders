using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class GameObject
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        virtual public void Reset()
        {

        }
        virtual public bool Update()
        {
            return true;
        }

        virtual public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
