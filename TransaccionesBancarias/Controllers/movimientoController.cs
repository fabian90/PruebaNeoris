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
    public class movimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        private readonly ICuentaService _cuentaService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<MovimientoDto> _validator;
        public movimientoController(IMovimientoService movimientoService, ICuentaService cuentaService, IValidator<MovimientoDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _movimientoService = movimientoService;
            _cuentaService=cuentaService;
        }
        // GET: api/<movimientoController>
        [HttpGet]
        public async Task<RecordsResponse<MovimientoDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _movimientoService.Get(filter);
            return response;
        }

        // GET api/<movimientoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _movimientoService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<movimientoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimientoDto request)
        {         
            var response = await _movimientoService.Add(request);

            return Ok(response);
        }

        // PUT api/<movimientoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MovimientoDto request)
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

            var response = await _movimientoService.Update(request);

            return Ok(response);
        }
  
        // DELETE api/<movimientoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _movimientoService.Delete(id);
            return Ok(response);
        }
    }
}
