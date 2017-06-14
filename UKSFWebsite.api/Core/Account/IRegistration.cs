using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Account
{
    interface IRegistration
    {
		Task tryRegister();
    }
}
