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
    public class ConfiguracionService : IConfiguracionService
    {
        private string table = "Configuracion";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConfiguracionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ConfiguracionDto>> Add(ConfiguracionDto request)
        {
            QueryFilter filter = new QueryFilter();
            filter.filter = Convert.ToString(request.Valor);
            var oConfiguracion = await _unitOfWork.ConfiguracionRepository.Get(filter);

            if (oConfiguracion.Items == null)
            {

                var configuracion = _mapper.Map<Configuracion>(request);
                await _unitOfWork.ConfiguracionRepository.Add(configuracion);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<ConfiguracionDto>(configuracion);

                return new ApiResponse<ConfiguracionDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<ConfiguracionDto>()
                {
                    Message = "Configuracion already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Configuracion oConfiguracion = await _unitOfWork.ConfiguracionRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<ConfiguracionDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.ConfiguracionRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<ConfiguracionDto>> Get(long id)
        {
            Configuracion oConfiguracion = await _unitOfWork.ConfiguracionRepository.GetById(id);
            var mapper = _mapper.Map<ConfiguracionDto>(oConfiguracion);

            return new ApiResponse<ConfiguracionDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Configuracion Id already exist",
            };
        }
        public async Task<ApiResponse<ConfiguracionDto>> Update(ConfiguracionDto request)
        {
            var configuracion = _mapper.Map<Configuracion>(request);

                _unitOfWork.ConfiguracionRepository.Update(configuracion);
                await _unitOfWork.SaveChangesAsync();
           
            return new ApiResponse<ConfiguracionDto>()
            {
                Data = request,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
