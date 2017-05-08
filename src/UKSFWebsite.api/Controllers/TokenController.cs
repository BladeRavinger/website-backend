using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UKSFWebsite.api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        // GET: api/token
        /// <summary>
        /// Gets meta data about the provided access token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // POST api/token
        /// <summary>
        /// Creates a new access token based on username and password provided.
        /// </summary>
        /// <param name="body">Body of the request provides login information.</param>
        [HttpPost]
        public void Post([FromBody]string body)
        {

        }
    }
}
