using FluentValidation;
using System.Text.RegularExpressions;
using TransaccionesBancarias.DTOs.Request;

namespace TransaccionesBancarias.Validators
{
    public class ClienteValidor : AbstractValidator<ClienteDto>
    {
        public ClienteValidor()
        {
            Include(new ClienteIsSpecified());
        }
        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
    public class ClienteIsSpecified : AbstractValidator<ClienteDto>
    {
    }
}
