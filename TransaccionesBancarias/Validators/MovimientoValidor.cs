using FluentValidation;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Validators
{
    public class MovimientoValidor : AbstractValidator<MovimientoDto>
    {
        public MovimientoValidor()
        {
            Include(new MovimientoIsSpecified());
        }
    }
    public class MovimientoIsSpecified : AbstractValidator<MovimientoDto>
    {
    }
}
