using ConfigLibrary.BL.Interfaces;
using ConfigLibrary.BL.Services;
using ConfigLibrary.DAL.Repositories;
using ConfigLibrary.Data;
using ConfigLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.Extension
{
    public class ConfigurationReader
    {
        private readonly string _appName;
        private readonly int _intervalMS;
        private readonly ConcurrentDictionary<string, Storage> _cache = new();
        private readonly IConfigService _configService;

        private Timer? _refreshTimer;

        public ConfigurationReader(string applicationName, string connectionString, int refreshIntervalMs)
        {
            _appName = applicationName;
            _intervalMS = refreshIntervalMs;


            var optionBuilder = new DbContextOptionsBuilder<ConfigDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            var newDbContext = new ConfigDbContext(optionBuilder.Options);
            newDbContext.Database.EnsureCreated();
            var newRepository = new ConfigRepository(newDbContext);
            _configService = new ConfigService(newRepository);

            LoadConfigs().Wait(); //await
            StartRefreshLoop();
        }


        /// <summary>
        /// Kullanıcı ConfigurationReader ı newlediği zaman applicationName ve isActive durumlarına bakarak ilgili configi alıp cache atar
        /// </summary>
        private async Task LoadConfigs()
        {
            var configs = await _configService.GetAllAsync();
            var filteredConfigs = configs
                                    .Where(x => x.ApplicationName == _appName
                                             && x.IsActive == true)
                                    .ToList();

            foreach (var config in filteredConfigs)
            {
                _cache[config.Name] = config;
            }

        }
        /// <summary>
        /// ConfigurationReader kullanılırken bir interval gelecek. Ona göre LoadConfig i çağırıp cache i günceller
        /// </summary>
        private void StartRefreshLoop()
        {
            _refreshTimer = new Timer(
                async x => await LoadConfigs(),
                null,
                _intervalMS,
                _intervalMS);
        }

        /// <summary>
        /// Kullanıcı type ı belirli olmayan bir key gönderir. Gelen Keye göre cache de tutulan config in value değeri alınır ve type ne ise ona dönüştürülmeye çalıştırılır. Parse başarılı olursa value o tiple geri döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public object? GetValue(string key)
        {
            try
            {
                if (_cache.TryGetValue(key, out var config) && config.Value != null) 
                {
                  
                    if(config.Type.ToLower() == "string")
                    {
                        return config.Value;
                    }
                    //if (config.Type.ToLower() == "bool")
                    //{
                    //    return bool.TryParse(config.Value, out var b) ? b : null;
                    //}
                    if(config.Type == "bool" || config.Type == "boolean")
                    {
                        if(config.Value == "1" || config.Value == "true")
                        {
                            return true;
                        }
                        else if(config.Value == "0" || config.Value == "false")
                        {
                            return false;
                        }
                    }
                    if (config.Type.ToLower() == "int")
                    {
                        return int.TryParse(config.Value,out var i) ? i : null; 
                    }
                    if (config.Type.ToLower() == "double")
                    {
                        return double.TryParse(config.Value,out var d) ? d : null;
                    }
                    if (config.Type.ToLower() == "float")
                    {
                        return float.TryParse(config.Value, out var f) ? f : null;
                    }

                }
                //todo :buralara exeption yaz
                return null;
            }
            catch
            {
                //todo : exp yaz
                return null;
            }
        }






    }
}
