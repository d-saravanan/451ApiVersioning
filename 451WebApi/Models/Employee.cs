using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _451WebApi.Models
{
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
