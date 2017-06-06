using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Parser.SyntaxTree;
using UKSFWebsite.api.Core.Authentication;

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
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { HttpContext.User.ToString(), HttpContext.User.Identity.Name, HttpContext.User.Identity.IsAuthenticated.ToString() };
        }

        // POST api/authtoken
        /// <summary>
        /// Creates a new access token based on username and password provided.
        /// </summary>
        /// <param name="body">Body of the request provides login information.</param>
        [HttpPost]
        public async Task<string> Post()
        {
            Task attempting = new LoginAttempt(HttpContext).tryLogin(HttpContext.Request.Headers["userid"], HttpContext.Request.Headers["password"]);
            while (attempting.Status == TaskStatus.Running)
            {
                await Task.Delay(200);
            }

            return "log in attempted "+HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
