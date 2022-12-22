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
    public class personaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<PersonaDto> _validator;
        public personaController(IPersonaService personaService, IValidator<PersonaDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _personaService = personaService;
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public async Task<RecordsResponse<PersonaDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _personaService.Get(filter);
            return response;
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _personaService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<PersonaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonaDto request)
        {
            var response = await _personaService.Add(request);

            return Ok(response);
        }

        // PUT api/<PersonaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonaDto request)
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

            var response = await _personaService.Update(request);

            return Ok(response);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _personaService.Delete(id);
            return Ok(response);
        }
    }
}
