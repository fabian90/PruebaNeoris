using Microsoft.EntityFrameworkCore;
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

namespace TransaccionesBancarias.Infrastructure_.Repositories
{
    public class MovimientoRepository : GenericRepository<Movimiento, bancoNeorisContext>, IMovimientoRepository
    {
        protected readonly bancoNeorisContext _context;

        public MovimientoRepository(bancoNeorisContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<MovimientoDto>> Get(QueryFilter filter)
        {
            var MovimientoDto = new MovimientoDto();
            try
            {
                var response = new RecordsResponse<Movimiento>();
                if (filter.filter != null && filter.filterDateTime != null)
                {
                    response = await _context.Movimientos.OrderBy(x => x.Id).Where(x => (x.Id != 0) && x.Fecha == filter.filterDateTime && x.Cuenta.Cliente.Persona.Identificacion == filter.filter).GetPagedAsync(filter.page, filter.take);
                }
                else if (filter.filter != null)
                {
                    response = await _context.Movimientos.Where(x => (x.Cuenta.Cliente.Persona.Identificacion == filter.filter)).GetPagedAsync(filter.page, filter.take);
                }
                else
                {
                    response = await _context.Movimientos.OrderBy(x => x.Id).GetPagedAsync(filter.page, filter.take);
                }
                return response.MapTo<RecordsResponse<MovimientoDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }

        public async Task<Movimiento> GetByCuentaId(long id)
        {
            var MovimientoDto = new MovimientoDto();
            try
            {

                var response =  _context.Movimientos.OrderByDescending(x => x.Id).FirstOrDefault(x => x.CuentaId == id);
                return response;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
