using Discord;
using Kyanite_Account_Nuker.CustomExtensions;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace Kyanite_Account_Nuker.Forms
{
    public partial class AboutToken : Form
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
        public string GetTokenInfo(string tkn)
        {
            string Final = ""       ;
            HttpRequest request = new HttpRequest();
            request.AddHeader("Authorization", tkn);
            var abtme = request.Get("https://discord.com/api/v9/users/@me");
            var jsonic = abtme.ToString();
            JObject o = JObject.Parse(jsonic);
            Final += $"ID: {o["id"]}" + Environment.NewLine;
            Final += $"Username: {o["username"]}#{o["discriminator"]}" + Environment.NewLine;
            Final += $"Email: {o["email"]}" + Environment.NewLine;
            Final += $"Phone Number: {o["phone"]}" + Environment.NewLine;

            return Final;
        }

        //{"id": "979594273848721448", "username": "sdmjlhdsfljdsfdf", "avatar": null, "avatar_decoration": null, "discriminator": "8321", "public_flags": 0, "flags": 0, "banner": null, "banner_color": null, "accent_color": null, "bio": "", "pronouns": "", "locale": "en-US", "nsfw_allowed": true, "mfa_enabled": false, "email": "devorlopata6@hotmail.com", "verified": true, "phone": null}
    public AboutToken(string client)
        {
            InitializeComponent();
            textBox1.Text += GetTokenInfo(client).Kyanite();
        }

        private void AboutToken_Load(object sender, EventArgs e)
        {
            new Guna.UI2.WinForms.Guna2ShadowForm(this)
            {
                ShadowColor = Color.FromArgb(110, 68, 255)
            };
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            Opacity = 0.98;
        }

        private void guna2Panel8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AboutToken_Load_1(object sender, EventArgs e)
        {

        }
    }
}
