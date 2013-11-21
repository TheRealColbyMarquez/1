using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PizzaGuy
{
    class PizzaGuy : MazeActor
    {
        public PizzaGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Layers.Layer map) :

            base(location, texture, initialFrame, velocity, map)
        {
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Right))
            {

                newDirection = Direction.RIGHT;
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {

                newDirection = Direction.DOWN;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {

                newDirection = Direction.UP;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {

                newDirection = Direction.LEFT;
            }

            base.Update(gameTime);
        }
    }
}