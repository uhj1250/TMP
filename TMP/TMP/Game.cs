using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TMP
{
    public struct Game
    {

        public string name;
        public string url;
        public string path;
        public Flatform flatform;
        public Image image;
        public EventHandler OnClick;

        public Game(string name, string url, Flatform flatform, Image image, EventHandler OnClick)
        {
            this.name = name;
            this.url = url;
            this.flatform = flatform;
            this.image = image;
            this.OnClick = OnClick;
            this.path = null;

        }


    }

    public static class RecentGame
    {
        public static List<Game> games = new List<Game>();

        public static void BuildGameList()
        {
            for(int i=0; i<5; i++)
            {
                games.Add(new Game("ASdf" + i, "steam://rungameid/294100", Flatform.Steam, null, Steam.StartGame));
            }
        }

        public static void AddGame(Game game)
        {
            if (games.Contains(game))
            {
                games.Remove(game);
            }
            games.Insert(0,game);
            Program.mainform.BuildContextMenuStrip();
        }

        



    }



}
