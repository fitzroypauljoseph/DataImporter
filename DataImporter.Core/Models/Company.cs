using System;
using System.Collections.Generic;

#nullable disable

namespace DataImporter.Core.Models
{
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
              
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
