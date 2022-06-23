using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anarchy;
using Discord.Gateway;
using Discord;
using System.Runtime.InteropServices;
using System.Threading;
using Kyanite_Account_Nuker.Helpers;
using Kyanite_Account_Nuker.Forms;
using System.Text.RegularExpressions;
using Kyanite_Account_Nuker.CustomExtensions;

namespace Kyanite_Account_Nuker
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();
        }

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        public DiscordClient client;


        async private Task LoginCord()
        {
            loginButton.Text = "This Will Take A Bit...";
            client = new DiscordClient(this.tokenText.Text, null);
            Console.WriteLine(client.User.Username);
            loginButton.Text = "Logged In";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (loginButton.Text == "Login (Required)")
            {
                Thread t = new Thread(async () => await LoginCord());
                t.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Guna.UI2.WinForms.Guna2ShadowForm(this)
            {
                ShadowColor = Color.FromArgb(110, 68, 255)
            };
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        private void guna2Panel8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.BlockEveryone(client));
            t.Start();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.UnfriendEveryone(client));
            t.Start();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.BlockFriends(client));
            t.Start();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            guildPanel.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.SpamGuilds(client, guna2TextBox1.Text, int.Parse(guna2TextBox2.Text)));
            t.Start();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.DeleteGuilds(client));
            t.Start();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.LeaveServers(client));
            t.Start();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.CloseDMS(client));
            t.Start();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(async () => await Features.MassDMFriends(client, guna2TextBox4.Text));
            t.Start();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            massDMPanel.BringToFront();
        }





        private void guna2Button13_Click(object sender, EventArgs e)
        {

            AboutToken aboutToken = new AboutToken(tokenText.Text.Kyanite())
            {
            };
            aboutToken.Show();
        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            new Thread(async () => await Features.Seizure(client)).Start();
        }

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {
        }
    }






    namespace CustomExtensions
    {
        //Extension methods must be defined in a static class
        public static class StringExtension
        {
            // This is the extension method.
            // The first parameter takes the "this" modifier
            // and specifies the type for which the method is defined.
            public static string Kyanite(this string str)
            {
                return str.ToString();
            }

            public static string ConvertWhitespacesToSingleSpaces(this string value)
            {
                return Regex.Replace(value, @"\s+", " ");
            }
        }
    }

}
