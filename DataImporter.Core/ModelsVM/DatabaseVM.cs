using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Core.Models
{
    public class DatabaseVM
    {

       public List<ProductVM> ProductsList { get; set; }
        public List<CompanyVM> CompaniesList { get; set; }
        public List<FeedVM> FeedsList { get; set; }


        public DatabaseVM()
        {
            ProductsList = new List<ProductVM>();
            CompaniesList = new List<CompanyVM>();
            FeedsList = new List<FeedVM>();
        }

    }
}
