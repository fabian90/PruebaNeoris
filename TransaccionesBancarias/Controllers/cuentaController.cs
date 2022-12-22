using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Interfaces.Services;
using TransaccionesBancarias.DTOs.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaccionesBancarias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<CuentaDto> _validator;
        public cuentaController(ICuentaService cuentaService, IValidator<CuentaDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _cuentaService = cuentaService;
        }
        // GET: api/<cuentaController>
        [HttpGet]
        public async Task<RecordsResponse<CuentaDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _cuentaService.Get(filter);
            return response;
        }

        // GET api/<cuentaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _cuentaService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<cuentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentaDto request)
        {
            var response = await _cuentaService.Add(request);

            return Ok(response);
        }

        // PUT api/<cuentaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CuentaDto request)
        {
            var validation = await _validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Code = e.ErrorCode,
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }));
            }

            var response = await _cuentaService.Update(request);

            return Ok(response);
        }

        // DELETE api/<cuentaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _cuentaService.Delete(id);
            return Ok(response);
        }
    }
}
