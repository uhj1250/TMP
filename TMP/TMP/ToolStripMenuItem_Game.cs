using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP
{
    public enum Flatform
    {
        Undefineded,
        Steam,
        Epic,
        Origin,
        BattleNet
    }


    public class ToolStripMenuItem_Game : ToolStripMenuItem
    {
        public string URL
        {
            get
            {
                return game.url;
            }
        }
        public Flatform Flatform
        {
            get
            {
                return game.flatform;
            }
        }



        public Game game;

        public ToolStripMenuItem_Game(string label, System.Drawing.Image image, EventHandler Onclick, Game game) : base(label, image, Onclick)
        {
            this.game = game;
        }


    }
}
