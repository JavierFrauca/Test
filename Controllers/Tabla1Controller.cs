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
        public async Task<ActionResult<Tabla1Dto>> Read(int id)
        {
            var(status,data,errors) = await _service.Read(id);
            if (status == true)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest(errors);
            }
        }
        [HttpDelete("/Tabla1/Delete/{id}")]
        public async Task<ActionResult<Tabla1Dto>> Delete(int id)
        {
            var(status, data, errors) = await _service.Delete(id);
            if (status == true)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest(errors);
            }
        }
        [HttpPut("/Tabla1/Write")]
        public async Task<ActionResult<Tabla1Dto>> Write(Tabla1Dto data)
        {
            var (status, dataout, errorMessage) = await _service.Write(data);
            if (status)
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
            var (status, dataout, errorMessage) = await _service.Add(data);
            if (status)
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
