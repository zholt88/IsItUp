using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsItUpCore
{
    public interface IUpChecker
    {
        bool IsItUp(string uri);
        Task<bool> IsItUpAsync(string uri);
        IEnumerable<(string uri, bool isUp)> AreTheyUp(IEnumerable<string> uris);
        Task<IEnumerable<(string uri, bool isUp)>> AreTheyUpAsync(IEnumerable<string> uris);
    }
}
