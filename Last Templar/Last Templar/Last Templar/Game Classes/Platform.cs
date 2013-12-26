using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Last_Templar.Game_Classes
{
    public class Platform
    {
        int width, height;
        public Rectangle rectangle;
        Texture2D texture;

        public Platform(Vector2 pos, GraphicsDevice gd, ContentManager cm, String filename)
        {
            texture = cm.Load<Texture2D>(filename);

            width = texture.Width;
            height = texture.Height;

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, width, height);
        }

        public void draw(SpriteBatch sb)
        {
            //Start sprite batch for drawing (you need to start and end a sprite batch any time you want to draw anything
            Vector2 rectPos = new Vector2(rectangle.X, rectangle.Y);
            sb.Begin();
            //Draw a new object, using our 1x1 pixel as the texture, our rectangle for the shape, and our color for the object's color
            sb.Draw(texture, rectPos, null, Color.White);
            sb.End();
        }
    }
}
