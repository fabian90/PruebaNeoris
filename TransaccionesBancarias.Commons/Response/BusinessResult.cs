using TransaccionesBancarias.Commons.Enum;
using TransaccionesBancarias.Commons.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TransaccionesBancarias.Commons.Response
{
    public class BusinessResult<T>
    {
        public T Result { get; set; }
        public ResultadoOperacion ResultadoOperacion { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public bool IsSuccess { get; set; }


        public static  BusinessResult<T> Success( T resultado, string Mensaje)
        {
            return new BusinessResult<T>
            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion =  ResultadoOperacion.Success,
                IsSuccess = true
            };
        }
        public static BusinessResult<IEnumerable<T>> Success(IEnumerable<T> resultado, string Mensaje)
        {
            return new BusinessResult<IEnumerable<T>>
            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = true
            };
        }
        public static BusinessResult<T> OperecionCorrecta(T resultado)
        {
            return new BusinessResult<T>
            {
                Message = Constants.SUCCESS,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = true
            };
        }

        public static BusinessResult<T> Error(T resultado, string Mensaje, Exception exception)
        {
            var error = string.Empty;

            if (exception != null)
            {
                error = exception.ToString();
            }
            return new BusinessResult<T>

            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                Exception = error,
                IsSuccess = false
            };
        }
        public static BusinessResult<IEnumerable<T>> Error(IEnumerable<T> resultado, string Mensaje, Exception exception)
        {
            var error = string.Empty;

            if (exception != null)
            {
                error = exception.ToString();
            }
            return new BusinessResult<IEnumerable<T>>

            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                Exception = error,
                IsSuccess = false
            };
        }
        public static BusinessResult<T> OperacionError(T resultado, SystemException excepciones)
        {
            return new BusinessResult<T>

            {
                Message = Constants.ERROR,
                Result = resultado,
                Exception = excepciones.ToString(),
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = false
            };

        }

    }
}
