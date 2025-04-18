using ConfigLibrary.DAL.Interfaces;
using ConfigLibrary.Data;
using ConfigLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.DAL.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ConfigDbContext _context;
        public ConfigRepository(ConfigDbContext context)
        {
            _context = context;
        }

        public async Task<List<Storage>> GetAllAsync()
        {
           return  await _context.Configs.ToListAsync();
        }
        public async Task<Storage?> GetByIdAsync(Guid id)
        {
            return await _context.Configs.FindAsync(id);
        }
        public async Task<bool> AddAsync(Storage storage)
        {
           _context.Configs.Add(storage);

           return  await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(Storage storage)
        {
           _context.Update(storage);

           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var deleteConfig = await _context.Configs.FindAsync(id);
            if (deleteConfig != null)
            {
                _context.Configs.Remove(deleteConfig);
                return await _context.SaveChangesAsync() > 0 ;
            }

            return false;
        }



    }
}
