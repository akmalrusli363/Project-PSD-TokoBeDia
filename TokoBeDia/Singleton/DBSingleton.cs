using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Singleton
{
    public class DBSingleton
    {
        private static DatabaseEntities db = null;

        private DBSingleton()
        {
        }

        public static DatabaseEntities getInstance()
        {
            return (db == null) ? new DatabaseEntities() : db;
        }
    }
}