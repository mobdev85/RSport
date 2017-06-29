using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Statics
{
    internal static class WebApi
    {

        public readonly static string SqliteDataBaseName = "URSpot.sqlite.2.3";
        public readonly static string JsonUrlBase = "https://urspot-dev.blob.core.windows.net/";//Test StaticData-v1.5;
        public readonly static string JsonNamePrefix = "static/StaticData-en-US-v";

        public readonly static string Baseurl = "http://urspot-dev.cloudapp.net/";
        public readonly static string HeaderAuthKey = "X-URSpot-Auth";
        public readonly static string HeaderAuthValue = "12345";



        public readonly static string ApiStaticDataVersion = "api/base/static-data-version";

        public readonly static string ApiFormsLogin = "api/accounts/forms-login";
        public readonly static string ApiForgotPassword = "api/accounts/forgot-password";
        public readonly static string ApiForgotPassword_ValidateCode = "api/accounts/forgot-password-validate-code";
        public readonly static string ApiForgotPassword_ResetPassword = "api/accounts/forgot-password-reset-password";
        public readonly static string ApiExitsUsername = "api/accounts/exists-username";
        public readonly static string ApiExitsEmail = "api/accounts/exists-email";
        public readonly static string ApiLogout = "api/accounts/logout";
        public readonly static string ApiFormsRegistration = "api/accounts/form-register";
        public readonly static string ApiSocialLogin = "api/accounts/social-login";
        public readonly static string ApiSocialRegistration = "api/accounts/social-registration";
        public readonly static string ApiSendPhoneConfirmationCode = "api/accounts/send-code";
        public readonly static string ApiConfirmPhoneNumber = "api/accounts/confirm-code";
        public readonly static string ApiUpdateProfile = "api/accounts/update-profile";

        //------------------------------------------------------------------------------
        //Media
        public readonly static string ApiGenerateSaasForMedia = "api/Media/generate-saas-for-media";
        public readonly static string ApiPublishMedia = "api/Media/publish-media";
        public readonly static string ApiDeleteMedia = "api/Media/";

        //------------------------------------------------------------------------------
        //Friends
        public readonly static string ApiCheckPeopleUsingAppByPhone = "api/friends/using-app/check-by-phone";
        public readonly static string ApiInvitePeopleToUseTheAppBySMS = "api/friends/using-app/send-invite-sms";
        public readonly static string ApiInvitePeopleToUseTheAppByEmail = "api/friends/using-app/send-invite-email";
        public readonly static string ApiCheckPeopleUsingAppByEmail = "api/friends/using-app/check-by-email";
        public readonly static string ApiFriendProfile = "api/friends/";
        public readonly static string ApiAllFriends = "api/friends/all";
        public readonly static string ApiNearbyFriends = "api/friends/nearby";
        public readonly static string ApiMyProfile = "api/friends/me";
        public readonly static string ApiSendFriendRequest = "api/friends/invite/send";
        public readonly static string ApiAcceptFriendRequest = "api/friends/invite/accept";
        public readonly static string ApiRejectFriendRequest = "api/friends/invite/reject";
        public readonly static string ApiAllFriendRequests = "api/friends/invite/all";
        public readonly static string ApiAllFriendRequestsReceived = "api/friends/invite/all/received";
        public readonly static string ApiFriendsSuggestions = "api/friends/suggestions";
        public readonly static string ApiAllFriendsRelated = "api/friends/allRelated";

    }
}
