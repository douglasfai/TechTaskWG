using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace TechTaskWG.Client.Product
{
    public static class ProductCtrl
    {
        private static HttpClient client;
        private static readonly string serverUrl = Properties.Settings.Default.ServerUrl;

        public static string Save(DTO.Product product)
        {
            string message;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                HttpResponseMessage response;

                if (product.Id > 0)
                {
                    //response = await client.PutAsJsonAsync("product/" + product.Id, product);
                    response = client.PutAsJsonAsync("product", product).Result;
                }
                else
                {
                    var serializedProduct = JsonConvert.SerializeObject(product);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    response = client.PostAsync("product", content).Result;
                }

                message = response.IsSuccessStatusCode ? "Operação realizada com sucesso!" : "Falha ao realizar a operação: " + response.StatusCode;                                
            }

            return message;
        }

        public static List<DTO.Product> GetAll()
        {
            List<DTO.Product> products = null;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                using (var response = client.GetAsync("product").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        products = JsonConvert.DeserializeObject<DTO.Product[]>(jsonString).ToList();
                    }
                }
            }

            return products;
        }

        public static DTO.Product GetById(int Id)
        {
            DTO.Product product = null;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                HttpResponseMessage response = client.GetAsync("product/" + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<DTO.Product>(jsonString);
                }

                return product;
            }
        }

        public static string Delete(int Id)
        {
            string message;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                HttpResponseMessage response = client.DeleteAsync("product/" + Id).Result;

                message = response.IsSuccessStatusCode ? "Operação realizada com sucesso!" : "Falha ao excluir o produto: " + response.StatusCode;                
            }

            return message;
        }
    }
}
