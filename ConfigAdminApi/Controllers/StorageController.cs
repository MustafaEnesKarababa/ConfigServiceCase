using ConfigLibrary.BL.Interfaces;
using ConfigLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigAdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IConfigService _configService;

        public StorageController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet("/GetAllConfig")]
        public async Task<IActionResult> GetAllConfig()
        {
            var result = await _configService.GetAllAsync();
            if (result != null)
            {
                return Ok();
            }

            //todo : çalıştırdıktan sonra hata yönetimlerini düzelt
            return NotFound();
        }

        [HttpGet("/GetById/id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var config = await _configService.GetByIdAsync(id);

            return config == null ? NotFound() : Ok();    
        }

        [HttpPost("/AddConfig")]
        public async Task<IActionResult> AddConfig(Storage config)
        {
            var result = await _configService.AddAsync(config);

            return result == false ? NotFound() : Ok();   
        }

        [HttpPut("/UpdateConfig")]
        public async Task<IActionResult> UpdateConfig(Storage config)
        {
            var result = await _configService.UpdateAsync(config);
            return result == false ? NotFound() : Ok();
        }

        [HttpDelete("/DeleteConfig/id")]
        public async Task<IActionResult> DeleteConfig(Guid id)
        {
            var result = await _configService.DeleteAsync(id);
            return result == false ? NotFound() : Ok(); 
        }

        //isActive için soft delete ekle test ettikten sonra  ???




    }
}
