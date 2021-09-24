using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace DataImporter.Core
{
  public class DataImporterService : IDataImporterService
  {
		ProductsEntities context;
		int SheetIndex = 1;
		char seperator = ',';

		public DataImporterService()
		{
			context = new ProductsEntities();
		}


		 public int ImportDataToDB()
		{
			try
			{
				DatabaseVM dbVM = GetDatabaseFromFiles();

				foreach (CompanyVM com in dbVM.CompaniesList)
				{
					Company c = new Company();

					c.Id = com.Id;
					c.Name = com.Name;
					
					context.Companies.Add(c);
					context.SaveChanges();
				}

				foreach (FeedVM fed in dbVM.FeedsList)
				{
					Feed f = new Feed();

					f.Id = fed.Id;
					f.Name = fed.Name;
				
					context.Feeds.Add(f);
					context.SaveChanges();
				}

				foreach (ProductVM prd in dbVM.ProductsList)
				{
					Product p = new Product();

					p.Name = prd.Name;
					p.Brand = prd.Brand;
					p.Description = prd.Description;
					p.CompanyId = prd.CompanyId;
					p.FeedId = prd.FeedId;

					context.Products.Add(p);
					context.SaveChanges();
				}

				

				return 1;
			} catch(Exception ex)
			{
				return -1;
			}

		}

		public DatabaseVM GetDatabaseFromFiles()
		{
			string CompanyId, FeedId, FileName;

			IEnumerable<DirectoryInfo> DirsList = Directory.GetDirectories(@"../../../TestData").Select(d => new DirectoryInfo(d));

			DatabaseVM databaseVM = new DatabaseVM();

			List<ProductVM> Productslist = new List<ProductVM>();
			List<ProductVM> list;

			foreach (var dir in DirsList)
			{
				CompanyId = dir.Name.Substring(dir.Name.IndexOf("_") + 1);

				foreach (var subdir in dir.GetDirectories())
				{
					

					FeedId = subdir.Name.Substring(subdir.Name.IndexOf("_") + 1);
					FileName = subdir.GetFiles().FirstOrDefault().FullName;
									
					list = ImportProducts(FileName, CompanyId, FeedId);
					
					

					Productslist.AddRange(list);
				}
			}
			databaseVM.ProductsList = Productslist;

			databaseVM.CompaniesList = ImportCompanies("../../../../Company.csv");
			databaseVM.FeedsList = ImportFeeds("../../../../Feed.csv");

			return databaseVM;
		}

		
		private List<ProductVM> ImportProducts(string fileName, string CompanyId, string FeedId)
		{
			List<ProductVM> prdsList= (from v in File.ReadLines(fileName).Skip(1) select ProductsFromCsv(v)).ToList<ProductVM>();

			prdsList.ForEach(a => a.FeedId = int.Parse(FeedId));
			prdsList.ForEach(a => a.CompanyId = int.Parse(CompanyId));

			return prdsList;
		}

		private List<CompanyVM> ImportCompanies(string fileName)
		{
			return (from v in File.ReadLines(fileName).Skip(1) select CompaniesFromCsv(v)).ToList<CompanyVM>();

		}

		private List<FeedVM> ImportFeeds(string fileName)
		{
			return (from v in File.ReadLines(fileName).Skip(1) select feedsFromCsv(v)).ToList<FeedVM>();
		}

		public ProductVM  ProductsFromCsv(string csvLine)
		 {			

			ProductVM ProductVM = new ProductVM();
			try
			{
				ProductVM.UniqueId = int.Parse(csvLine.Split(new char[] { seperator })[0]);
				ProductVM.Name = csvLine.Split(new char[] { seperator })[1];
				ProductVM.Brand = csvLine.Split(new char[] { seperator })[2];
				ProductVM.Description = csvLine.Split(new char[] { seperator })[3];
				
			}
			catch
			{
			}
			return ProductVM;
		}

		private CompanyVM CompaniesFromCsv(string csvLine)
		{
			CompanyVM CompanyVM = new CompanyVM();
			try
			{
				CompanyVM.Id = int.Parse(csvLine.Split(new char[] { seperator })[0]);
				CompanyVM.Name = csvLine.Split(new char[] { seperator })[1];		
			}
			catch
			{
			}
			return CompanyVM;
		}

		private FeedVM feedsFromCsv(string csvLine)
		{
			FeedVM FeedVM = new FeedVM();
			try
			{
				FeedVM.Id = int.Parse(csvLine.Split(new char[] { seperator })[0]);
				FeedVM.Name = csvLine.Split(new char[] { seperator })[1];
			}
			catch
			{
			}
			return FeedVM;
		}


	
	}
}
