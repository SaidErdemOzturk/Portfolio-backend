using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        //this(success) işlemi alttaki ctoru çalıştırmamızı sağlıyor.
        //this(success,message) işlemi uygulansaydı success ve message parametrelerine sahip olan ctor'u çalıştıracaktı.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
        //set işlemi sadece ctor içerisinde yapılabilir.
    }
}
