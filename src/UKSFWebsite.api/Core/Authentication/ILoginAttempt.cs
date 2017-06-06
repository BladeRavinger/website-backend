﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Authentication
{
    interface ILoginAttempt
    {
        Task tryLogin(string userid, string password);
    }
}
