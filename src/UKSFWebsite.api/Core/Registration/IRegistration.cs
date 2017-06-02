using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Registration
{
    interface IRegistration
    {
		Task register();
		Boolean userExists();
    }
}
