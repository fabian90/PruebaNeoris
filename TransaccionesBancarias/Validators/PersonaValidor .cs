using FluentValidation;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Validators
{
    public class PersonaValidor : AbstractValidator<PersonaDto>
    {
        public PersonaValidor()
        {
            Include(new PersonaIsSpecified());
        }
    }
    public class PersonaIsSpecified : AbstractValidator<PersonaDto>
    {
    }
}
