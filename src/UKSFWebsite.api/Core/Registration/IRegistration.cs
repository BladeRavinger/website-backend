﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Registration
{
    interface IRegistration
    {
		Task tryRegister(string username, string password, string email);
    }
}
