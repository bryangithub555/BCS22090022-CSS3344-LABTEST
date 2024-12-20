using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCS22090022.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BCS22090022.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        // Get Posts
        public async Task<List<PostRecord>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("posts");
            var posts = new List<PostRecord>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PostRecord>>(json);
            }
            return new List<PostRecord>();
        }

        // Post a new Post
        public async Task<PostRecord> CreatePostAsync(PostRecord newPost)
        {
            var json = JsonSerializer.Serialize(newPost);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("posts", content);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PostRecord>(responseJson);
            }
            return null;
        }
    }

}
