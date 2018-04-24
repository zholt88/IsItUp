using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;

namespace IsItUpLogic
{
    public class NotifyingUpChecker : IUpChecker
    {
        public bool IsItUp(string uri)
        {
            if (IsUp(uri).GetAwaiter().GetResult())
            {
                ShowNotification(uri);
                return true;
            }
            return false;
        }

        public async Task<bool> IsItUpAsync(string uri)
        {
            if (await IsUp(uri))
            {
                ShowNotification(uri);
                return true;
            }
            return false;
        }

        public IEnumerable<(string uri, bool isUp)> AreTheyUp(IEnumerable<string> uris)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<(string uri, bool isUp)>> AreTheyUpAsync(IEnumerable<string> uris)
        {
            throw new NotImplementedException();
        }

        private void ShowNotification(string uri)
        {
            var notification = new NotifyIcon()
            {
                Visible = true,
                Icon = SystemIcons.Information,
                BalloonTipText = "Yay! " + uri + " is up!"
            };
            notification.ShowBalloonTip(5000);
        }

        private async Task<bool> IsUp(string uri)
        {
            try
            {
                HttpResponseMessage response = await uri.GetAsync();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
