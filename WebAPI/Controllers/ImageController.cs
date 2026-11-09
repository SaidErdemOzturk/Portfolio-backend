using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] int projectId, [FromForm] int? id)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest("Lütfen bir resim dosyası seçin.");
            }

            var imageModel = new Image
            {
                Id = id ?? 0,
                ProjectId = projectId
            };

            var result = _imageService.Add(formFile, imageModel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Image image)
        {
            var result = _imageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _imageService.Delete(new Image { Id = id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
