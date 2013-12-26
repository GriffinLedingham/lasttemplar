using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Last_Templar.Game_Classes
{
    public class Level
    {
        public List<Platform> platforms;

        public Level(GraphicsDevice gd, ContentManager cm)
        {
            platforms = new List<Platform>();
            platforms.Add(new Platform(new Vector2(100, 750), gd, cm,"prisontile"));
            platforms.Add(new Platform(new Vector2(150, 900), gd, cm, "prisontile"));
            platforms.Add(new Platform(new Vector2(450, 900), gd, cm, "prisontile"));
        }

        public void draw(SpriteBatch sb)
        {
            foreach (Platform p in platforms)
            {
                p.draw(sb);
            }
        }
    }
}
