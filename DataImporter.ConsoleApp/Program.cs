using DataImporter.Core;
using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using System;
using System.Linq;

namespace DataImporter.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataImporterService _dataImporterService = new DataImporterService();

            Console.WriteLine("************************");
            Console.WriteLine("ImportToDb ");

            //   _dataImporterService.ImportDataToDB();

            DatabaseVM dataVM = _dataImporterService.GetDatabaseFromFiles();

            Console.WriteLine("************************");
            Console.WriteLine("Companies List: ");

            foreach (CompanyVM com in dataVM.CompaniesList.Take(5))
            {
                Console.WriteLine("Id:" + com.Id);
                Console.WriteLine("Name:" + com.Name);
            }
            Console.WriteLine("************************");
            Console.WriteLine("Feeds List: ");

            foreach (FeedVM fed in dataVM.FeedsList.Take(5))
            {
                Console.WriteLine("Id:" + fed.Id);
                Console.WriteLine("Name:" + fed.Name);
            }
            Console.WriteLine("************************");
            Console.WriteLine("Products List: ");

            foreach (ProductVM prd in dataVM.ProductsList.Take(5))
            {
                Console.WriteLine("Id:" + prd.UniqueId);
                Console.WriteLine("Name:" + prd.Name);
                Console.WriteLine("Brand:" + prd.Brand);
                Console.WriteLine("Description:" + prd.Description);
            }

            Console.ReadLine();

        

        }
    }

}