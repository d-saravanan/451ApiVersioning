using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _451WebApi.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
    }
}