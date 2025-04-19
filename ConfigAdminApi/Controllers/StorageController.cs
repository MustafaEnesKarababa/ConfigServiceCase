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
            try
            {
                var result = await _configService.GetAllAsync();
                if (result != null && result.Any())
                {
                    return Ok(result);
                }

                return NotFound("Hiçbir konfigürasyon verisi bulunamadı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet("/GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var config = await _configService.GetByIdAsync(id);
                if (config == null)
                    return NotFound($"ID değeri {id} olan konfigürasyon bulunamadı.");

                return Ok(config);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost("/AddConfig")]
        public async Task<IActionResult> AddConfig(Storage config)
        {
            try
            {
                var result = await _configService.AddAsync(config);

                if (!result)
                    return BadRequest("Konfigürasyon eklenemedi. Girdiğiniz verileri kontrol ediniz.");

                return Ok("Konfigürasyon başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPut("/UpdateConfig")]
        public async Task<IActionResult> UpdateConfig(Storage config)
        {
            try
            {
                var result = await _configService.UpdateAsync(config);

                if (!result)
                    return NotFound($"ID değeri {config.Id} olan konfigürasyon güncellenemedi.");

                return Ok("Konfigürasyon başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpDelete("/DeleteConfig/{id}")]
        public async Task<IActionResult> DeleteConfig(Guid id)
        {
            try
            {
                var result = await _configService.DeleteAsync(id);

                if (!result)
                    return NotFound($"ID değeri {id} olan konfigürasyon silinemedi.");

                return Ok("Konfigürasyon başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        //sofDelete Update ile yönetildi




    }
}
