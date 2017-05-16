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
            databaseConnection = new MongoClient(SensitiveConfigurationManager.dbConUrl);
        }
        public static Database getDatabase()
        {
            return new Database();
        }
        private static IMongoDatabase getMongoDatabase()
        {
            return databaseConnection.GetDatabase("UKSF");
        }
    }
}
