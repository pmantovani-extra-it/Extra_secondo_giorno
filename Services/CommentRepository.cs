using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services
{
    public class CommentRepository : IRepository<Comment>
    {
        public async Task<IList<Comment>> GetItemsAsync()
        {
            var httpClient = new HttpClient();
            await Task.Delay(TimeSpan.FromSeconds(5));
            var result = await httpClient.GetStringAsync(new Uri("http://jsonplaceholder.typicode.com/comments"));
            return JsonConvert.DeserializeObject<List<Comment>>(result);
        }

        public async Task<IList<Comment>> GetItemsAsync(int id)
        {
            var result = await GetItemsAsync();
            return result.Where(c => c.PostId == id).ToList();
        }

        public bool SuppotFiltering { get { return true; } }
    }
}
