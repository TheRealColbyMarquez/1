using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PizzaGuy
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    class MazeActor : Sprite
    {
        public Direction direction, newDirection;
        public Vector2 target;
        public xTile.Layers.Layer map;
        public float speed = 120;

        public MazeActor(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Layers.Layer map) :

            base(location, texture, initialFrame, velocity)
        {
            direction = Direction.RIGHT;
            target = location;
            this.map = map;

            UpdateDirection();
        }

        public bool CanMove(Direction dir)
        {
            Vector2 newTarget = target;

            switch (dir)
            {
                case Direction.LEFT:

                    newTarget += new Vector2(-32, 0);

                    break;

                case Direction.RIGHT:

                    newTarget += new Vector2(32, 0);


                    break;

                case Direction.UP:

                    newTarget += new Vector2(0, -32);


                    break;

                case Direction.DOWN:

                    newTarget += new Vector2(0, 32);


                    break;
            }

            if (map.Tiles[(int)newTarget.X / 32, (int)newTarget.Y / 32] == null)
            {
                return true;
            }

            return false;
        }

        public virtual void UpdateDirection()
        {

            switch (direction)
            {
                case Direction.LEFT:

                    target = location + new Vector2(-32, 0);
                    velocity = new Vector2(-speed, 0);
                    Rotation = -MathHelper.PiOver2;

                    break;

                case Direction.RIGHT:

                    target = location + new Vector2(32, 0);
                    velocity = new Vector2(speed, 0);
                    Rotation = MathHelper.PiOver2;

                    break;

                case Direction.UP:

                    target = location + new Vector2(0, -32);
                    velocity = new Vector2(0, -speed);
                    Rotation = 0;

                    break;

                case Direction.DOWN:

                    target = location + new Vector2(0, 32);
                    velocity = new Vector2(0, speed);
                    Rotation = MathHelper.Pi;

                    break;
            }


        }

        public override void Update(GameTime gameTime)
        {

            if (velocity.X > 0 && location.X >= target.X ||
                velocity.X < 0 && location.X <= target.X ||
                velocity.Y > 0 && location.Y >= target.Y ||
                velocity.Y < 0 && location.Y <= target.Y ||
                velocity == Vector2.Zero)
            {
                location = target;

                if (CanMove(newDirection))
                {
                    direction = newDirection;
                    UpdateDirection();
                }
                else if (CanMove(direction))
                {
                    UpdateDirection();
                }

            }


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
