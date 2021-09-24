using System;
using System.Collections.Generic;

#nullable disable

namespace DataImporter.ConsoleApp.Models
{
    public partial class Product
    {
        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int FeedId { get; set; }
    }
}
