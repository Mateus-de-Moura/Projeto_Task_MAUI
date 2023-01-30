using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPFinanceiro
{
    public class AppSettings
    {
        private static string DatabaseName = "databaseTask.db";
        private static string DatabaseDirectory = FileSystem.AppDataDirectory;
        public  static string DatabasePatch = Path.Combine(DatabaseDirectory, DatabaseName);
    }
}
