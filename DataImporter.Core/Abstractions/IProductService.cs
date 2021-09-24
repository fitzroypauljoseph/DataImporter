using DataImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Core.Abstractions
{
  public interface IProductService
  {
        IEnumerable<ProductVM> GetProducts(int CompanyId, int FeedId);
  }
}
