using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class VideoService
    {
        private readonly AppDbContext _appDbContext;
        public VideoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Pagination<VideoModel>> GetAllVideos(int pageNumber, int pageSize)//Display all Video
        {
            var totalVideoAccount = await _appDbContext.Videos.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalVideoAccount / pageSize);
            var video = await _appDbContext.Videos
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(v => new VideoModel
            {
                VideoId = v.VideoId,
                Title = v.Title,
                Type = v.Type,
                Location = v.Location,
                Description = v.Description,
                CreateDate = v.CreateDate,
                VideoUrl = v.VideoUrl
            }).ToListAsync();

            return new Pagination<VideoModel>
            {
                Items = video,
                TotalCount = totalVideoAccount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<Video?> GetVideoById(Guid videoId)
        {
            return await _appDbContext.Videos.FirstOrDefaultAsync(v => v.VideoId == videoId);
        }
        public async Task<Video> AddVideo(VideoModel newVideo)//create new Video
        {

            Video video = new Video
            {
                VideoId = Guid.NewGuid(),
                Title = newVideo.Title,
                Type = newVideo.Type,
                Location = newVideo.Location,
                Description = newVideo.Description,
                CreateDate = DateTime.UtcNow,
                VideoUrl = newVideo.VideoUrl

            };
            await _appDbContext.Videos.AddAsync(video);
            await _appDbContext.SaveChangesAsync();
            return video;

        }
    }
}