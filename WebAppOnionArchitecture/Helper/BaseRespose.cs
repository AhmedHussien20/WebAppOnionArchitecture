using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAppOnionArchitecture.Helper
{
    public enum ResponseType
    {
        Ok = 200,
        NotOk = 400,
        AuthenticationError = 401,
        ForbiddenAccessError = 403,
        NotFound = 404
    }

    public class BaseResponse<T>
    {

        public BaseResponse()
        {
            StatusCode = (int)ResponseType.Ok;
            ErrorList = new List<string>();
        }
        public T Data { get; set; }
        public string SuccessMessage { get; set; }
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        /// <see cref="ResponseType"/>
        public int StatusCode { get; set; }
        public List<string> ErrorList { get; set; }
        public object ValidationErrorList { get; set; }
        public bool IsSuccess { get; set; } = true;

        public int? TotalRecords { get; set; }


        public JsonResult GetHttpErrorResponse(ResponseType responseType, string msg)
        {
            // Added the status-code properly without changing the previous response model of the API
            this.StatusCode = (int)responseType;
            this.IsSuccess = false;
            return new JsonResult(this)
            {
                StatusCode = (int)responseType

                // The APP does not have necessary code to handle not-200 HTTP responses
                // Hence, making all the responses to have 200 status even though these were caused by some erroneous requests
                // StatusCode = (int)ResponseType.Ok
            };
        }

        public JsonResult GetHttpResponse(ResponseType responseType)
        {
            // Added the status-code properly without changing the previous response model of the API
            this.StatusCode = (int)responseType;
            this.IsSuccess = ((int)responseType == 200) ? true : false;
            return new JsonResult(this)
            {
                StatusCode = (int)responseType

                // The APP does not have necessary code to handle not-200 HTTP responses
                // Hence, making all the responses to have 200 status even though these were caused by some erroneous requests
                // StatusCode = (int)ResponseType.Ok
            };
        }
    }
    public class BaseResponse : BaseResponse<object>
    {

    }
}
