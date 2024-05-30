using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using Image = NZWalks.API.Models.Domain.Image;

namespace NZWalks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ImagesController : ControllerBase
  {
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
      _imageRepository = imageRepository;
    }

    // POST: /api/Images/Upload
    [HttpPost("Upload")]
    [Authorize(Roles = "Writer")]
    public async Task<ActionResult<ImagesUploadRequestDto>> PostImage([FromForm] ImagesUploadRequestDto imagesUploadRequestDto)
    {
      ValidateFileUpload(imagesUploadRequestDto);

      if (ModelState.IsValid)
      {
        // convert DTO to Domain Model
        var imageDomainModel = new Image
        {
          File = imagesUploadRequestDto.File,
          FileExtension = Path.GetExtension(imagesUploadRequestDto.File.FileName),
          FileSizeInBytes = imagesUploadRequestDto.File.Length,
          FileName = imagesUploadRequestDto.FileName,
          FileDescription = imagesUploadRequestDto.FileDescription,
        };

        await _imageRepository.Upload(imageDomainModel);

        return Ok(imageDomainModel);
      }

      return BadRequest(ModelState);
    }

    private void ValidateFileUpload(ImagesUploadRequestDto uploadRequestDto)
    {
      var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

      if (!allowedExtensions.Contains(Path.GetExtension(uploadRequestDto.File.FileName)))
      {
        ModelState.AddModelError("file", "Unsupported file extension");
      }

      if (uploadRequestDto.File.Length > 1048576)
      {
        ModelState.AddModelError("file", "File size more than 1MB, please upload a smaller size");
      }
    }
  }

}