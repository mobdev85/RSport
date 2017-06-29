using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api
{

    public enum AckCode
    {
        SUCCESS, ERROR, FAILURE, NOTFOUND, UNAUTHORIZED
    }

    public class ResponseEnvelope<T>
    {
        public T Data { get; set; }

        public AckCode Ack { get; set; }

        public String Message { get; set; }

        public Exception Exception { get; set; }

        public static ResponseEnvelope<T> Success(T data)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.SUCCESS,
                Data = data
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> SuccessAsync(T data)
        {
            return await Task.Run(() =>
            {
                return Success(data);
            });

        }

        public static ResponseEnvelope<T> Error(String message, Exception ex = null)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.ERROR,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> ErrorAsync(String message, Exception ex = null)
        {
            return await Task.Run(() =>
            {
                return Error(message, ex);
            });

        }

        public static ResponseEnvelope<T> Error(Exception exception)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.ERROR,
                Message = exception.Message
            };
            return response;
        }

        public static ResponseEnvelope<T> BadRequest(String message, Exception ex = null)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.FAILURE,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> BadRequestAsync(String message, Exception ex = null)
        {
            return await Task.Run(() =>
            {
                return BadRequest(message, ex);
            });

        }

        public static ResponseEnvelope<T> NotFound(String message, Exception ex = null)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.NOTFOUND,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> NotFoundAsync(String message, Exception ex = null)
        {
            return await Task.Run(() =>
            {
                return NotFound(message, ex);
            });

        }

        public static ResponseEnvelope<T> UnAuthorized(String message, Exception ex = null)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.UNAUTHORIZED,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> UnAuthorizedAsync(String message, Exception ex = null)
        {
            return await Task.Run(() =>
            {
                return UnAuthorized(message, ex);
            });

        }

    }
}
