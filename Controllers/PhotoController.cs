using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoService _photoService;
        public PhotoController(AppDbContext appDbContext)
        {
            _photoService = new PhotoService(appDbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhotos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4)
        {
            try
            {
                var photos = await _photoService.GetAllPhotos(pageNumber, pageSize);
                return ApiResponse.Success(photos, "All Photos are returned successfully");
            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
        [HttpGet("{photoId}")]
        public async Task<IActionResult> GetPhotoById(Guid photoId)
        {
            try
            {
                var photo = await _photoService.GetPhotoById(photoId);
                if (photo == null)
                {
                    return ApiResponse.NotFound("No Photo Found");
                }
                else
                {
                    return ApiResponse.Success(photo, "single photo is returned successfully");
                }
            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddPhoto(PhotoModel newPhoto)
        {
            try
            {
                Photo createdPhoto = await _photoService.AddPhoto(newPhoto);
                return ApiResponse.Success(createdPhoto, "Photo is added successfully");
            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
    }
}