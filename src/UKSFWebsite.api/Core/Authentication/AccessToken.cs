using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Authentication
{
    public class AccessToken
    {
        private string token;
        private string lastValidated;

        public AccessToken()
        {
            
            registerWithDatabase();
        }

        public bool checkIsValid()
        {
            return false;
        }
        
        private void registerWithDatabase()
        {

        }
    }
}
