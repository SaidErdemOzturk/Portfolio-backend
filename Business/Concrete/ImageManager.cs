using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IFileHelper _fileHelper;
        public ImageManager(IImageDal imageDal, IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, Image image)
        {
            image.ImagePath = _fileHelper.Upload(formFile, DefaultObjects.ImagePath);
            _imageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            _fileHelper.Delete(DefaultObjects.ImagePath + image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IResult Update(IFormFile formFile, Image image)
        {
            image.ImagePath = _fileHelper.Update(formFile, image.ImagePath, DefaultObjects.ImagePath);
            _imageDal.Update(image);
            return new SuccessResult();
        }
    }
}
