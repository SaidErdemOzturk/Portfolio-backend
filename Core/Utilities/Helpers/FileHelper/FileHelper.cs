using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile formFile,string direction)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), direction, fileName);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create); //FileMode.Create => İşletim sisteminin yeni bir dosya oluşturması gerektiğini belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.
            formFile.CopyTo(fileStream); //yola kopyala
            fileStream.Flush(); //ara belleği temizle
            return fileName;
        }
    }
}
