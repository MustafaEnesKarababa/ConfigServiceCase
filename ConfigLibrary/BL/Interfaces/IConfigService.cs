using ConfigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.BL.Interfaces
{
    public interface IConfigService
    {
        Task<List<Storage>> GetAllAsync();
        Task<Storage?> GetByIdAsync(Guid id);

        //Task<Storage> GetByNameAsync(string applicationName); 
        // react tarafında filterlarsan burada gerek kalmayabilir, duruma göre bak !!

        Task<bool> AddAsync(Storage storage);
        Task<bool> UpdateAsync(Storage storage);
        Task<bool> DeleteAsync(Guid id);
    }
}
