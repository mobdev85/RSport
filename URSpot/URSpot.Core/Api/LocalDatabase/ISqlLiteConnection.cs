using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Dependencies;
using URSpot.Core.Statics;

namespace URSpot.Core.Api.LocalDatabase
{
    public interface ISqlLiteConnection
    {
        SQLiteConnection GetConnection();

    }

    public class SqlLite : ISqlLiteConnection
    {
        public SqlLite()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = WebApi.SqliteDataBaseName;
            string documentsPath = Xamarin.Forms.DependencyService.Get<IDataBasePath>().GetDataBasePath(); // Documents folder

            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
