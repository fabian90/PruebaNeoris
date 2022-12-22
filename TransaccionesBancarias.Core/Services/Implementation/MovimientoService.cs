using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.Core.Interfaces.Services;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Core.Services.Implementation
{
    public class MovimientoService : IMovimientoService
    {

        private string table = "Movimiento";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovimientoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<MovimientoDto>> Add(MovimientoDto request)
        {
            var movimiento = _mapper.Map<Movimiento>(request);
            decimal saldoAnt = 0;
            decimal valor = 0;
            decimal totalDiponible = 0;
            Cuenta oCuenta = new Cuenta();
            Movimiento oMovimiento = new Movimiento();
             oCuenta = await _unitOfWork.CuentaRepository.GetById(request.CuentaId);

            var mapper = _mapper.Map<MovimientoDto>(movimiento);

            if (oCuenta != null)
            {
                if (oCuenta.Estado==true)
                {
                     oMovimiento = await _unitOfWork.MovimientoRepository.GetByCuentaId(request.CuentaId);
                    if (oMovimiento != null)
                    {
                        saldoAnt = oMovimiento.Saldo;
                        valor= oMovimiento.Valor;
                        
                        if (oMovimiento.TipoMovimiento == 7)
                        {

                            totalDiponible = Convert.ToInt64(saldoAnt + valor);
                        }
                        else
                        {
                            totalDiponible = Convert.ToInt64(saldoAnt  - valor);
                        }

                    }
                    else
                    {
                        totalDiponible = oCuenta.SaldoInicial;
                    }

                    if (totalDiponible < request.Valor && request.TipoMovimiento == 5)
                    {
                        return new ApiResponse<MovimientoDto>()
                        {
                            Data = mapper,
                            Success = true,
                            Message = "Saldo no disponible",
                        };
                    }
                    movimiento.Saldo = totalDiponible;
                    mapper.Saldo=totalDiponible;
                    await _unitOfWork.MovimientoRepository.Add(movimiento);
                    await _unitOfWork.SaveChangesAsync();
                    return new ApiResponse<MovimientoDto>()
                    {
                        Data = mapper,
                        Success = true,
                        Message = "The " + table + " was created successfully",
                    };
                }
                else
                {
                    return new ApiResponse<MovimientoDto>()
                    {
                        Data = mapper,
                        Success = true,
                        Message = "Cuenta desactivada",
                    };
                }
            }
            else
            {

                return new ApiResponse<MovimientoDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "Cuenta no existe",
                };           
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Movimiento oMovimiento = await _unitOfWork.MovimientoRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<MovimientoDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.MovimientoRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<MovimientoDto>> Get(long id)
        {
            Movimiento oMovimiento = await _unitOfWork.MovimientoRepository.GetById(id);
            var mapper = _mapper.Map<MovimientoDto>(oMovimiento);

            return new ApiResponse<MovimientoDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Movimiento Id already exist",
            };
        }
        public async Task<ApiResponse<MovimientoDto>> Update(MovimientoDto request)
        {
            var movimiento = _mapper.Map<Movimiento>(request);

            if (movimiento.Saldo != 0)
            {

                _unitOfWork.MovimientoRepository.UpdateProperties(movimiento, p => p.TipoMovimiento!,p => p.Valor);
            }
            else
            {
                _unitOfWork.MovimientoRepository.UpdateProperties(movimiento);
            }

            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<MovimientoDto>()
            {
                Data = request,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }

    }
}
