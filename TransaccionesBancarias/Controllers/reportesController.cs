using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.DTOs.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaccionesBancarias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reportesController : ControllerBase
    {

        private string table = "Movimiento";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public reportesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RecordsResponse<MovimientoDto>> Get([FromBody] QueryFilter filter)
        {
            var response = await _unitOfWork.MovimientoRepository.Get(filter);
            return response;
        }
    }
}
