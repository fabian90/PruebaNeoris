using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class CuentaService : ICuentaService
    {
        private string table = "Cuenta";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuentaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<CuentaDto>> Add(CuentaDto request)
        {
            QueryFilter filter = new QueryFilter();
            filter.filter = Convert.ToString(request.NumeroCuenta);
            var oCuenta = await _unitOfWork.CuentaRepository.Get(filter);

            if (oCuenta.Items.Count() == 0)
            {

                var cuenta = _mapper.Map<Cuenta>(request);
                await _unitOfWork.CuentaRepository.Add(cuenta);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<CuentaDto>(cuenta);

                return new ApiResponse<CuentaDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<CuentaDto>()
                {
                    Message = "Cuenta already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Cuenta oCuenta = await _unitOfWork.CuentaRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<CuentaDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.CuentaRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<CuentaDto>> Get(long id)
        {
            Cuenta oCuenta = await _unitOfWork.CuentaRepository.GetById(id);
            var mapper = _mapper.Map<CuentaDto>(oCuenta);

            return new ApiResponse<CuentaDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Cuenta Id already exist",
            };
        }
        public async Task<ApiResponse<CuentaDto>> Update(CuentaDto request)
        {
            var cuenta = _mapper.Map<Cuenta>(request);

            if (cuenta.SaldoInicial != 0)
            {

                _unitOfWork.CuentaRepository.UpdateProperties(cuenta, p => p.TipoCuenta!, p => p.NumeroCuenta!, p => p.SaldoInicial);
                await _unitOfWork.SaveChangesAsync();
            }
        
            return new ApiResponse<CuentaDto>()
            {
                Data = request,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
