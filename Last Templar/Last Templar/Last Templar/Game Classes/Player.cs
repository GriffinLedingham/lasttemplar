using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Last_Templar.Game_Classes
{
    class Player
    {
        Vector2 position;
        Texture2D dummyTexture;
        Rectangle dummyRectangle;
        Color Colori;

        public Player(Vector2 posIn, GraphicsDevice gd)
        {
            position = posIn;
            dummyRectangle = new Rectangle(100,100,100,100);
            Colori = Color.Red;
            dummyTexture = new Texture2D(gd, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
        }

        public void update()
        {

        }

        public void draw(SpriteBatch sb)
        {
            sb.Begin();
                sb.Draw(dummyTexture, dummyRectangle, Colori);
            sb.End();
        }
    }
}
