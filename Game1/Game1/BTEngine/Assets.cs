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
}
