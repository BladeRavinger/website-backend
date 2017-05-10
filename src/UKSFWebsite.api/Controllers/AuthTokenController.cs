using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Parser.SyntaxTree;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UKSFWebsite.api.Controllers
{
    [Route("api/[controller]")]
    public class AuthTokenController : Controller
    {
        // GET: api/authtoken
        /// <summary>
        /// Gets meta data about the provided access token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "asd", "" };
        }

        // POST api/authtoken
        /// <summary>
        /// Creates a new access token based on username and password provided.
        /// </summary>
        /// <param name="body">Body of the request provides login information.</param>
        [HttpPost]
        public string Post()
        {
            acceptedname = HttpContext.Request.Headers["Authentication"];
            return "new accepted name is " + acceptedname;
        }

        public static string acceptedname = "first";
    }
}
