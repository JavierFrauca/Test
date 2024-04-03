using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using TEST.Dtos;
using TEST.Services;

namespace TEST.Controllers
{
    public class Tabla3Controller(ITabla3Service service) : Controller
    {
        private readonly ITabla3Service _service = service;
        [HttpGet("/Tabla3/List")]
        public async Task<ActionResult<IEnumerable<Tabla3Dto>>> List() => await _service.List();
        [HttpGet("/Tabla3/{id}")]
        public async Task<ActionResult<Tabla3Dto>> Read(int id) => await _service.Read(id);
        [HttpDelete("/Tabla3/Delete/{id}")]
        public async Task<ActionResult<Tabla3Dto>> Delete(int id) => await _service.Delete(id);
        [HttpPut("/Tabla3/Write")]
        public async Task<ActionResult<Tabla3Dto>> Write(Tabla3Dto data)
        {
            var (isSuccess, dataout, errorMessage) = await _service.Write(data);
            if (isSuccess)
            {
                return Ok(dataout);
            }
            else
            {
                return BadRequest(errorMessage);
            }
        }
        [HttpPost("/Tabla3/Add")]
        public async Task<ActionResult<Tabla3Dto>> Add(Tabla3Dto data)
        {
            var (isSuccess, dataout, errorMessage) = await _service.Add(data);
            if (isSuccess)
            {
                return Ok(dataout);
            }
            else
            {
                return BadRequest(errorMessage);
            }
        }
    }
}
