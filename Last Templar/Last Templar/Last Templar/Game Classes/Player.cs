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
        Color color;
        Vector2 velocity;
        Rectangle rectangle;

        int height;
        int width;
        bool jumping;

        //This is the object's constructor, it takes in a vector (X position, Y position), a width, and a height
        public Player(Vector2 posIn, int width_in, int height_in, GraphicsDevice gd)
        {
            //Assign square's position
            position = posIn;
            width = width_in;
            height = height_in;
            jumping = false;

            velocity = new Vector2(0, 0);
            rectangle = new Rectangle((int)posIn.X, (int)posIn.Y, width, height);

            //Give the square a color for when you want to draw it to the screen
            color = Color.Red;

            //Create a sample 1x1 white pixel, which we will color below when it comes time to actually draw the object
            texture = new Texture2D(gd, 1,1);
            texture.SetData(new Color[] { Color.White });
        }

        public void keyPressed(Keys pressed)
        {
            if (pressed == Keys.Left)
            {
                velocity.X = -10;
            }
            if (pressed == Keys.Right)
            {
                velocity.X = 10;
            }
            if (pressed == Keys.Up && !jumping)
            {
                jumping = true;
                velocity.Y = -20;
            }

            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }

        public void update(List<Platform> plat)
        {
            if (velocity.Y > 10)
            {
                velocity.Y = 10;
            }

            rectangle.X += (int)velocity.X;
            rectangle.Y += (int)velocity.Y;
            position += velocity;

            velocity = new Vector2(0, velocity.Y);

            bool intersecting = false;
            foreach (Platform p in plat)
            {
                if (rectangle.Intersects(p.rectangle))
                {
                    bool collide = collision(rectangle, p.rectangle);
                    if (collide)
                    {
                        intersecting = true;
                        jumping = false;
                    }
                }
            }
            
            if (jumping)
            {
                velocity.Y += 1;
            }

            if (intersecting == false)
            {
                jumping = true;
            }
        }

        public bool collision(Rectangle r1, Rectangle r2)
        {
            if (rectHelper.TouchTopOf(r1, r2) && velocity.Y > 0)
            {
                Console.WriteLine("collide");
                rectangle.Y = r2.Y - height;
                position.Y = r2.Y - height;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void draw(SpriteBatch sb)
        {
            //Start sprite batch for drawing (you need to start and end a sprite batch any time you want to draw anything
            Vector2 recPosition = new Vector2(rectangle.X, rectangle.Y);
            sb.Begin();
                //Draw a new object, using our 1x1 pixel as the texture, our rectangle for the shape, and our color for the object's color
                sb.Draw( texture,recPosition,rectangle,color);
            sb.End();
        }
    }
}
