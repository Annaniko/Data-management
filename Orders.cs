using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp30.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Structure { get; set; }

        public int CustomerId { get; set; }
    }
}
