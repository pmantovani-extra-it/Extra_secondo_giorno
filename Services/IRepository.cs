using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetItemsAsync();
        Task<IList<T>> GetItemsAsync(int id);

        bool SuppotFiltering { get; }
    }
}
