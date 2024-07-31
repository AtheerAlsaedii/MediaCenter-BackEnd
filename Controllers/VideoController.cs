using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/videos")]
    public class VideoController : ControllerBase
    {
        private readonly VideoService _videoService;
        public VideoController(AppDbContext appDbContext)
        {
            _videoService = new VideoService(appDbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVideos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4)
        {
            try
            {
                var videos = await _videoService.GetAllVideos(pageNumber, pageSize);
                return ApiResponse.Success(videos, "All Videos are returned successfully");
            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
        [HttpGet("{videoId}")]
        public async Task<IActionResult> GetVideoById(Guid videoId)
        {
            try
            {
                var video = await _videoService.GetVideoById(videoId);
                if (video == null)
                {
                    return ApiResponse.NotFound("No video Found");
                }
                else
                {
                    return ApiResponse.Success(video, "single Video is returned successfully");
                }
            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddVideo(VideoModel newVideo)
        {
            try
            {
                Video createdVideo = await _videoService.AddVideo(newVideo);
                return ApiResponse.Success(createdVideo, "Video is added successfully");

            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
    }
}