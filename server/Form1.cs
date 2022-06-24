using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void Form1_Load(object sender, EventArgs e)
        {
            Process.Start("Growtopia.exe");

            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = "Server Data Restarter Timer > " + +progressBar2.Value;
            Process[] server = Process.GetProcessesByName("Growtopia");
            progressBar2.Increment(1);
            if (progressBar2.Value == 2400000) //3 days useful for free memory
            {
                Process[] processes = Process.GetProcessesByName("Growtopia");
                Process game1 = processes[0];

                IntPtr p = game1.MainWindowHandle;

                SetForegroundWindow(p);
                System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM Growtopia.exe /T");
                listBox1.Items.Add("Restarted server to save data " + System.DateTime.Now);
                progressBar2.Value = 0;
            }

            if (server.Length < 1)
            {
                listBox1.Items.Add("Crashed At " + System.DateTime.Now);
                Process.Start("Growtopia.exe");
            }
            else
            {

            }

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
