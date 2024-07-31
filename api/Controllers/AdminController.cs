using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/admins")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        public AdminController(AppDbContext appDbContext, IPasswordHasher<Admin> passwordHasher)
        {
            _adminService = new AdminService(appDbContext, passwordHasher);
        }

        [HttpPost("/api/admins/register")]
        public async Task<IActionResult> RegisterAdmin(AdminModel newAdmin)
        {
            try
            {
                Admin? createdAdmin = await _adminService.RegisterAdmin(newAdmin);
                if (createdAdmin == null)
                {
                    return ApiResponse.Failed(newAdmin, "The Admin is already exists");
                }
                else
                    return ApiResponse.Success(newAdmin, "Admin is added successfully");

            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
        [HttpPost("/api/admins/login")]
        public async Task<IActionResult> LoginAdmin(LoginModel adminInfo)
        {
            try
            {
                Admin? loginAdmin = await _adminService.LoginAdmin(adminInfo);
                if (loginAdmin == null)
                {
                    return ApiResponse.Failed(loginAdmin, "The Password or email addres is incorrect");
                }
                else
                    return ApiResponse.Success(loginAdmin, "Admin is login successfully");

            }
            catch (Exception e)
            {
                return ApiResponse.ServerError(e.Message);
            }
        }
    }
}