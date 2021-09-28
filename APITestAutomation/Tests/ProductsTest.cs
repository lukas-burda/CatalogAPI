using APITestAutomation.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace APITestAutomation
{
    [TestClass]
    public class ProductsTest
    {
        private string baseUrl = "https://localhost:5001/";

        [TestMethod]
        public void TestGetAllProducts()
        {
            var client = new RestClient(baseUrl + "api/products");

            var request = new RestRequest(baseUrl + "api/products");

            var response = client.Get(request);

            Console.WriteLine(response.Content);

        }

        [TestMethod]
        public void TestGetProductById()
        {
            var fclient = new RestClient(baseUrl + "api/products");

            var frequest = new RestRequest(baseUrl + "api/products");

            var fresponse = fclient.Get(frequest);

            //Le o ID do da lista
            List<ProductTestModel> products = JsonConvert.DeserializeObject<List<ProductTestModel>>(fresponse.Content);

            var productId = "";

            foreach (var item in products)
            {
                productId = item.id;
            }

            var client = new RestClient(baseUrl + "api/products");

            var request = new RestRequest(baseUrl + $"api/products/{productId}");

            var response = client.Get(request);

            Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void TestPostProduct()
        {
            ProductTestModel product = new ProductTestModel(Guid.NewGuid(), "Teste01", "ProdutoTeste");

            var body = JsonConvert.SerializeObject(product);

            var client = new RestClient(baseUrl + "api/products");

            var request = new RestRequest(baseUrl + "api/products").AddJsonBody(body);

            var response =  client.Post(request);

        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            /* //Teste de update automatico 
            var fclient = new RestClient(baseUrl + "api/products");

            var frequest = new RestRequest(baseUrl + "api/products");

            var fresponse = fclient.Get(frequest);

            //Le o ID do da lista
            List<ProductTestModel> products = JsonConvert.DeserializeObject<List<ProductTestModel>>(fresponse.Content);

            var productId = "";

            foreach (var item in products)
            {
                productId = item.id;
            }
            */

            var productId = "ef7718b2-3b90-4eaa-9f1f-08d9822932ba";

            ProductTestModel product = new ProductTestModel(Guid.Parse(productId),"Teste01", "ProdutoTesteAlterado");

            var client = new RestClient(baseUrl + "api/products");

            var request = new RestRequest(baseUrl + $"api/products/{productId}").AddJsonBody(JsonConvert.SerializeObject(product));

            var response = client.Patch(request);                
         
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            var productId = "8ae73ce7-3dda-4a01-9f20-08d9822932ba";

            var client = new RestClient(baseUrl + "api/products");

            var request = new RestRequest(baseUrl + $"api/products/{productId}");

            var response = client.Delete(request);
        }
    }
}
