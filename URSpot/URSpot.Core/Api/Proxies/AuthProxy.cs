using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Auth;
using URSpot.Core.Api.Dtos.Misc;
using URSpot.Core.Api.Dtos.User;
using URSpot.Core.Api.Exceptions;
using URSpot.Core.Api.LocalDatabase;
using URSpot.Core.Api.LocalDatabase.Entities;
using URSpot.Core.Models.User;
using URSpot.Core.Statics;
using static URSpot.Core.Statics.Enums;
using URSpot.Core.Api.Mappings;

namespace URSpot.Core.Api.Proxies
{
    public interface IAuthProxy : IBaseProxy
    {
        Task<ResponseEnvelope<UserModel>> LoginAsync(string username, string password);
        Task<ResponseEnvelope<UserModel>> SocialLoginAsync(string accessToken, AuthProvider provider);
        Task<ResponseEnvelope<string>> RegisterUserUsingFormsAsync(UserModel data);
        Task<ResponseEnvelope<string>> RegisterUserUsingSocialAsync(string accessToken, AuthProvider provider);
        Task<ResponseEnvelope<string>> SendPhoneConfirmationCodeAsync(string phoneNumber);
        Task<ResponseEnvelope<string>> ConfirmPhoneNumberAsync(string code);
        Task<ResponseEnvelope<string>> LogoutAsync();
        Task<ResponseEnvelope<UserModel>> UpdateUserProfileAsync(UserModel data);
    }

    public class AuthProxy : BaseProxy, IAuthProxy
    {
        #region private members

        private IUserRepository userRepository;
        private UserEntity currentUser;

        #endregion

        #region Constructors

        public AuthProxy(IUserRepository userRepository) : base()
        {
            this.userRepository = userRepository;
        }


        #endregion

        #region Properties

        public UserModel CurrentUser
        {
            get
            {
                if (currentUser == null) currentUser = this.userRepository.GetUser();
                if (currentUser == null) return null;

                return currentUser.ToModel();
            }
        }

        #endregion

        #region helpers

        private void RefreshProxyData()
        {
            this.currentUser = this.userRepository.GetUser();
        }

        #endregion

        #region Methods

        public async Task<ResponseEnvelope<string>> ConfirmPhoneNumberAsync(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code)) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<string> dto = new SimpleDataWrapper_Dto<string>() { Data = code };
                var response = await this.ClientApi.PostJsonRequestAsync<string, SimpleDataWrapper_Dto<string>>(WebApi.ApiConfirmPhoneNumber, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    //update user data in local db
                    this.currentUser = userRepository.GetUser();
                    if (this.currentUser != null)
                    {
                        this.currentUser.PhoneNumberConfirmed = true;
                        userRepository.SaveUser(this.currentUser);
                    }
                }

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

        public async Task<ResponseEnvelope<UserModel>> LoginAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username)) return await ResponseEnvelope<UserModel>.BadRequestAsync(INVALID_DATA);
                if (string.IsNullOrEmpty(password)) return await ResponseEnvelope<UserModel>.BadRequestAsync(INVALID_DATA);
                Req_FormLogin_Dto dto = new Req_FormLogin_Dto() { Password = password, Username = username };
                var response = await this.ClientApi.PostJsonRequestAsync<UserProfile_Dto, Req_FormLogin_Dto>(WebApi.ApiFormsLogin, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    //update user data in local db
                    userRepository.ClearUser();
                    UserEntity dbUser = response.Data.ToDbEntity();
                    if (dbUser != null)
                    {
                        userRepository.SaveUser(dbUser);
                        this.RefreshProxyData();
                    }
                    return await ResponseEnvelope<UserModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<UserModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<string>> LogoutAsync()
        {
            try
            {
                var currentUser = this.userRepository.GetUser();

                if (currentUser == null) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                var response = await this.ClientApi.PostJsonRequestAsync<string, object>(WebApi.ApiLogout, null);

                if (response.Ack == AckCode.SUCCESS)
                {
                    //update user data in local db
                    userRepository.ClearUser();
                    this.RefreshProxyData();
                }
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

        public async Task<ResponseEnvelope<string>> RegisterUserUsingFormsAsync(UserModel data)
        {
            try
            {
                if (data == null) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                var response = await this.ClientApi.PostJsonRequestAsync<string, Req_FormRegister_Dto>(WebApi.ApiFormsRegistration, data.ToDto());

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

        public async Task<ResponseEnvelope<string>> RegisterUserUsingSocialAsync(string accessToken, AuthProvider provider)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken)) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                if (provider == AuthProvider.Forms) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                Req_SocialRequest_Dto dto = new Req_SocialRequest_Dto() { AccessToken = accessToken, Provider = Enum.GetName(typeof(Enums.AuthProvider), provider).ToLower() };
                var response = await this.ClientApi.PostJsonRequestAsync<string, Req_SocialRequest_Dto>(WebApi.ApiSocialRegistration, dto);

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

        public async Task<ResponseEnvelope<string>> SendPhoneConfirmationCodeAsync(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber)) return await ResponseEnvelope<string>.BadRequestAsync(INVALID_DATA);
                SimpleDataWrapper_Dto<string> dto = new SimpleDataWrapper_Dto<string>() { Data = phoneNumber };
                var response = await this.ClientApi.PostJsonRequestAsync<string, SimpleDataWrapper_Dto<string>>(WebApi.ApiSendPhoneConfirmationCode, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    //update user data in local db
                    var currentUser = userRepository.GetUser();
                    if (currentUser != null)
                    {
                        currentUser.Phone = phoneNumber;
                        userRepository.SaveUser(currentUser);
                        this.RefreshProxyData();
                    }
                }

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

        public async Task<ResponseEnvelope<UserModel>> SocialLoginAsync(string accessToken, AuthProvider provider)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken)) return await ResponseEnvelope<UserModel>.BadRequestAsync(INVALID_DATA);
                if (provider == AuthProvider.Forms) return await ResponseEnvelope<UserModel>.BadRequestAsync(INVALID_DATA);
                Req_SocialRequest_Dto dto = new Req_SocialRequest_Dto() { AccessToken = accessToken, Provider = Enum.GetName(typeof(Enums.AuthProvider), provider).ToLower() };
                var response = await this.ClientApi.PostJsonRequestAsync<UserProfile_Dto, Req_SocialRequest_Dto>(WebApi.ApiSocialLogin, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    //update user data in local db
                    userRepository.ClearUser();
                    UserEntity dbUser = response.Data.ToDbEntity();
                    if (dbUser != null)
                    {
                        userRepository.SaveUser(dbUser);
                        this.RefreshProxyData();
                    }
                    return await ResponseEnvelope<UserModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<UserModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<UserModel>> UpdateUserProfileAsync(UserModel data)
        {
            try
            {
                if (data == null) return await ResponseEnvelope<UserModel>.BadRequestAsync(INVALID_DATA);
                var response = await this.ClientApi.PostJsonRequestAsync<UserProfile_Dto, UserProfile_Dto>(WebApi.ApiUpdateProfile, data.ToProfileDto());

                if (response.Ack == AckCode.SUCCESS)
                {
                    this.currentUser = userRepository.GetUser();
                    if (this.CurrentUser == null) return await ResponseEnvelope<UserModel>.ErrorAsync(INTERNAL_ERROR);
                    var newUser = response.Data.UpdateDbEntity(currentUser);
                    //update user data in local db
                    userRepository.ClearUser();
                    userRepository.SaveUser(newUser);
                    this.RefreshProxyData();
                    return await ResponseEnvelope<UserModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<UserModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<UserModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }


        #endregion
    }
}
