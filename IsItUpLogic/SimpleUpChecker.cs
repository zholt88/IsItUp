using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;

namespace IsItUpLogic
{
    public class SimpleUpChecker : IUpChecker
    {
        public bool IsItUp(string uri)
        {
            return IsUp(uri).GetAwaiter().GetResult();
        }

        public async Task<bool> IsItUpAsync(string uri)
        {
            return await IsUp(uri);
        }

        public IEnumerable<(string uri, bool isUp)> AreTheyUp(IEnumerable<string> uris)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<(string uri, bool isUp)>> AreTheyUpAsync(IEnumerable<string> uris)
        {
            throw new NotImplementedException();
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
