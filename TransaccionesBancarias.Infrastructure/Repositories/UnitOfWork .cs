using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.Core.Interfaces.Repositories;
using TransaccionesBancarias.Infrastructure.Data.Context;
using TransaccionesBancarias.Infrastructure_.Repositories;

namespace TransaccionesBancarias.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly bancoNeorisContext _context;
        private readonly ICuentaRepository _CuentaRepository;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMovimientoRepository _MovimientoRepository;
        private readonly IPersonaRepository _PersonaRepository;
        private readonly IConfiguracionRepository _ConfiguracionRepository;

        public UnitOfWork(bancoNeorisContext context)
        {
            _context = context;
        }
        public IClienteRepository ClienteRepository => _ClienteRepository ?? new ClienteRepository(_context);

        public IConfiguracionRepository ConfiguracionRepository => _ConfiguracionRepository ?? new ConfiguracionRepository(_context);

        public ICuentaRepository CuentaRepository => _CuentaRepository ?? new CuentaRepository(_context);

        public IPersonaRepository PersonaRepository => _PersonaRepository ?? new PersonaRepository(_context);

        public IMovimientoRepository MovimientoRepository => _MovimientoRepository ?? new MovimientoRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
