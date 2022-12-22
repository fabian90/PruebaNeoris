using AutoMapper;
using TransaccionesBancarias.Core.Entity;
using TransaccionesBancarias.DTOs.Request;
//using TransaccionesBancarias.Core.DTOs.Request;
//using TransaccionesBancarias.Core.Entity;


namespace TransaccionesBancarias.Infraestructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Cliente
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            #endregion
            #region Configuracion
            CreateMap<Configuracion, ConfiguracionDto>();
            CreateMap<ConfiguracionDto, Configuracion>();
            #endregion
            #region Cuenta
            CreateMap<Cuenta, CuentaDto>();
            CreateMap<CuentaDto, Cuenta>();
            #endregion
            #region Movimiento
            CreateMap<Movimiento, MovimientoDto>();
            CreateMap<MovimientoDto, Movimiento>();
            #endregion
            #region Persona
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
            #endregion
        }
    }
}
