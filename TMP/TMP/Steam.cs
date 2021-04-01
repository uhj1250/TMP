using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace TMP
{
    public static class Steam
    {

        private static Process proccache = null;

        public static Process process
        {
            get
            {
                if (proccache != null) return proccache;
                else
                {
                    proccache = Process.GetProcessesByName("steam").FirstOrDefault();
                    if (proccache == null) proccache = StartSteam();
                    return proccache;
                }

            }
        }


        public static Process StartSteam()
        {

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Valve\Steam", false);
            string path = (string)key.GetValue("InstallPath");
            Process steam = Process.Start(path + "/Steam.exe", "-silent");
            return steam;
        }

        public static void StartGame(object sender, EventArgs e)
        {

            ToolStripMenuItem_Game item = sender as ToolStripMenuItem_Game;
            Process.Start(item.URL);
            RecentGame.AddGame(item.game);
        }


    }

}
