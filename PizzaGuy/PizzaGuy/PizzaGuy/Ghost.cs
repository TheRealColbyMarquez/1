using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PizzaGuy
{
    class Ghost : MazeActor
    {
        Random rand = new Random();
        public float timer = 0f;
        public PizzaGuy pacman;

        public Ghost(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Layers.Layer map,
            PizzaGuy pacman) :

            base(location, texture, initialFrame, velocity, map)
        {
            this.pacman = pacman;
        }

        public override void UpdateDirection()
        {
            base.UpdateDirection();
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer >= 0)
            {
                timer = 0;

                newDirection = (Direction)rand.Next(0, 5);

                while (!CanMove(newDirection))
                    newDirection = (Direction)rand.Next(0, 5);
            }

            base.Update(gameTime);

            /*
            if (!CanMove(direction))
            {
                if (CanMove(Direction.UP))
                {
                    newDirection = Direction.UP;
                }
                else if (CanMove(Direction.DOWN))
                {
                    newDirection = Direction.DOWN;
                }
                else if (CanMove(Direction.LEFT))
                {
                    newDirection = Direction.LEFT;
                }
                else if (CanMove(Direction.RIGHT))
                {
                    newDirection = Direction.RIGHT;
                }                
            }
             * */
        }
    }
}
