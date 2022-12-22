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
    public class clienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<ClienteDto> _validator;
        public clienteController(IClienteService clienteService, IValidator<ClienteDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _clienteService = clienteService;
        }
        // GET: api/<clienteController>
        [HttpGet]
        public async Task<RecordsResponse<ClienteDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _clienteService.Get(filter);
            return response;
        }

        // GET api/<clienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _clienteService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<clienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto request)
        {
            var response = await _clienteService.Add(request);

            return Ok(response);
        }

        // PUT api/<clienteController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto request)
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

            var response = await _clienteService.Update(request);

            return Ok(response);
        }

        // DELETE api/<clienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clienteService.Delete(id);
            return Ok(response);
        }
    }
}
