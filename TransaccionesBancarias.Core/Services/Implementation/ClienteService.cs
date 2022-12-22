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
    public class ClienteService:IClienteService
    {
        private string table = "Cliente";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ClienteDto>> Add(ClienteDto request)
        {
            
            Cliente oCliente = await _unitOfWork.ClienteRepository.GetById(request.PersonaId);

            if (oCliente == null)
            {
                var cliente = _mapper.Map<Cliente>(request);

                await _unitOfWork.ClienteRepository.Add(cliente);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<ClienteDto>(cliente);

                return new ApiResponse<ClienteDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<ClienteDto>()
                {
                    Message = "Clientename already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Cliente oCliente = await _unitOfWork.ClienteRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<ClienteDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.ClienteRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<ClienteDto>> Get(long id)
        {
            Cliente oCliente = await _unitOfWork.ClienteRepository.GetById(id);
            var mapper = _mapper.Map<ClienteDto>(oCliente);

            return new ApiResponse<ClienteDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Cliente Id already exist",
            };
        }
        public async Task<ApiResponse<ClienteDto>> Update(ClienteDto request)
        {
            var cliente = _mapper.Map<Cliente>(request);

            if (cliente != null)
            {

                _unitOfWork.ClienteRepository.UpdateProperties(cliente, p => p.PersonaId!);
            }
            else
            {
                _unitOfWork.ClienteRepository.UpdateProperties(cliente, p => p.PersonaId!);
            }

            await _unitOfWork.SaveChangesAsync();

            var mapper = _mapper.Map<ClienteDto>(cliente);

            return new ApiResponse<ClienteDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }

    }
}
