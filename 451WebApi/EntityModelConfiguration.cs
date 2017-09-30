using _451WebApi.Models;
using Microsoft.Web.Http;
using Microsoft.Web.OData.Builder;
using System.Web.OData.Builder;

namespace _451WebApi
{
    public class EntityModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.Namespace = "Core";

            builder.EntitySet<Employee>("Employees");
            //builder.EntitySet<Address>("Address");

            switch (apiVersion.MajorVersion)
            {
                default:
                case 1:
                    builder.EntitySet<Address>("Address");
                    break;
            }

            //switch (apiVersion.MajorVersion)
            //{
            //    case 1:
            //        break;
            //    case 2:
            //        builder.EntitySet<V2.Employee>("Employees");
            //        break;
            //    case 3:
            //        builder.EntitySet<V3.Employee>("Employees");
            //        builder.EntitySet<V3.EmployeeType>("EmployeeTypes");
            //        break;
            //}
        }

    }
}