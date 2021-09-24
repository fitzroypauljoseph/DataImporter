using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Core.Models
{
    public class ProductVM
    {
        public int UniqueId { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

        public int FeedId { get; set; }

        public int CompanyId { get; set; }

    }
}
