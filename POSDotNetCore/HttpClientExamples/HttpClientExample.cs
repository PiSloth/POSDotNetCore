using Newtonsoft.Json;
using POSDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.HttpClientExamples
{
    internal class HttpClientExample
    {
        public async Task Run ()
        {
            //await Read();
            //await Edit(1);
            //await Edit(200);
            //await Create("Kaubkii", "Testing", "Wahaha");
            //await Update(11, "Dinosaw", "Title", "SawSaw");
            await Delete(14);
        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7009/api/Blog");
            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                //string cObj = JsonConvert.SerializeObject( response);
                await Console.Out.WriteLineAsync(jsonStr);
            }
        }
        private async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =  await client.GetAsync($"https://localhost:7009/api/Blog/{id}");
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(json);
                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(json)!;
                Console.WriteLine(item.BlogId + "\n" + item.BlogAuthor + "\n" + item.BlogTitle + "\n" + item.BlogContent);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        
        private async Task Create (string author, string title, string content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                BlogAuthor = author,
                BlogContent  = content,
                BlogTitle = title
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            await Console.Out.WriteLineAsync(jsonBlog);

            HttpContent contentHttp = new StringContent (jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = $"https://localhost:7009/api/Blog";
            HttpClient client = new HttpClient();
            HttpResponseMessage response =  await client.PostAsync(url, contentHttp);
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task Update(int id,string author, string title, string content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                BlogAuthor = author,
                BlogContent = content,
                BlogTitle = title
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent contentHttp = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = $"https://localhost:7009/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, contentHttp);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task Delete(int id)
        {
            string url = $"https://localhost:7009/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync(await response.Content.ReadAsStringAsync());
            }
            else
            {
                await Console.Out.WriteLineAsync(await response.Content.ReadAsStringAsync());
            }

        }

    }
}
