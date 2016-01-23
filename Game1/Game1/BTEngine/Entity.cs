using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Game1.BTEngine
{
    class Entity
    {
        private int X;
        private int Y;
        private bool isAlive;
        private Texture2D sprite;

        public enum moveDirection { Up, Down, Left, Right }

        public Entity()
        {
            X = 0;
            Y = 0;
            isAlive = false;
            sprite = null;
        }
        public Entity(int xCoord, int yCoord, Texture2D texture)
        {
            X = xCoord;
            Y = yCoord;
            isAlive = true;
            sprite = texture;
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public bool isLiving()
        {
            return isAlive;
        }
        public bool Kill()
        {
            if (isAlive)
            {
                isAlive = false;
                return true;
            }
            return false;
        }
        public bool Revive()
        {
            if (!isAlive)
            {
                isAlive = true;
                return true;
            }
            return false;
        }
        public Texture2D getSprite()
        {
            return sprite;
        }
        public void setSprite(Texture2D texture)
        {
            sprite = texture;
        }
        public bool Move(moveDirection moving, int Distance = 1, bool ignoreDeath = false)
        {
            if (isAlive || ignoreDeath)
            {
                switch (moving)
                {
                    case moveDirection.Up:
                        Y -= Distance;
                        return true;
                    case moveDirection.Down:
                        Y += Distance;
                        return true;
                    case moveDirection.Left:
                        X -= Distance;
                        return true;
                    case moveDirection.Right:
                        X += Distance;
                        return true;
                    default: return false;
                }
            }
            return false;
        }
    }

}
