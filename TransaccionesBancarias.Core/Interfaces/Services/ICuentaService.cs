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
    public interface ICuentaService
    {
        Task<ApiResponse<CuentaDto>> Add(CuentaDto request);
        Task<ApiResponse<CuentaDto>> Update(CuentaDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<CuentaDto>> Get(QueryFilter filter);
        Task<ApiResponse<CuentaDto>> Get(long id);
    }
}
