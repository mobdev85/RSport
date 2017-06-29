using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Media;
using URSpot.Core.Api.Exceptions;
using URSpot.Core.Models.Media;
using URSpot.Core.Statics;
using URSpot.Core.Api.Mappings;

namespace URSpot.Core.Api.Proxies
{
    public interface IMediaProxy : IBaseProxy
    {
        Task<ResponseEnvelope<MediaTaskModel>> GenerateSaaSUrlForMediaAsync(string filename, int size, long? venueId, long? userId);
        Task<ResponseEnvelope<MediaModel>> PublishMediaAsync(Guid uuId);
    }
    public class MediaProxy : BaseProxy, IMediaProxy
    {
        #region Constructors

        public MediaProxy() : base()
        {

        }


        #endregion

        #region Methods
        public async Task<ResponseEnvelope<MediaTaskModel>> GenerateSaaSUrlForMediaAsync(string filename, int size, long? venueId, long? userId)
        {
            try
            {
                if (size == 0) return await ResponseEnvelope<MediaTaskModel>.BadRequestAsync(INVALID_DATA);
                Req_MediaTask_Dto dto = new Req_MediaTask_Dto() {
                    Filename = filename,
                    PlaceId = venueId,
                    Size = size,
                    UserId = userId
                };
                var response = await this.ClientApi.PostJsonRequestAsync<MediaTask_Dto, Req_MediaTask_Dto>(WebApi.ApiGenerateSaasForMedia, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<MediaTaskModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<MediaTaskModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<MediaTaskModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<MediaTaskModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }

        public async Task<ResponseEnvelope<MediaModel>> PublishMediaAsync(Guid uuId)
        {
            try
            {
                if (uuId == Guid.Empty) return await ResponseEnvelope<MediaModel>.BadRequestAsync(INVALID_DATA);
                Req_MediaPublish_Dto dto = new Req_MediaPublish_Dto()
                {
                   UuId = uuId
                };
                var response = await this.ClientApi.PostJsonRequestAsync<MediaItem_Dto, Req_MediaPublish_Dto>(WebApi.ApiPublishMedia, dto);

                if (response.Ack == AckCode.SUCCESS)
                {
                    return await ResponseEnvelope<MediaModel>.SuccessAsync(response.Data.ToModel());
                }

                return await ResponseEnvelope<MediaModel>.ErrorAsync(response.Message);
            }
            catch (NoInternetConnectionException)
            {
                return await ResponseEnvelope<MediaModel>.ErrorAsync(NO_INTERNET_CONNECTION);
            }
            catch (Exception ex)
            {
                return await ResponseEnvelope<MediaModel>.ErrorAsync(INTERNAL_ERROR, ex);
            }
        }
        #endregion
    }
}
