using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.LocalDatabase.Entities;

namespace URSpot.Core.Api.LocalDatabase
{
    public interface IUserRepository
    {
        /// <summary>
        /// Save user entity to LocalStorage 
        /// </summary>
        void SaveUser(UserEntity user);
        /// <summary>
        /// Get current user
        /// </summary>
        UserEntity GetUser();
        void UpdateUserImage(string url);
        void ClearUser();
    }

    public class UserRepository : IUserRepository
    {

        private ISqlLiteConnection sqlLiteConnection;
        public UserRepository(ISqlLiteConnection sqlLiteConnection)
        {
            this.sqlLiteConnection = sqlLiteConnection;

            this.sqlLiteConnection.GetConnection().CreateTable<UserEntity>();
        }

        public UserEntity GetUser()
        {
            return this.sqlLiteConnection.GetConnection().Table<UserEntity>().FirstOrDefault();
        }

        public void SaveUser(UserEntity user)
        {
            //upsert - we make sure that there is only one user in the local database.
            this.sqlLiteConnection.GetConnection().DeleteAll<UserEntity>();
            this.sqlLiteConnection.GetConnection().InsertOrReplace(user);
        }

        public void ClearUser()
        {
            this.sqlLiteConnection.GetConnection().DeleteAll<UserEntity>();
        }

        public void UpdateUserImage(string url)
        {
            var currentUser = this.GetUser();
            if (currentUser != null)
            {
                currentUser.DisplayImageUrl = url;
                this.SaveUser(currentUser);
            }
        }
    }
}
