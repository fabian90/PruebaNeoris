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
    public interface IConfiguracionService
    {
        Task<ApiResponse<ConfiguracionDto>> Add(ConfiguracionDto request);
        Task<ApiResponse<ConfiguracionDto>> Update(ConfiguracionDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<ConfiguracionDto>> Get(QueryFilter filter);
        Task<ApiResponse<ConfiguracionDto>> Get(long id);
    }
}
