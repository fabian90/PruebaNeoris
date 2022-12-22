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

namespace TransaccionesBancarias.Infrastructure.Repositories
{
    public class PersonaRepository: GenericRepository<Persona, bancoNeorisContext>, IPersonaRepository
    {
        protected readonly bancoNeorisContext _context;

        public PersonaRepository(bancoNeorisContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<PersonaDto>> Get(QueryFilter filter)
        {
            var response =  new RecordsResponse<Persona>();
            try
            {
               
                if (filter.filter == null)
                {
                    response = await _context.Personas.OrderBy(x => x.Id).Where(x => x.Id != 0 ).GetPagedAsync(filter.page, filter.take);
                }
                else
                {
                   response = await _context.Personas.OrderBy(x => x.Id).Where(x => x.Identificacion == filter.filter).GetPagedAsync(filter.page, filter.take);
                }
                return response.MapTo<RecordsResponse<PersonaDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
