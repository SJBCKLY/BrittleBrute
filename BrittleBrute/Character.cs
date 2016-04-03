using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrittleBrute
{
    class Character
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Rectangle position;
        public Texture2D sprite;
        private int currentFrame;
        private double frameTimer;
        private int totalFrames;
        private Rectangle source;

        public Character(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            position = new Rectangle(_x, _y, _width, _height);
        }

        public Rectangle getPosition()
        {
            return position;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public Texture2D getTexture()
        {
            return sprite;
        }

        public Rectangle getSource()
        {
            source = new Rectangle((Convert.ToInt32(currentFrame * width)), 0, width, height);
            return source;
        }

        public void setPosition(int _x, int _y)
        {
            position = new Rectangle(_x, _y, width, height);
        }

        public int setX(int _x)
        {
            x = _x;
            return x;
        }

        public int setY(int _y)
        {
            y = _y;
            return y;
        }

        public void moveLeft(int _movement)
        {
            x = x - _movement;
        }

        public void moveRight(int _movement)
        {
            x = x + _movement;
        }

        public void moveUp(int _movement)
        {
            y = y - _movement;
        }

        public void moveDown(int _movement)
        {
            y = y + _movement;
        }

        public void setTexture(Texture2D _sprite, int _totalFrames)
        {
            sprite = _sprite;
            totalFrames = _totalFrames;
        }

        public void setCurrentFrame(int _frame)
        {
            currentFrame = _frame;
        }

        public int getCurrentFrame()
        {
            return currentFrame;
        }

        public void updateFrame()
        {
            frameTimer = frameTimer + 0.067;
            if (frameTimer > 1)
            {
                currentFrame++;
                if (currentFrame > 6)
                {
                    currentFrame = 0;
                }
                frameTimer = 0;
            }
        }
    }
}
