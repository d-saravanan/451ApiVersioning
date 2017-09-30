using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData.Batch;

namespace _451WebApi
{
    internal class SampleODataBatchHandler : DefaultODataBatchHandler
    {
        private HttpServer httpServer;

        public SampleODataBatchHandler(HttpServer httpServer) : base(httpServer)
        {
            this.httpServer = httpServer;
        }

        public override Uri GetBaseUri(HttpRequestMessage request)
        {
            return base.GetBaseUri(request);
        }

        public override Task<HttpResponseMessage> ProcessBatchAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.ProcessBatchAsync(request, cancellationToken);
        }
    }
}