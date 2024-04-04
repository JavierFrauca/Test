using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEST.Dtos;
using TEST.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TEST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class Tabla3Controller(ICommonService<Tabla3Dto> service) : Controller
    {
        private readonly ICommonService<Tabla3Dto> _service = service;
        [HttpGet("/Tabla3/List")]
        public async Task<ActionResult<IEnumerable<Tabla3Dto>>> List() => await _service.List();
        [HttpGet("/Tabla3/{id}")]
        public async Task<ActionResult<Tabla3Dto>> Read(int id)
        {
            var (status, data, errors) = await _service.Read(id);
            if (status == true)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest(errors);
            }
        }
        [HttpDelete("/Tabla3/Delete/{id}")]
        public async Task<ActionResult<Tabla3Dto>> Delete(int id)
        {
            var (status, data, errors) = await _service.Delete(id);
            if (status == true)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest(errors);
            }
        }
        [HttpPut("/Tabla3/Write")]
        public async Task<ActionResult<Tabla3Dto>> Write(Tabla3Dto data)
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
        [HttpPost("/Tabla3/Add")]
        public async Task<ActionResult<Tabla3Dto>> Add(Tabla3Dto data)
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
