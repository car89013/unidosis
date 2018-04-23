using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Unidosis.WebApi.App_Start
{
    public class CORSHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isOrigin = request.Headers.Contains("Origin");
            var preflight = request.Method == HttpMethod.Options;

            if (isOrigin)
            {
                if (preflight)
                {
                    return Task.Factory.StartNew(() =>
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);

                        response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues("Origin")); //TODO: Check allowed domains
                        response.Headers.Add("Access-Control-Allow-Headers", request.Headers.GetValues("Access-Control-Request-Headers"));
                        response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE"); //TODOS: Check allowed http Methods for this domain

                        return response;

                    });
                }

                return base.SendAsync(request, cancellationToken)
                           .ContinueWith(t =>
                           {
                               var response = t.Result;
                               response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues("Origin"));

                               return response;
                           });
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}