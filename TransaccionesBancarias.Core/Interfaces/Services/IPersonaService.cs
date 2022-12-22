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
    public interface IPersonaService
    {
        Task<ApiResponse<PersonaDto>> Add(PersonaDto request);
        Task<ApiResponse<PersonaDto>> Update(PersonaDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<PersonaDto>> Get(QueryFilter filter);
        Task<ApiResponse<PersonaDto>> Get(long id);
    }
}
