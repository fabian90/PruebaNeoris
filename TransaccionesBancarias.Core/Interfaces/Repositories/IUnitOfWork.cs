using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransaccionesBancarias.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IConfiguracionRepository ConfiguracionRepository { get; }
        ICuentaRepository CuentaRepository { get; }
        IPersonaRepository PersonaRepository { get; }
        IMovimientoRepository MovimientoRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
