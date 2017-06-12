using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;

namespace UKSFWebsite.api.Core.Database
{
    public class Database
    {
        private static IMongoClient databaseConnection;
        private Database ()
        {
            /**
             * Setting database connectivity
             **/
            string conUrlKey = "TestingDbConUrl";
            if (Environment.GetEnvironmentVariable("-StagingEnvironment") != null)
            {
                conUrlKey = "StagingDbConUrl";
            }
            else if(Environment.GetEnvironmentVariable("-LiveEnvironment") != null){
                conUrlKey = "DbConUrl";
            }
            databaseConnection = new MongoClient(ConfigManager.getValue(conUrlKey));
        }
        public static Database getDatabase()
        {
            return new Database();
        }
        public IMongoDatabase getMongoDatabase()
        {
            return databaseConnection.GetDatabase("UKSF");
        }
    }
}
