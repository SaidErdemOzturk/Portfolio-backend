using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile formFile, Image image);
        IResult Update(IFormFile formFile, Image image);
        IResult Delete(Image image);
    }
}
