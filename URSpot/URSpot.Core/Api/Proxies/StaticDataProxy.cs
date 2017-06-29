using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Exceptions;
using URSpot.Core.Api.LocalDatabase;
using URSpot.Core.Models.Misc;
using URSpot.Core.Statics;

namespace URSpot.Core.Api.Proxies
{
    public interface IStaticDataProxy : IBaseProxy
    {
        Task<ResponseEnvelope<string>> SyncDataAsync();
        Task<ResponseEnvelope<List<LookupModel>>> GetAllMediaStatusAsync();
        Task<ResponseEnvelope<List<LookupModel>>> GetMediaTypesAsync();
        Task<ResponseEnvelope<List<LookupModel>>> GetAllFavoriteSportsAsync();
        Task<ResponseEnvelope<List<LookupModel>>> GetAllFavoriteMusicAsync();

        Task<ResponseEnvelope<LookupModel>> GetFavoriteSportByIdAsync(long id);
        Task<ResponseEnvelope<LookupModel>> GetFavoriteMusicByIdAsync(long id);

    }
    public class StaticDataProxy : BaseProxy, IStaticDataProxy
    {
        #region Private members

        private IStaticDataRepository staticDataRepository;

        #endregion

        #region Constructors

        public StaticDataProxy(IStaticDataRepository repository) : base()
        {
            this.staticDataRepository = repository;
        }



        #endregion

        #region Helper methods

        private async Task<string> GetStaticDataAsync(string version)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Statics.WebApi.JsonUrlBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await client.GetAsync(WebApi.JsonNamePrefix + version))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Server error");
                }

                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    return result;
                }
            }

        }
        #endregion

        #region Methods

        public async Task<ResponseEnvelope<List<LookupModel>>> GetAllMediaStatusAsync()
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllMediaStatus();
                if (dbResponse == null) return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<List<LookupModel>>.SuccessAsync(dbResponse.Select(s => new LookupModel()
                {
                    Id = s.ID,
                    Key = s.Key,
                    Name = s.Name
                }).ToList());
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<LookupModel>>> GetMediaTypesAsync()
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllMediaTypes();
                if (dbResponse == null) return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<List<LookupModel>>.SuccessAsync(dbResponse.Select(s => new LookupModel()
                {
                    Id = s.ID,
                    Key = s.Key,
                    Name = s.Name
                }).ToList());
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }



        public async Task<ResponseEnvelope<string>> SyncDataAsync()
        {
            try
            {
                var versionResponse = await this.ClientApi.GetRequestAsync<string>(WebApi.ApiStaticDataVersion);
                if(versionResponse.Ack == AckCode.SUCCESS)
                {
                    var jsonString = await this.GetStaticDataAsync(versionResponse.Data);
                    if (string.IsNullOrEmpty(jsonString) == false)
                    {
                        this.staticDataRepository.SyncronizeDatabase(versionResponse.Data, jsonString);
                        return await ResponseEnvelope<string>.SuccessAsync(string.Empty);

                    }
                }
                return await ResponseEnvelope<string>.ErrorAsync(string.Empty);
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

        public async Task<ResponseEnvelope<List<LookupModel>>> GetAllFavoriteSportsAsync()
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllFavoriteSports();
                if (dbResponse == null) return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<List<LookupModel>>.SuccessAsync(dbResponse.Select(s => new LookupModel()
                {
                    Id = s.ID,
                    Key = s.Key,
                    Name = s.Name
                }).ToList());
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<List<LookupModel>>> GetAllFavoriteMusicAsync()
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllFavoriteMusic();
                if (dbResponse == null) return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<List<LookupModel>>.SuccessAsync(dbResponse.Select(s => new LookupModel()
                {
                    Id = s.ID,
                    Key = s.Key,
                    Name = s.Name
                }).ToList());
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<List<LookupModel>>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<LookupModel>> GetFavoriteSportByIdAsync(long id)
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllFavoriteSports();
                if (dbResponse == null) return await ResponseEnvelope<LookupModel>.ErrorAsync(INVALID_DATA);
                var selectedResponse = dbResponse.Where(d => d.ID == id).FirstOrDefault();
                if(selectedResponse==null) return await ResponseEnvelope<LookupModel>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<LookupModel>.SuccessAsync( new LookupModel()
                {
                    Id = selectedResponse.ID,
                    Key = selectedResponse.Key,
                    Name = selectedResponse.Name
                });
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<LookupModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<LookupModel>> GetFavoriteMusicByIdAsync(long id)
        {
            try
            {
                var dbResponse = this.staticDataRepository.GetAllFavoriteMusic();
                if (dbResponse == null) return await ResponseEnvelope<LookupModel>.ErrorAsync(INVALID_DATA);
                var selectedResponse = dbResponse.Where(d => d.ID == id).FirstOrDefault();
                if (selectedResponse == null) return await ResponseEnvelope<LookupModel>.ErrorAsync(INVALID_DATA);
                return await ResponseEnvelope<LookupModel>.SuccessAsync(new LookupModel()
                {
                    Id = selectedResponse.ID,
                    Key = selectedResponse.Key,
                    Name = selectedResponse.Name
                });
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<LookupModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        #endregion
    }
}
