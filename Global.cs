using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    static class Global
    {
        static public ContentManager content;
        static public Rectangle screenRect;
        static public KeyboardState keys;
        static public int width, height;
        static public SpriteBatch spriteBatch;
        static private GraphicsDevice _graphicsDevice;

        static public GraphicsDevice GraphicsDevice
        {
            get 
            {
                return _graphicsDevice;
            }
            
            set
            {
                _graphicsDevice = value;
                screenRect = new Rectangle(0, 0, _graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height);
                width = screenRect.Width;
                height = screenRect.Height;
            }
        }

        static private Random _rGen = new Random();
        static public int Random(int lower, int upper)
        {
            return _rGen.Next(lower, upper);
        }
    }
}
