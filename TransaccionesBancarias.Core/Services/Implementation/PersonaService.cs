using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.Core.Interfaces.Services;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Core.Services.Implementation
{
    public class PersonaService: IPersonaService
    {
        private string table = "Persona";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PersonaDto>> Add(PersonaDto request)
        {
            QueryFilter filter = new QueryFilter();
            filter.filter = request.Identificacion;
            var oPersona = await _unitOfWork.PersonaRepository.Get(filter);

            if (oPersona.Items.Count() == 0)
            {

                var persona = _mapper.Map<Persona>(request);
                await _unitOfWork.PersonaRepository.Add(persona);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<PersonaDto>(persona);

                return new ApiResponse<PersonaDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<PersonaDto>()
                {
                    Message = "Persona already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Persona oPersona = await _unitOfWork.PersonaRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<PersonaDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.PersonaRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<PersonaDto>> Get(long id)
        {
            Persona oPersona = await _unitOfWork.PersonaRepository.GetById(id);
            var mapper = _mapper.Map<PersonaDto>(oPersona);

            return new ApiResponse<PersonaDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Persona Id already exist",
            };
        }
        public async Task<ApiResponse<PersonaDto>> Update(PersonaDto request)
        {
            var persona = _mapper.Map<Persona>(request);

            _unitOfWork.PersonaRepository.UpdateProperties(persona, p => p.Identificacion!,p=>p.Direccion,p=>p.Edad);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<PersonaDto>()
            {
                Data = request,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
