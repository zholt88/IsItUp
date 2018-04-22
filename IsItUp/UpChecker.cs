using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Flurl.Http;

namespace IsItUp
{
    public class UpChecker
    {
        public bool IsItUp()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["UrlToCheck"];
            if (IsUp(url))
            {
                var notification = new NotifyIcon()
                {
                    Visible = true,
                    Icon = SystemIcons.Information,
                    BalloonTipText = "Yay! " + url + " is up!"
                };
                notification.ShowBalloonTip(5000);
                return true;
            }
            return false;
        }

        private static bool IsUp(string url)
        {
            try
            {
                HttpResponseMessage response = url.GetAsync().GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                string conent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
