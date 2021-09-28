using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogApiTestAutomation.Test
{
    [TestClass]
    class TestProductsMethods
    {
        private string baseUrl = "https://localhost:5001/";
        [TestMethod]
        public void TestGetAllProducts()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(baseUrl + "api/products");
            restClient.Get(restRequest);
            Console.WriteLine("oi rodei");
        }
    }
}
