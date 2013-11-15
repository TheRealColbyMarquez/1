using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PizzaGuy;

namespace PizzaGuy
{
    class PizzaGuy : Sprite
    {
        public PizzaGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity) :

            base(location, texture, initialFrame, velocity)
        {

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Down))
            {
                velocity = new Vector2(0,0);
                
            }

            if (keyboard.IsKeyDown(Keys.Right))
            {
                Velocity = new Vector2(175, 0);
                Rotation = 1.59f;

            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                velocity = new Vector2(0, 175);
                Rotation = 3.18f;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(0, -175);
                Rotation = 0f;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                velocity = new Vector2(-175, 0);
                Rotation = 4.77f;
            }

            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Down))
            {
                velocity = new Vector2(175, 175);
                Rotation = 2.385f;
            }

            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(175, -175);
                Rotation = 0.795f;
            }

            if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(-175, -175);
                Rotation = 5.565f;
            }

            if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyDown(Keys.Down))
            {
                velocity = new Vector2(-175, 175);
                Rotation = 3.975f;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}