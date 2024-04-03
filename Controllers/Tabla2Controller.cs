using Microsoft.AspNetCore.Mvc;
using TEST.Dtos;
using TEST.Services;

namespace TEST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Tabla2Controller(ICommonService<Tabla2Dto> service) : Controller
    {
        private readonly ICommonService<Tabla2Dto> _service = service;
        [HttpGet("/Tabla2/List")]
        public async Task<ActionResult<IEnumerable<Tabla2Dto>>> List() => await _service.List();
        [HttpGet("/Tabla2/{id}")]
        public async Task<ActionResult<Tabla2Dto>> Read(int id) => await _service.Read(id);
        [HttpDelete("/Tabla2/Delete/{id}")]
        public async Task<ActionResult<Tabla2Dto>> Delete(int id) => await _service.Delete(id);
        [HttpPut("/Tabla2/Write")]
        public async Task<ActionResult<Tabla2Dto>> Write(Tabla2Dto data)
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
        [HttpPost("/Tabla2/Add")]
        public async Task<ActionResult<Tabla2Dto>> Add(Tabla2Dto data)
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
