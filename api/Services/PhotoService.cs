using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace api.Services
{
    public class PhotoService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public PhotoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<Pagination<PhotoModel>> GetAllPhotos(int pageNumber, int pageSize)//Display all Photos
        {
            var totalPhotosAccount = await _appDbContext.Photos.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalPhotosAccount / pageSize);
            var photo = await _appDbContext.Photos
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new PhotoModel
            {
                PhotoId = p.PhotoId,
                Title = p.Title,
                Type = p.Type,
                Location = p.Location,
                Description = p.Description,
                CreateDate = p.CreateDate,
                ImageUrl = p.ImageUrl
            }).ToListAsync();

            return new Pagination<PhotoModel>
            {
                Items = photo,
                TotalCount = totalPhotosAccount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<Photo?> GetPhotoById(Guid photoId)
        {
            return await _appDbContext.Photos.FirstOrDefaultAsync(p => p.PhotoId == photoId);
        }
        public async Task<Photo> AddPhoto(PhotoModel newPhoto)//Create new Photos
        {

            Photo photo = new Photo
            {
                PhotoId = Guid.NewGuid(),
                Title = newPhoto.Title,
                Type = newPhoto.Type,
                Location = newPhoto.Location,
                Description = newPhoto.Description,
                CreateDate = DateTime.UtcNow,
                ImageUrl = newPhoto.ImageUrl

            };
            await _appDbContext.Photos.AddAsync(photo);
            await _appDbContext.SaveChangesAsync();
            return photo;

        }
    }
}