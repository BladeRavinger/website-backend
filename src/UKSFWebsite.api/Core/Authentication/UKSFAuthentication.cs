using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UKSFWebsite.api.Core.Authentication;

namespace UKSFWebsite.api.Controllers
{
    public class UKSFAuthentication
    {
        private UKSFAuthentication instance;

        public UKSFAuthentication Instance
        {
            get
            {
                if(instance == null)
                    instance = new UKSFAuthentication();
                return instance;
            }
        }

        public AccessToken getNewToken()
        {
            return createToken();
        }

        private AccessToken createToken()
        {
            return new AccessToken();
        }
    }
}
