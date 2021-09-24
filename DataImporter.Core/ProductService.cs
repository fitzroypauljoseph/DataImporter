using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataImporter.Core
{
  public class ProductService : IProductService
  {

        ProductsEntities context;

        public ProductService()
        {
            context = new ProductsEntities();
        }

        public IEnumerable<ProductVM> GetProducts(int CompanyId, int FeedId)
        {
            return context.Products.Where(p => p.CompanyId == CompanyId && p.FeedId == FeedId)
                .Select(a => new ProductVM()
                {
                     UniqueId= a.UniqueId,
                    Name = a.Name,
                    Brand = a.Brand,
                    Description = a.Description                  
                })
                    .ToList();
        }
    }
}
