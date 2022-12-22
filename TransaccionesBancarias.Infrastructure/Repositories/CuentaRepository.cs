using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Commons.Mapper;
using TransaccionesBancarias.Commons.Paging;
using TransaccionesBancarias.Commons.Repository.Repository;
using TransaccionesBancarias.Commons.RequestFilter;
using TransaccionesBancarias.Commons.Response;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.DTOs.Request;
using TransaccionesBancarias.Infrastructure.Data.Context;

namespace TransaccionesBancarias.Infrastructure.Repositories
{
    public class CuentaRepository : GenericRepository<Cuenta, bancoNeorisContext>, ICuentaRepository
    {
        protected readonly bancoNeorisContext _context;

        public CuentaRepository(bancoNeorisContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<CuentaDto>> Get(QueryFilter filter)
        {
            var response=new RecordsResponse<Cuenta>();
            try
            {
                if (filter.filter == null)
                {
                    response = await _context.Cuenta.OrderBy(x => x.Id).Where(x => x.Id != 0 ).GetPagedAsync(filter.page, filter.take);
                }
                else
                {
                    response = await _context.Cuenta.OrderBy(x => x.Id).Where(x => x.NumeroCuenta == Convert.ToInt64(filter.filter)).GetPagedAsync(filter.page, filter.take);
                }
                return response.MapTo<RecordsResponse<CuentaDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
