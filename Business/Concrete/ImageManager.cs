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
            if (image.Id == 0)
            {
                var allImages = _imageDal.GetAll();
                image.Id = allImages.Any() ? allImages.Max(i => i.Id) + 1 : 1;
            }

            image.ImagePath = _fileHelper.Upload(formFile, DefaultObjects.ImagePath);
            _imageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            var imageToDelete = _imageDal.Get(i => i.Id == image.Id || (!string.IsNullOrEmpty(image.ImagePath) && i.ImagePath == image.ImagePath));
            if (imageToDelete == null)
            {
                return new ErrorResult("Resim bulunamadı.");
            }
            _fileHelper.Delete(DefaultObjects.ImagePath + imageToDelete.ImagePath);
            _imageDal.Delete(imageToDelete);
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
