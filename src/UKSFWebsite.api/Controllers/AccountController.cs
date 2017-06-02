using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using UKSFWebsite.api.Core.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UKSFWebsite.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpPost]
        public string Post([FromBody] string body)
        {
            Console.WriteLine(body);
            User user = BsonSerializer.Deserialize<User>(body);
            return string.Format("{0} {1}", user.username, user.password);
            //return body;
        }
    }
}
