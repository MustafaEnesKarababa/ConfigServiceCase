using ConfigLibrary.BL.Interfaces;
using ConfigLibrary.DAL.Interfaces;
using ConfigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.BL.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public Task<List<Storage>> GetAllAsync()
        {
            return _configRepository.GetAllAsync();    
        }

        public Task<Storage?> GetByIdAsync(Guid id)
        {
           return _configRepository.GetByIdAsync(id);
        }
        public Task<bool> AddAsync(Storage storage)
        {
            return 
            _configRepository.AddAsync(storage);    
        }
        public Task<bool> UpdateAsync(Storage storage)
        {
            return (_configRepository.UpdateAsync(storage));    
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _configRepository.DeleteAsync(id);
        }    

    }
}
