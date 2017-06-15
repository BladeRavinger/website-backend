using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.Database
{
    public class DatabaseSetup
    {
        private IMongoClient dbServer;
        public DatabaseSetup()
        {
            setupRequiredDatabases();
            setupRequiredCollections();
            //setupRequiredDefaultValues();//TODO
        }

        private void setupRequiredDatabases()
        {
            //loop
            //if doesn't exist then setupDatabase()
        }

        private void setupRequiredCollections()
        {
            //same as db
        }

        private void setupCollection()
        {

        }

        private void setupDatabase()
        {

        }

        private bool checkDatabase()
        {
            return false;
        }

        private bool checkCollection()
        {
            return false;
        }
    }
}
