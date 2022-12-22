using System;
using System.Collections.Generic;
using System.Text;

namespace TransaccionesBancarias.Commons.Response
{
    public class ValidationResult
    {
        public string Code { get; set; }
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
