using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Friend;
using URSpot.Core.Api.Dtos.Misc;
using URSpot.Core.Api.Exceptions;
using URSpot.Core.Api.LocalDatabase;
using URSpot.Core.Models.Friend;
using URSpot.Core.Statics;
using URSpot.Core.Api.Mappings;

namespace URSpot.Core.Api.Proxies
{
    public interface IFriendProxy
    {
        Task<ResponseEnvelope<List<FriendModel>>> CheckPeopleUsingTheAppByPhoneNumberAsync(List<string> phoneNumbers);
        Task<ResponseEnvelope<List<FriendModel>>> CheckPeopleUsingTheAppByEmailAsync(List<string> emails);
        Task<ResponseEnvelope<string>> InviteUserToUseAppByEmailAsync(string email);
        Task<ResponseEnvelope<string>> InviteUserToUseAppBySMSAsync(string phoneNumber);

        Task<ResponseEnvelope<FriendDetailsModel>> GetFriendProfileAsync(long id);
        Task<ResponseEnvelope<List<FriendModel>>> GetAllFriendsAsync();
        Task<ResponseEnvelope<List<FriendModel>>> GetNearbyFriendsAsync(decimal latitude, decimal longitude);
        Task<ResponseEnvelope<FriendProfileForCurrentUserModel>> GetMyFriendProfileAsync();


        Task<ResponseEnvelope<FriendRequestModel>> SendFriendRequestAsync(long userId);
        Task<ResponseEnvelope<FriendModel>> AcceptFriendRequestAsync(long friendRequestId);
        Task<ResponseEnvelope<FriendRequestModel>> RejectFriendRequestAsync(long friendRequestId);


    }
    public class FriendProxy :  BaseProxy, IFriendProxy
    {
        #region private members
        private IFriendRepository friendRepository;
        #endregion

        #region Constructors

        public FriendProxy(IFriendRepository repository) : base()
        {
            this.friendRepository = repository;
        }

        #endregion

        #region Properties

        #endregion

        #region helper methods

        #endregion

        #region Methods

        public async Task<ResponseEnvelope<FriendModel>> AcceptFriendRequestAsync(long friendRequestId)
        {
            try
            {
                if (friendRequestId == 0) return await ResponseEnvelope<FriendModel>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<long> dto = new SimpleDataWrapper_Dto<long>() { Data = friendRequestId };
                var response = await this.ClientApi.PostJsonRequestAsync<Friend_Dto, SimpleDataWrapper_Dto<long>>(WebApi.ApiAcceptFriendRequest, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<FriendModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<FriendModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<FriendModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<FriendModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<FriendModel>>> CheckPeopleUsingTheAppByEmailAsync(List<string> emails)
        {
            try
            {
                if (emails == null) return await ResponseEnvelope<List<FriendModel>>.BadRequestAsync(INVALID_DATA);
                if (emails.Count == 0) return await ResponseEnvelope<List<FriendModel>>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<List<string>> dto = new SimpleDataWrapper_Dto<List<string>>() { Data = emails };
                var response = await this.ClientApi.PostJsonRequestAsync<List<InAppUser_Dto>, SimpleDataWrapper_Dto<List<string>>>(WebApi.ApiCheckPeopleUsingAppByEmail, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    if (response.Data == null) response.Data = new List<InAppUser_Dto>();
                    return await ResponseEnvelope<List<FriendModel>>.SuccessAsync(response.Data.Select(s=> s.ToModel()).ToList());
                }

                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<FriendModel>>> CheckPeopleUsingTheAppByPhoneNumberAsync(List<string> phoneNumbers)
        {
            try
            {
                if (phoneNumbers == null) return await ResponseEnvelope<List<FriendModel>>.BadRequestAsync(INVALID_DATA);
                if (phoneNumbers.Count == 0) return await ResponseEnvelope<List<FriendModel>>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<List<string>> dto = new SimpleDataWrapper_Dto<List<string>>() { Data = phoneNumbers };
                var response = await this.ClientApi.PostJsonRequestAsync<List<InAppUser_Dto>, SimpleDataWrapper_Dto<List<string>>>(WebApi.ApiCheckPeopleUsingAppByPhone, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    if (response.Data == null) response.Data = new List<InAppUser_Dto>();
                    return await ResponseEnvelope<List<FriendModel>>.SuccessAsync(response.Data.Select(s => s.ToModel()).ToList());
                }

                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<FriendModel>>> GetAllFriendsAsync()
        {
            try
            {
                var response = await this.ClientApi.PostJsonRequestAsync<FriendsRelated_Dto, object>(WebApi.ApiAllFriendsRelated,null);

                if (response.Ack == AckCode.SUCCESS)
                {
                    List<FriendModel> result = new List<FriendModel>();
                    if(response.Data != null)
                    {
                        if(response.Data.Suggestions != null)
                        {
                            result.AddRange(response.Data.Suggestions.Select(s => s.ToModel()));
                        }
                        if (response.Data.FriendRequests != null)
                        {
                            result.AddRange(response.Data.FriendRequests.Select(s => s.ToModel()));
                        }
                        if (response.Data.Friends != null)
                        {
                            result.AddRange(response.Data.Friends.Select(s => s.ToModel()));
                        }
                    }
                    return await ResponseEnvelope<List<FriendModel>>.SuccessAsync(result);
                }

                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<FriendDetailsModel>> GetFriendProfileAsync(long id)
        {
            try
            {
                if (id == 0) return await ResponseEnvelope<FriendDetailsModel>.BadRequestAsync(INVALID_DATA);
                var response = await this.ClientApi.GetRequestAsync<FriendProfile_Dto>(string.Format("{0}{1}",WebApi.ApiFriendProfile, id));

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<FriendDetailsModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<FriendDetailsModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<FriendDetailsModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<FriendDetailsModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<FriendProfileForCurrentUserModel>> GetMyFriendProfileAsync()
        {
            try
            {
                var response = await this.ClientApi.GetRequestAsync<FriendProfile_Dto>(WebApi.ApiMyProfile);

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<FriendProfileForCurrentUserModel>.SuccessAsync(response.Data.ToCurrentUserProfileModel());
                }

                return await ResponseEnvelope<FriendProfileForCurrentUserModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<FriendProfileForCurrentUserModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<FriendProfileForCurrentUserModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<FriendModel>>> GetNearbyFriendsAsync(decimal latitude, decimal longitude)
        {
            try
            {
                var response = await this.ClientApi.GetRequestAsync<List<Friend_Dto>>(string.Format("{0}?latitude={1}&longitude={2}", WebApi.ApiNearbyFriends, latitude, longitude));

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<List<FriendModel>>.SuccessAsync(response.Data.Select(s=>s.ToModel()).ToList());
                }

                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<FriendModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<string>> InviteUserToUseAppByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<string> dto = new SimpleDataWrapper_Dto<string>() { Data = email };
                var response = await this.ClientApi.PostJsonRequestAsync<string, SimpleDataWrapper_Dto<string>>(WebApi.ApiInvitePeopleToUseTheAppByEmail, dto);

                return response;
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<string>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<string>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<string>> InviteUserToUseAppBySMSAsync(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber)) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<string> dto = new SimpleDataWrapper_Dto<string>() { Data = phoneNumber };
                var response = await this.ClientApi.PostJsonRequestAsync<string, SimpleDataWrapper_Dto<string>>(WebApi.ApiInvitePeopleToUseTheAppBySMS, dto);

                return response;
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<string>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<string>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<FriendRequestModel>> RejectFriendRequestAsync(long friendRequestId)
        {
            try
            {
                if (friendRequestId == 0) return await ResponseEnvelope<FriendRequestModel>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<long> dto = new SimpleDataWrapper_Dto<long>() { Data = friendRequestId };
                var response = await this.ClientApi.PostJsonRequestAsync<FriendRequest_Dto, SimpleDataWrapper_Dto<long>>(WebApi.ApiRejectFriendRequest, dto);

                return await ResponseEnvelope<FriendRequestModel>.SuccessAsync(response.Data.ToFriendRequestModel());
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<FriendRequestModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<FriendRequestModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<FriendRequestModel>> SendFriendRequestAsync(long userId)
        {
            try
            {
                if (userId == 0) return await ResponseEnvelope<FriendRequestModel>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<long> dto = new SimpleDataWrapper_Dto<long>() { Data = userId };
                var response = await this.ClientApi.PostJsonRequestAsync<FriendRequest_Dto, SimpleDataWrapper_Dto<long>>(WebApi.ApiSendFriendRequest, dto);

                return await ResponseEnvelope<FriendRequestModel>.SuccessAsync(response.Data.ToFriendRequestModel());
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<FriendRequestModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<FriendRequestModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        #endregion
    }
}
