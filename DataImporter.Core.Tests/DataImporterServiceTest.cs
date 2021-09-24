using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataImporter.Core.Tests
{
  [TestClass]
  public class DataImporterServiceTest
  {
    [TestMethod]
    public void CompagniesTestMethod()
    {          
            IDataImporterService _dataImporterService = new DataImporterService();

            DatabaseVM dataVM = _dataImporterService.GetDatabaseFromFiles();

            Assert.IsNotNull(dataVM.CompaniesList);
            Assert.IsTrue(dataVM.CompaniesList.Count > 0);


          
        }

        [TestMethod]
        public void FeedsTestMethod()
        {
            IDataImporterService _dataImporterService = new DataImporterService();

            DatabaseVM dataVM = _dataImporterService.GetDatabaseFromFiles();          

            Assert.IsNotNull(dataVM.FeedsList);
            Assert.IsTrue(dataVM.FeedsList.Count > 0);
       }

        [TestMethod]
        public void ProductsTestMethod()
        {
            IDataImporterService _dataImporterService = new DataImporterService();

            DatabaseVM dataVM = _dataImporterService.GetDatabaseFromFiles();

            Assert.IsNotNull(dataVM.ProductsList);
            Assert.IsTrue(dataVM.ProductsList.Count > 0);

        }


    }
}
