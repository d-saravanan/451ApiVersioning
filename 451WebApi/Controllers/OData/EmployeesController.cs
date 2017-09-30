using _451WebApi.Models;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace _451WebApi.Controllers.OData
{
    [ApiVersion("1.0")]
    public class EmployeesController : ODataController
    {
        public IQueryable<Employee> GetEmployees() => new List<Employee>
        {
            new Employee
            {
                EmployeeId=1,
                FirstName=System.IO.Path.GetRandomFileName(),
                LastName=System.IO.Path.GetRandomFileName()
            },
            new Employee
            {
                EmployeeId=2,
                FirstName=System.IO.Path.GetRandomFileName(),
                LastName=System.IO.Path.GetRandomFileName()
            },
            new Employee
            {
                EmployeeId=3,
                FirstName=System.IO.Path.GetRandomFileName(),
                LastName=System.IO.Path.GetRandomFileName()
            }
        }.AsQueryable();

        public IQueryable<Employee> GetEmployee([FromODataUri] long key) => new List<Employee>
           {
            new Employee
            {
                EmployeeId=key,
                FirstName=System.IO.Path.GetRandomFileName(),
                LastName=System.IO.Path.GetRandomFileName()
            }
        }.AsQueryable();

        [ODataRoute("Employees({EmployeeId})")]
        public async Task<IHttpActionResult> DeleteEmployees([FromODataUri] long EmployeeId) => Ok("deleted");

        [ODataRoute("Employees({EmployeeId})/Address")]
        public IQueryable<Address> GetEmployeeAddress([FromODataUri] long key) => new List<Address>
        {
            new Address
            {
                Id = 1,
                City = System.IO.Path.GetRandomFileName(),
                CountryName = System.IO.Path.GetRandomFileName()
            },
            new Address
            {
                Id = 2,
                City = System.IO.Path.GetRandomFileName(),
                CountryName = System.IO.Path.GetRandomFileName()
            }
        }.AsQueryable();
    }
}
