using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace TechTaskWG.Client.Component
{
    public class ComponentCtrl
    {
        private static HttpClient client;
        private static readonly string serverUrl = Properties.Settings.Default.ServerUrl;

        public static string Save(DTO.Component component)
        {
            string message;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                HttpResponseMessage response;

                if (component.Id > 0)
                {
                    //response = await client.PutAsJsonAsync("product/" + product.Id, product);
                    response = client.PutAsJsonAsync("component", component).Result;
                }
                else
                {
                    var serializedComponent = JsonConvert.SerializeObject(component);
                    var content = new StringContent(serializedComponent, Encoding.UTF8, "application/json");
                    response = client.PostAsync("component", content).Result;
                }

                message = response.IsSuccessStatusCode ? "Operação realizada com sucesso!" : "Falha ao realizar a operação: " + response.StatusCode;
            }

            return message;
        }

        public static List<DTO.Component> GetAll()
        {
            List<DTO.Component> components = null;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                using (var response = client.GetAsync("product").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        components = JsonConvert.DeserializeObject<DTO.Component[]>(jsonString).ToList();
                    }
                }
            }

            return components;
        }

        public static DTO.Component GetById(int Id)
        {
            DTO.Component component = null;

            using (client = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.ServerUrl) })
            {
                HttpResponseMessage response = client.GetAsync("product/" + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    component = JsonConvert.DeserializeObject<DTO.Component>(jsonString);
                }

                return component;
            }
        }

        public static string Delete(int Id)
        {
            string message;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                HttpResponseMessage response = client.DeleteAsync("product/" + Id).Result;

                message = response.IsSuccessStatusCode ? "Operação realizada com sucesso" : "Falha ao excluir o produto: " + response.StatusCode;
            }

            return message;
        }
    }
}
