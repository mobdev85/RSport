using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Auth;
using URSpot.Core.Api.Dtos.User;
using URSpot.Core.Api.LocalDatabase.Entities;

namespace URSpot.Core.Api.Mappings
{
    public static class DtoToDbEntity
    {
        public static UserEntity ToDbEntity(this UserProfile_Dto data)
        {
            if (data == null) return null;
            UserEntity result = new UserEntity()
            {
                Age = data.Age,
                DisplayImageUrl = data.DisplayImageUrl,
                Email = data.Email,
                FavoriteMusicId = data.FavoriteMusicId,
                FavoriteSportId = data.FavoriteSportId,
                FirstName = data.FirstName,
                IsLocationVisible = data.IsLocationVisible,
                IsMale = data.IsMale,
                IsOtherGender = data.IsOtherGender,
                LastName = data.LastName,
                PhoneNumberConfirmed = data.PhoneNumberConfirmed,
                UserId = data.Id,
                Username = data.Username
            };

            return result;
        }

        public static UserEntity UpdateDbEntity(this UserProfile_Dto data, UserEntity result)
        {
            if (result == null) return result;
            result.Age = data.Age;
            result.DisplayImageUrl = data.DisplayImageUrl;
            result.Email = data.Email;
            result.FavoriteMusicId = data.FavoriteMusicId;
            result.FavoriteSportId = data.FavoriteSportId;
            result.FirstName = data.FirstName;
            result.IsLocationVisible = data.IsLocationVisible;
            result.IsMale = data.IsMale;
            result.IsOtherGender = data.IsOtherGender;
            result.LastName = data.LastName;
            result.PhoneNumberConfirmed = data.PhoneNumberConfirmed;
            result.UserId = data.Id;
            result.Username = data.Username;

            return result;
        }

        public static UserEntity ToDbEntity(this Resp_Login_Dto data)
        {
            if (data == null) return null;
            UserEntity result = new UserEntity()
            {
                Age = data.Age,
                DisplayImageUrl = data.DisplayImageUrl,
                Email = data.Email,
                FavoriteMusicId = data.FavoriteMusicId,
                FavoriteSportId = data.FavoriteSportId,
                FirstName = data.FirstName,
                IsLocationVisible = data.IsLocationVisible,
                IsMale = data.IsMale,
                IsOtherGender = data.IsOtherGender,
                LastName = data.LastName,
                PhoneNumberConfirmed = data.PhoneNumberConfirmed,
                UserId = data.Id,
                Username = data.Username,
                AuthToken = data.Token
            };

            return result;
        }

        public static UserEntity UpdateDbEntity(this Resp_Login_Dto data, UserEntity result)
        {
            if (result == null) return result;
            result.Age = data.Age;
            result.DisplayImageUrl = data.DisplayImageUrl;
            result.Email = data.Email;
            result.FavoriteMusicId = data.FavoriteMusicId;
            result.FavoriteSportId = data.FavoriteSportId;
            result.FirstName = data.FirstName;
            result.IsLocationVisible = data.IsLocationVisible;
            result.IsMale = data.IsMale;
            result.IsOtherGender = data.IsOtherGender;
            result.LastName = data.LastName;
            result.PhoneNumberConfirmed = data.PhoneNumberConfirmed;
            result.UserId = data.Id;
            result.Username = data.Username;
            result.AuthToken = data.Token;
            return result;
        }
    }
}
