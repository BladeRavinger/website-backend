using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UKSFWebsite.api.Core.Account;
using Newtonsoft.Json.Linq;

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
        public string Get()
        {
            JObject responseObject = new JObject();
            responseObject.Add(new JProperty("isAuthenticated", HttpContext.User.Identity.IsAuthenticated.ToString()));
            HttpContext.Response.Headers.Add("Content-Type", "application/json");
            return responseObject.ToString();
        }

        // POST api/authtoken
        /// <summary>
        /// Creates a new access token based on username and password provided.
        /// </summary>
        /// <param name="body">Body of the request provides login information.</param>
        [HttpPost]
        public async Task<string> Post()
        {
            Task attempting = new LoginAttempt(HttpContext).tryLogin();
            while (attempting.Status == TaskStatus.Running)
            {
                await Task.Delay(200);
            }

            return "log in attempted "+HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
