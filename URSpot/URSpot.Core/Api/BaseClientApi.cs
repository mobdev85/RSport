using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Exceptions;

namespace URSpot.Core.Api
{
    public abstract class BaseClientApi
    {
        protected HttpClient Client { set; get; }

        public BaseClientApi(string baseUrl)
        {
            Client = new HttpClient(); //handler
            Client.BaseAddress = new Uri(baseUrl);
        }

        protected abstract void PrepareAuthorizeData();

        protected bool ExistInternet
        {
            get { return true/*CrossConnectivity.Current.IsConnected*/; }
        }

        private async Task<ResponseEnvelope<TResponse>> HandleResponseAsync<TResponse>(HttpResponseMessage response)
        {
            string result;
            using (var content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                return await ResponseEnvelope<TResponse>.BadRequestAsync(dataResponse.Messages.FirstOrDefault());
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                return await ResponseEnvelope<TResponse>.UnAuthorizedAsync(dataResponse.Messages.FirstOrDefault());
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                return await ResponseEnvelope<TResponse>.ErrorAsync(dataResponse.Messages.FirstOrDefault());
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                return await ResponseEnvelope<TResponse>.NotFoundAsync(dataResponse.Messages.FirstOrDefault());
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Server error");
            }
            return await ResponseEnvelope<TResponse>.SuccessAsync(JsonConvert.DeserializeObject<TResponse>(result));
        }

        public async Task<ResponseEnvelope<TResponse>> PostJsonRequestWithParamsAsync<TResponse>(string url, List<KeyValuePair<string, object>> param)
        {
            PrepareAuthorizeData();

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            var serializedParams = new List<KeyValuePair<string, string>>();
            foreach (var p in param)
            {
                serializedParams.Add(new KeyValuePair<string, string>(p.Key, JsonConvert.SerializeObject(p.Value)));
            }
            var serializedData = new FormUrlEncodedContent(serializedParams);


            var message = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = serializedData
            };
            using (var response = await Client.SendAsync(message))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public async Task<ResponseEnvelope<TResponse>> GetRequestAsync<TResponse>(string url) where TResponse : class
        {

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            //authorize
            PrepareAuthorizeData();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await Client.GetAsync(url))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public async Task<ResponseEnvelope<TResponse>> PostJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class
        {
            PrepareAuthorizeData();

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PostAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }
        public async Task<ResponseEnvelope<TResponse>> PostJsonRequest<TResponse, TRequest>(string url, TRequest request) where TRequest : class
        {
            PrepareAuthorizeData();

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            //authorize
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PostAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public async Task<ResponseEnvelope<TResponse>> PutBytesRequest<TResponse, TRequest>(string url, TRequest request) where TRequest : class
        {
            PrepareAuthorizeData();

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PostAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }
    }
}
