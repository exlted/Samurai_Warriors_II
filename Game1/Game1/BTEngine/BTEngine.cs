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

namespace BTEngine //A fully 2D engine
{
    static class Assets
    {
        public static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public static SpriteFont font;
        public static string[] import;

        public static void importFiles(Game game)
        {
            import = Directory.GetFiles(Path.GetFullPath(@"../../../Content/Textures"));
            for (int i = 0; i < import.Length; i++)
            {
                textures.Add(Path.GetFileNameWithoutExtension(import[i]), game.Content.Load<Texture2D>("Textures/" + Path.GetFileNameWithoutExtension(import[i])));
            }
            import = Directory.GetFiles(Path.GetFullPath(@"../../../Content/Music"));
            for (int i = 0; i < import.Length; i++)
            {
                sounds.Add(Path.GetFileNameWithoutExtension(import[i]), game.Content.Load<SoundEffect>("Music/" + Path.GetFileNameWithoutExtension(import[i])));
            }
            font = game.Content.Load<SpriteFont>("Fonts/NewSpriteFont");
        }
    }

    static class Physics //Collision work
    {
        static List<ICollidable> allObjects;

        public static void addObject(ICollidable newObject)
        {
            if (!allObjects.Contains(newObject))
                allObjects.Add(newObject);
        }
    }

    class World
    {

    }

    class Entity : ICollidable
    {

        Rectangle pos;
        private bool isAlive;
        private Texture2D sprite;
        private Game theGame;

        public enum moveDirection { Up, Down, Left, Right }

        public Entity()
        {
            isAlive = false;
            sprite = null;
            theGame = null;
            pos = new Rectangle(0, 0, 0, 0);
            Physics.addObject(this);
        }
        public Entity(int xCoord, int yCoord, Texture2D texture, Game TheGame = null)
        {
            isAlive = true;
            sprite = texture;
            theGame = TheGame;
            pos = new Rectangle(xCoord, yCoord, sprite.Width, sprite.Height);
        }
        public int getX()
        {
            return pos.X;
        }
        public int getY()
        {
            return pos.Y;
        }
        public int getWidth()
        {
            return pos.Width;
        }
        public int getHeight()
        {
            return pos.Height;
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
                        pos.Y -= Distance;
                        return true;
                    case moveDirection.Down:
                        pos.Y += Distance;
                        return true;
                    case moveDirection.Left:
                        pos.X -= Distance;
                        return true;
                    case moveDirection.Right:
                        pos.X += Distance;
                        return true;
                    default: return false;
                }
            }
            return false;
        }
    }

    static class Render
    {
        public static void Draw()
        {

        }
    }

    interface ICollidable
    {

    }
}
