using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using UKSFWebsite.api.Core.Models;
using UKSFWebsite.api.Core.Registration;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UKSFWebsite.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

		/// <summary>
		/// Starts registration process of user
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<string> Post()
		{
			Task attempting = new Registration(HttpContext).tryRegister(HttpContext.Request.Headers["username"], HttpContext.Request.Headers["password"], HttpContext.Request.Headers["email"]);
			while (attempting.Status == TaskStatus.Running)
			{
				await Task.Delay(200);
			}
			return null;
		}
	}
}
