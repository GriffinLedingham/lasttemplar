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
        //Declare the object's variables it will use
        Vector2 position;
        Texture2D texture;
        Rectangle rectangle;
        Color color;

        //This is the object's constructor, it takes in a vector (X position, Y position), a width, and a height
        public Player(Vector2 posIn, int width_in, int height_in, GraphicsDevice gd)
        {
            //Assign square's position
            position = posIn;

            //Assign square's rectangle refence (this gives the square an X,Y coordinate, as well as a height and a width)
            rectangle = new Rectangle(posIn.X(), posIn.Y(), width_in, height_in);

            //Give the square a color for when you want to draw it to the screen
            color = Color.Red;

            //Create a sample 1x1 white pixel, which we will color below when it comes time to actually draw the object
            texture = new Texture2D(gd, 1, 1);
            texture.SetData(new Color[] { Color.White });
        }

        public void update()
        {

        }

        public void draw(SpriteBatch sb)
        {
            //Start sprite batch for drawing (you need to start and end a sprite batch any time you want to draw anything
            sb.Begin();
                //Draw a new object, using our 1x1 pixel as the texture, our rectangle for the shape, and our color for the object's color
                sb.Draw(texture, rectangle, color);
            sb.End();
        }
    }
}
