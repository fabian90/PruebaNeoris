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
    public class ConfiguracionRepository : GenericRepository<Configuracion, bancoNeorisContext>, IConfiguracionRepository
    {
        protected readonly bancoNeorisContext _context;

        public ConfiguracionRepository(bancoNeorisContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<ConfiguracionDto>> Get(QueryFilter filter)
        {
            var ConfiguracionDto = new ConfiguracionDto();
            try
            {

                var response = await _context.Configuracion.OrderBy(x => x.Id).Where(x => x.Id != 0 || x.Nombre==filter.filter || x.Valor== filter.filter).GetPagedAsync(filter.page, filter.take);
                return response.MapTo<RecordsResponse<ConfiguracionDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
