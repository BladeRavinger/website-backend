using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UKSFWebsite.api.Core.Authentication
{
    public class LoginAttempt
    {
        private string userid;
        private string password;

        public bool success { get; private set; }
        public bool accountExists { get; private set; }

        public LoginAttempt(string userid, string password)
        {
            this.userid = userid;
            this.password = password;

            if (userid == "email" && password == "password")
                success = true;
        }
    }
}
