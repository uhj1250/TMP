using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP
{
    public static class ContextMenuUtility
    {
        public static void AddMenuItem(this ContextMenuStrip contextMenuStrip, string label, System.Drawing.Image image, EventHandler Onclick)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(label,image, Onclick);
            contextMenuStrip.Items.Add(item);
        }

        public static void AddMenuItem_Game(this ContextMenuStrip contextMenuStrip, Game game)
        {
            switch (game.flatform)
            {
                case Flatform.Steam:
                    ToolStripMenuItem_Game item = new ToolStripMenuItem_Game(game.name, game.image, game.OnClick, game);
                    contextMenuStrip.Items.Add(item);
                    break;
            }
        }




    }





}
