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
    public class Tabla2Controller(ICommonService<Tabla2Dto> service) : Controller
    {
        private readonly ICommonService<Tabla2Dto> _service = service;
        [HttpGet("/Tabla2/List")]
        public async Task<ActionResult<IEnumerable<Tabla2Dto>>> List() => await _service.List();
        [HttpGet("/Tabla2/{id}")]
        public async Task<ActionResult<Tabla2Dto>> Read(int id)
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
        [HttpDelete("/Tabla2/Delete/{id}")]
        public async Task<ActionResult<Tabla2Dto>> Delete(int id)
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
        [HttpPut("/Tabla2/Write")]
        public async Task<ActionResult<Tabla2Dto>> Write(Tabla2Dto data)
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
        [HttpPost("/Tabla2/Add")]
        public async Task<ActionResult<Tabla2Dto>> Add(Tabla2Dto data)
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
