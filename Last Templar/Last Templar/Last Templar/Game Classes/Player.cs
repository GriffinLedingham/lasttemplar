using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Last_Templar.Game_Classes
{
    class Player
    {
        //Declare the object's variables it will use
        Vector2 position;
        Texture2D texture;
        int height;
        int width;
        Color color;

        Vector2 velocity;

        Rectangle rectangle;

        //This is the object's constructor, it takes in a vector (X position, Y position), a width, and a height
        public Player(Vector2 posIn, int width_in, int height_in, GraphicsDevice gd)
        {
            //Assign square's position
            position = posIn;

            width = width_in;
            height = height_in;

            rectangle = new Rectangle(0, 0, width, height);


            //Give the square a color for when you want to draw it to the screen
            color = Color.Red;

            velocity = new Vector2(0, 0);

            //Create a sample 1x1 white pixel, which we will color below when it comes time to actually draw the object
            texture = new Texture2D(gd, 1,1);
            texture.SetData(new Color[] { Color.White });
        }

        public void keyPressed(Keys pressed)
        {
            if (pressed == Keys.Left)
            {
                velocity.X -= .3f;
                velocity.Y -= .3f;
            }
            if (pressed == Keys.Right)
            {
                velocity.X += .3f;
                velocity.Y += .3f;
            }
            if (pressed == Keys.Up)
            {
                velocity.Y -= .3f;
                velocity.X += .3f;
            }
            if (pressed == Keys.Down)
            {
                velocity.Y += .3f;
                velocity.X -= .3f;

            }
        }

        public void update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;
            if (velocity.X > 0)
            {
                velocity.X -= .1f;
                if (velocity.X < 0)
                {
                    velocity.X = 0;
                }
            }
            else
            {
                velocity.X += .1f;
                if (velocity.X > 0)
                {
                    velocity.X = 0;
                }
            }

            if (velocity.Y > 0)
            {
                velocity.Y -= .1f;
                if (velocity.Y < 0)
                {
                    velocity.Y = 0;
                }
            }
            else
            {
                velocity.Y += .1f;
                if (velocity.Y > 0)
                {
                    velocity.Y = 0;
                }
            }
        }

        public void draw(SpriteBatch sb)
        {
            //Start sprite batch for drawing (you need to start and end a sprite batch any time you want to draw anything
            sb.Begin();
                //Draw a new object, using our 1x1 pixel as the texture, our rectangle for the shape, and our color for the object's color
                sb.Draw( texture,position,rectangle,color);
            sb.End();
        }
    }
}
