using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using Flurl.Http;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace CommunityTools.Proxy.Common
{
    public class CommonHttpResponse
    {
        private const string IdIsMissingTemplate = "Validation failed. Id is required on this action.{0}{1}";
        private const string IdFromUrlMismatchTemplate = "Validation failed. Id in the BODY must match Id from the URL.{0}{1}";
        private const string InvalidModelStateResponseTemplate = "Validation failed. The model state is invalid.";
        private const string GenericExceptionResponseTemplate = "{0}";
        private const string FlurlExceptionResponseTemplate = "{0}";
        private const string ParameterIsNullResponseTemplate = "Validation failed. Parameter body must not be null.{0}{1}";

        private static StringContent CreateStringContent(object value)
        {
            return new StringContent(JsonConvert.SerializeObject(value));
        }

        public static HttpResponseMessage GenericExceptionResponse(Exception ex, HttpRequestMessage request = null)
        {
            var details = "An error has occured.";

            if (request != null)
            {
                // Will show detailed error message useful for developers / debuggers.
                if (request.Headers.Contains("X-Debug"))
                {
                    details = ex.Message;
                }
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = CreateStringContent(
                    new
                    {
                        details = string.Format(GenericExceptionResponseTemplate, details),
                        exceptionType = ex.GetType().Name
                    })
            };
        }

        public static HttpResponseMessage FlurlExceptionResponse(FlurlHttpException ex, HttpRequestMessage request = null)
        {
            var details = "An error has occured on an external request.";

            if (request != null)
            {
                // Will show detailed error message useful for developers / debuggers.
                if (request.Headers.Contains("X-Debug"))
                {
                    details = ex.Call.Response.Content.ReadAsStringAsync().Result;
                }
            }

            return new HttpResponseMessage
            {
                StatusCode = ex.Call.Response.StatusCode,
                Content = CreateStringContent(
                    new
                    {
                        details = string.Format(FlurlExceptionResponseTemplate, details),
                        exceptionType = ex.GetType().Name,
                        callDetails = ex.Message
                    })
            };
        }

        public static HttpResponseMessage IdIsMissingResponse(string moreDetails = null)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = CreateStringContent(
                    new
                    {
                        details = string.Format(IdIsMissingTemplate, moreDetails == null ? "" : " ", moreDetails)
                    })
            };
        }

        public static HttpResponseMessage IdFromUrlMismatchResponse(string moreDetails = null)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = CreateStringContent(
                    new
                    {
                        details = string.Format(IdFromUrlMismatchTemplate, moreDetails == null ? "" : " ", moreDetails)
                    })
            };
        }

        public static HttpResponseMessage InvalidModelStateResponse(ModelStateDictionary modelState)
        {
            var errStrings = new List<string>();

            modelState.Values.ForEach(v => v.Errors.ForEach(e => errStrings.Add(e.ErrorMessage != "" ? e.ErrorMessage : e.Exception.Message)));

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = CreateStringContent(
                    new
                    {
                        details = InvalidModelStateResponseTemplate,
                        modelStateErrors = errStrings
                    })
            };
        }

        public static HttpResponseMessage ParameterIsNullResponse(Type type, string moreDetails = null)
        {
            var entityType = type != null ? type.Name : "Type is undefined.";

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = CreateStringContent(
                    new
                    {
                        details = string.Format(ParameterIsNullResponseTemplate, moreDetails == null ? "" : " ", moreDetails),
                        type = entityType,
                        typeModel = type != null ? Activator.CreateInstance(type) : "Type is undefined."
                    })
            };
        }
    }
}