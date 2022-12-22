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
    public interface IClienteService
    {
        Task<ApiResponse<ClienteDto>> Add(ClienteDto request);
        Task<ApiResponse<ClienteDto>> Update(ClienteDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<ClienteDto>> Get(QueryFilter filter);
        Task<ApiResponse<ClienteDto>> Get(long id);
    }
}
