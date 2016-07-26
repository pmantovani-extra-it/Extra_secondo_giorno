using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using Newtonsoft.Json;

namespace Services
{
    public class RestPostRepository : IRepository<Post>
    {
        public async Task<IList<Post>> GetItemsAsync()
        {
            var httpClient = new HttpClient();
            await Task.Delay(TimeSpan.FromSeconds(5));
            var result = await httpClient.GetStringAsync(new Uri("http://jsonplaceholder.typicode.com/posts"));
            return JsonConvert.DeserializeObject<List<Post>>(result);

        }

        public Task<IList<Post>> GetItemsAsync(int id)
        {
            throw new NotSupportedException();
        }

        public bool SuppotFiltering
        {
            get { return false; }
        }
    }
}
