using FluentValidation;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Validators
{
    public class CuentaValidor : AbstractValidator<CuentaDto>
    {
        public CuentaValidor()
        {
            Include(new CuentaIsSpecified());
        }
    }
    public class CuentaIsSpecified : AbstractValidator<CuentaDto>
    {
    }
}
