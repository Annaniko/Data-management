using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp30.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }
    }
  
}
