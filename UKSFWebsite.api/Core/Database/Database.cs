﻿using System;
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
            databaseConnection = new MongoClient(ConfigManager.getValue("DbConUrl"));
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
