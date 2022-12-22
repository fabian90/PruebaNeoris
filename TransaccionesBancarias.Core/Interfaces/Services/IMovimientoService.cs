using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Core.Interfaces.Services
{
    public interface IMovimientoService
    {
        Task<ApiResponse<MovimientoDto>> Add(MovimientoDto request);
        Task<ApiResponse<MovimientoDto>> Update(MovimientoDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<MovimientoDto>> Get(QueryFilter filter);
        Task<ApiResponse<MovimientoDto>> Get(long id);
    }
}
