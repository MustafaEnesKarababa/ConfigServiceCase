﻿using ConfigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.DAL.Interfaces
{
    public interface IConfigRepository
    {
        Task<List<Storage>> GetAllAsync();
        Task<Storage?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(Storage storage);
        Task<bool> UpdateAsync(Storage storage);
        Task<bool> DeleteAsync(Guid id);
    }
}
