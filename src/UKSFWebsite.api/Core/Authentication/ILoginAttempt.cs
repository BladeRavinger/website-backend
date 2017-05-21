using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Authentication
{
    interface ILoginAttempt
    {
        Task TryLogin(string userid, string password);
    }
}
