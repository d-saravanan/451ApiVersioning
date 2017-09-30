using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.Http.Routing;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http;
using Microsoft.Web.OData.Builder;

[assembly: OwinStartup(typeof(_451WebApi.Startup))]

namespace _451WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer(configuration);

            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
            };
            // Web API routes
            configuration.MapHttpAttributeRoutes(constraintResolver);

            configuration.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            var modelBuilder = new VersionedODataModelBuilder(configuration);
            modelBuilder.ModelConfigurations.Add(new EntityModelConfiguration());
            var models = modelBuilder.GetEdmModels();

            var odataBatchHandler = new SampleODataBatchHandler(httpServer);
            odataBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 100;
            odataBatchHandler.MessageQuotas.MaxPartsPerBatch = 100;

            // Create the versioned routes.  A route will be created for each model 
            // version created by the VersionedODataModelBuilder.            
            configuration.MapVersionedODataRoutes("odata", "odata", models, odataBatchHandler);

            configuration.AddODataQueryFilter();

            app.UseWebApi(httpServer);
        }

    }
}
