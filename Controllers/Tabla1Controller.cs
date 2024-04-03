using Microsoft.AspNetCore.Mvc;
using TEST.Dtos;
using TEST.Services;

namespace TEST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Tabla1Controller(ICommonService<Tabla1Dto> service) : Controller
    {
        private readonly ICommonService<Tabla1Dto> _service = service;
        [HttpGet("/Tabla1/List")]
        public async Task<ActionResult<IEnumerable<Tabla1Dto>>> List() => await _service.List();
        [HttpGet("/Tabla1/{id}")]
        public async Task<ActionResult<Tabla1Dto>> Read(int id) => await _service.Read(id);
        [HttpDelete("/Tabla1/Delete/{id}")]
        public async Task<ActionResult<Tabla1Dto>> Delete(int id) => await _service.Delete(id);
        [HttpPut("/Tabla1/Write")]
        public async Task<ActionResult<Tabla1Dto>> Write(Tabla1Dto data)
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
        [HttpPost("/Tabla1/Add")]
        public async Task<ActionResult<Tabla1Dto>> Add(Tabla1Dto data)
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
