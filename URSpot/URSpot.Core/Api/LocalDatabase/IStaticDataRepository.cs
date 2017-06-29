using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.LocalDatabase.Entities;
using Newtonsoft.Json;

namespace URSpot.Core.Api.LocalDatabase
{
    public interface IStaticDataRepository
    {
        void SyncronizeDatabase(string version, string data);

        ICollection<MediaTypeEntity> GetAllMediaTypes();

        ICollection<MediaStatusEntity> GetAllMediaStatus();

        ICollection<FavoriteMusicEntity> GetAllFavoriteMusic();

        ICollection<FavoriteSportEntity> GetAllFavoriteSports();

    }


    public class StaticDataRepository  :IStaticDataRepository
    {
        private ISqlLiteConnection sqlLiteConnection;

        public StaticDataRepository( ISqlLiteConnection sqlLiteConnection)
        {
            this.sqlLiteConnection = sqlLiteConnection;
        }

        public async void SyncronizeDatabase(string version, string data)
        {
                var connection = sqlLiteConnection.GetConnection();
                //Create the lookup tables
                CreateTables(connection);
                // TruncateTables(connection);

                var dbVersion = connection.Table<VersionEntity>().FirstOrDefault();
                if (dbVersion == null || version != dbVersion.Version)
                {
                    TruncateTables(connection);
                   
                    PopulateTables(connection, data);

                    VersionEntity versionEntity = new VersionEntity { ID = 1, Version = version };
                    connection.InsertOrReplace(version);
                }

        }

        private void PopulateTables(SQLite.SQLiteConnection connection, string jsonCallback)
        {
            /*
			Regex regex = new Regex("[(.*?)]");
			var v = regex.Match(jsonCallback);
			string json = v.Groups[1].ToString();
			*/
            string json = jsonCallback.Replace("staticDataCallback([", "");
            json = json.Replace("])", "");

            StaticData staticData = JsonConvert.DeserializeObject<StaticData>(json);

            if (staticData != null )
            {
                if (staticData.MediaStatus != null)
                {
                    foreach (var item in staticData.MediaStatus)
                    {
                        var entity = new MediaStatusEntity { ID = item.Id, Name = item.Name, Key = item.Key };
                        connection.Insert(entity);
                    }
                }

                if (staticData.MediaType != null)
                {
                    foreach (var item in staticData.MediaType)
                    {
                        var entity = new MediaTypeEntity { ID = item.Id, Name = item.Name, Key = item.Key };
                        connection.Insert(entity);
                    }
                }

                if (staticData.FavoriteMusic != null)
                {
                    foreach (var item in staticData.FavoriteMusic)
                    {
                        var entity = new FavoriteMusicEntity { ID = item.Id, Name = item.Name, Key = item.Key };
                        connection.Insert(entity);
                    }
                }

                if (staticData.FavoriteSport != null)
                {
                    foreach (var item in staticData.FavoriteSport)
                    {
                        var entity = new FavoriteSportEntity { ID = item.Id, Name = item.Name, Key = item.Key };
                        connection.Insert(entity);
                    }
                }
            }
        }

        private void CreateTables(SQLite.SQLiteConnection connection)
        {
            connection.CreateTable<MediaStatusEntity>();
            connection.CreateTable<MediaTypeEntity>();
            connection.CreateTable<VersionEntity>();
            connection.CreateTable<FavoriteMusicEntity>();
            connection.CreateTable<FavoriteSportEntity>();

        }

        private void TruncateTables(SQLite.SQLiteConnection connection)
        {
            connection.DeleteAll<MediaStatusEntity>();
            connection.DeleteAll<MediaTypeEntity>();
            connection.DeleteAll<VersionEntity>();
            connection.DeleteAll<FavoriteMusicEntity>();
            connection.DeleteAll<FavoriteSportEntity>();
        }

        public ICollection<MediaTypeEntity> GetAllMediaTypes()
        {
            var connection = sqlLiteConnection.GetConnection();
            return connection.Table<MediaTypeEntity>().ToArray();
        }

        public ICollection<MediaStatusEntity> GetAllMediaStatus()
        {
            var connection = sqlLiteConnection.GetConnection();
            return connection.Table<MediaStatusEntity>().ToArray();
        }

        public ICollection<FavoriteMusicEntity> GetAllFavoriteMusic()
        {
            var connection = sqlLiteConnection.GetConnection();
            return connection.Table<FavoriteMusicEntity>().ToArray();
        }

        public ICollection<FavoriteSportEntity> GetAllFavoriteSports()
        {
            var connection = sqlLiteConnection.GetConnection();
            return connection.Table<FavoriteSportEntity>().ToArray();
        }

        public class StaticData
        {
            public String Version { get; set; }
            public List<StaticObject> MediaType { get; set; }
            public List<StaticObject> MediaStatus { get; set; }
            public List<StaticObject> FavoriteMusic { get; set; }
            public List<StaticObject> FavoriteSport { get; set; }

        }

        public class StaticObject
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Key { get; set; }
        }

    }
}
