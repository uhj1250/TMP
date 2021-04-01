using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP
{
    public partial class Form1 : Form
    {

        public bool terminate = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = Steam.process.ProcessName + " " + Steam.process.Handle;
            ProcessThreadCollection sc = Steam.process.Threads;
            

            foreach(Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.ToLower().Contains("steam"))
                {
                    try
                    {
                        IntPtr trayApp = TrayUtility.FindWindow(null, proc.ProcessName);
                        //TrayUtility.ShowWindow(trayApp, 1);
                        NotifyIconData pnid = new NotifyIconData();
                        pnid.uCallbackMessage = 0x800;
                        pnid.uFlags = 1;
                        pnid.hwnd = trayApp;
                        pnid.uID = 1;
                        pnid.hIcon = IntPtr.Zero;
                        pnid.szTip = null;
                        pnid.uFlags |= 2;
                        label1.Text += "\n" + TrayUtility.Shell_NotifyIcon(2, ref pnid) + " ";
                        label1.Text += proc.ProcessName + " " + pnid.hwnd + " " + trayApp;
                    }
                    catch
                    {
                        label1.Text += "\n" + proc.ProcessName + " Failed";
                    }

                }


            }


            //NotifyIconData pnid = new NotifyIconData();
            //pnid.uCallbackMessage = 0x800;
            //pnid.uFlags = 1;
            //
            //pnid.hwnd = Steam.process.Handle;
            //pnid.uID = 1;
            //pnid.hIcon = IntPtr.Zero;
            //pnid.szTip = null;
            //pnid.uFlags |= 2;
            //Steam.Shell_NotifyIcon(2, ref pnid);

        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                notifyIcon1.Visible = true;
                Hide();
                e.Cancel = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {   
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            FormClosing += Form1_FormClosing;
            RecentGame.BuildGameList();
            BuildContextMenuStrip();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terminate = true;
            Close();
        }

        public void BuildContextMenuStrip()
        {
            notifyIcon1.ContextMenuStrip.Items.Clear();
            foreach (Game game in RecentGame.games)
            {
                notifyIcon1.ContextMenuStrip.AddMenuItem_Game(game);
            }
            notifyIcon1.ContextMenuStrip.Items.Add(toolStripSeparator1);


            notifyIcon1.ContextMenuStrip.Items.Add(exitToolStripMenuItem);


        }



    }
}
