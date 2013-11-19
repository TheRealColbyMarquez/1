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
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    class PizzaGuy : Sprite
    {
        public Direction direction;
        public Vector2 target;
        public xTile.Layers.Layer map;
        public float speed = 120;

        public PizzaGuy(
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

        public void UpdateDirection()
        {
            Vector2 oldtarget = target;
            float oldRotation = Rotation;

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

            if (map.Tiles[(int)target.X / 32, (int)target.Y / 32] != null)
            {
                target = location;
                velocity = Vector2.Zero;
                Rotation = oldRotation;
            }
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Right))
            {
                direction = Direction.RIGHT;
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                direction = Direction.DOWN;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {
                direction = Direction.UP;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                direction = Direction.LEFT;
            }

            if (velocity.X > 0 && location.X >= target.X ||
                velocity.X < 0 && location.X <= target.X ||
                velocity.Y > 0 && location.Y >= target.Y ||
                velocity.Y < 0 && location.Y <= target.Y ||
                velocity == Vector2.Zero)
            {
                location = target;

                UpdateDirection();
            }


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}