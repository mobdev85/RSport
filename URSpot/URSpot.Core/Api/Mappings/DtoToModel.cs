using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Auth;
using URSpot.Core.Api.Dtos.Friend;
using URSpot.Core.Api.Dtos.Media;
using URSpot.Core.Api.Dtos.User;
using URSpot.Core.Api.Proxies;
using URSpot.Core.Models.Friend;
using URSpot.Core.Models.Media;
using URSpot.Core.Models.User;

namespace URSpot.Core.Api.Mappings
{
    public static class DtoToModel
    {
        private static UserModel GetModelFromUserProfile(UserProfile_Dto data)
        {
            UserModel result = new UserModel();

            result.Age = data.Age;
            result.Email = data.Email;
            result.FavoriteSportId = data.FavoriteSportId;
            result.FavoriteMusicId = data.FavoriteMusicId;
            result.FirstName = data.FirstName;
            result.LastName = data.LastName;
            result.PhoneNumberConfirmed = data.PhoneNumberConfirmed;
            result.ShareLocation = data.IsLocationVisible;
            result.Id = data.Id;
            result.Username = data.Username;

            var staticDataProxy = Mvx.Resolve<IStaticDataProxy>();

            if (result.FavoriteSportId.HasValue)
            {
                var favoriteSport = staticDataProxy.GetFavoriteSportByIdAsync(result.FavoriteSportId.Value).Result;
                if (favoriteSport != null) result.FavoriteSportName = favoriteSport.Data.Name;
            }
            if (result.FavoriteMusicId.HasValue)
            {
                var favoriteMusic = staticDataProxy.GetFavoriteMusicByIdAsync(result.FavoriteMusicId.Value).Result;
                if (favoriteMusic != null) result.FavoriteMusicName = favoriteMusic.Data.Name;
            }
            return result;
        }

        public static UserModel ToModel(this UserProfile_Dto data)
        {
            return GetModelFromUserProfile(data);
        }

        public static UserModel ToModel(this Resp_Login_Dto data)
        {
            return GetModelFromUserProfile(data);
        }

        public static FriendModel ToModel(this Friend_Dto data)
        {
            //we need to define this;
            return new FriendModel();
        }

        public static FriendModel ToModel(this InAppUser_Dto data)
        {
            //we need to define this;
            return new FriendModel();
        }

        public static FriendModel ToModel(this FriendRequest_Dto data)
        {
            //we need to define this;
            return new FriendModel();
        }

        public static FriendDetailsModel ToModel(this FriendProfile_Dto data)
        {
            //we need to define this;
            return new FriendDetailsModel();
        }

        public static FriendProfileForCurrentUserModel ToCurrentUserProfileModel(this FriendProfile_Dto data)
        {
            //we need to define this;
            return new FriendProfileForCurrentUserModel();
        }

        public static FriendRequestModel ToFriendRequestModel(this FriendRequest_Dto data)
        {
            //we need to define this;
            return new FriendRequestModel();
        }

        #region Media

        public static MediaTaskModel ToModel(this MediaTask_Dto data)
        {
            MediaTaskModel result = new MediaTaskModel();
            if (data != null)
            {
                result.Id = data.Id;
                result.Filename = data.Filename;
                result.VenueId = data.PlaceId;
                result.Size = data.Size;
                result.TypeId = data.TypeId;
                result.Url = data.Url;
                result.UserId = data.UserId;
                result.UuId = data.UuId;
            }
            return result;
        }

        public static MediaModel ToModel(this MediaItem_Dto data)
        {
            MediaModel result = new MediaModel();
            if (data != null)
            {
                result.Id = data.Id;
                result.Filename = data.Filename;
                result.VenueId = data.PlaceId;
                result.Size = data.Size;
                result.TypeId = data.TypeId;
                result.Url = data.Url;
                result.UserId = data.UserId;
                result.UuId = data.UuId;
                result.ThumbnailUrl = data.ThumbnailUrl;
            }
            return result;
        }

        #endregion
    }
}
