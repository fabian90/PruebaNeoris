using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Commons.Repository.Interfaces;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Core.Interfaces.Repositories
{
    public interface IMovimientoRepository : IGenericRepository<Movimiento>
    {
        Task<Movimiento>GetByCuentaId(long id);
        Task<RecordsResponse<MovimientoDto>> Get(QueryFilter filter);     
    }
}

