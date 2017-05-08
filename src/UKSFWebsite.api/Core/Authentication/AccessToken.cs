using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Authentication
{
    public class AccessToken
    {
        public string token { get; private set; }

        public bool checkIsValid()
        {
            return false;
        }
        
        private void registerWithDatabase()
        {

        }
    }
}
