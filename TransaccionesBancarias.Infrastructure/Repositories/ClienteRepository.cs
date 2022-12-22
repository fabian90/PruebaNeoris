using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ClienteRepository : GenericRepository<Cliente, bancoNeorisContext>, IClienteRepository
    {
        protected readonly bancoNeorisContext _context;

        public ClienteRepository(bancoNeorisContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<ClienteDto>> Get(QueryFilter filter)
        {
            var ClienteDto = new ClienteDto();
            try
            {

                var response = await _context.Clientes.OrderBy(x => x.Id).Where(x => x.Id != 0).GetPagedAsync(filter.page, filter.take);
                return response.MapTo<RecordsResponse<ClienteDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
