using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;

namespace Services
{
    public class FakePostRepository : IRepository<Post>
    {
        public async Task<IList<Post>> GetItemsAsync()
        {
           return new List<Post>
            {
                new Post
                {
                    Title = "titolo di prova",
                    Body = "corpo del post"
                },
                 new Post
                {
                    Title = "titolo di prova",
                    Body = "corpo del post"
                }

            }
            ;
        }

        public Task<IList<Post>> GetItemsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SuppotFiltering { get { return false; } }
    }
}
