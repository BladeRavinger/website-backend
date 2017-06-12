using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UKSFWebsite.api.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UKSFWebsite.api.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { ConfigManager.getValue("DbConUrl") };
        }
    }
}
