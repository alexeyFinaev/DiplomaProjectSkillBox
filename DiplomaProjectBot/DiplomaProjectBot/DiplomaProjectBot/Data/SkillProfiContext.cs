using DiplomaProjectBot.Models.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;


namespace DiplomaProjectBot.Data
{
    class SkillProfiContext
    {
        private HttpClient Client()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => { return true; };

           

            return new HttpClient(clientHandler);
            
        }

        private readonly string url = @"https://localhost:44346/api/values";

        /// <summary>
        /// метод добавления заявки
        /// </summary>
        /// <param name="proposal"></param>
        public void AddProposal(Proposal proposal)
        {
            Client().PostAsync(requestUri: $"{url}/addproposal", content:
                new StringContent(JsonConvert.SerializeObject(proposal), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// список с проектами
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            var json = Client().GetStringAsync($"{url}/getprojects").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Project>>(json);
        }

        /// <summary>
        /// метод получения списка услуг
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetServices()
        {
            var json = Client().GetStringAsync($"{url}/getservices").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Service>>(json);
        }

        /// <summary>
        /// метод получения списка блогов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetBlogs()
        {
            var json = Client().GetStringAsync($"{url}/getblogs").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Blog>>(json);
        }

     

        
    }
}
