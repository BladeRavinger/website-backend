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
        public Database ()
        {
            /**
             * Setting database connectivity
             **/
            databaseConnection = new MongoClient("mongodb://api:sXH9gjG98wXX@92.222.75.92:27017/UKSF");
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
