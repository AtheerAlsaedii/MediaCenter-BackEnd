using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class AdminService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPasswordHasher<Admin> _passwordHasher;
        public AdminService(AppDbContext appDbContext, IPasswordHasher<Admin> passwordHasher)
        {
            _appDbContext = appDbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task<Admin?> RegisterAdmin(AdminModel newAdmin)//Register new Admin
        {
            bool emailExists = await _appDbContext.Admins.AnyAsync(u => u.Email == newAdmin.Email);
            if (emailExists)
            {
                return null;
            }
            else
            {
                Admin createAdmin = new Admin
                {
                    AdminId = Guid.NewGuid(),
                    Name = newAdmin.Name,
                    Email = newAdmin.Email,
                    Password = _passwordHasher.HashPassword(null, newAdmin.Password)
                };

                await _appDbContext.Admins.AddAsync(createAdmin);

                await _appDbContext.SaveChangesAsync();

                return createAdmin;
            }
        }
        public async Task<Admin?> LoginAdmin(LoginModel adminInfo)
        {
            //check the email:
            Admin admin = await _appDbContext.Admins.FirstOrDefaultAsync(a => a.Email == adminInfo.Email);
            if (admin == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(admin, admin.Password, adminInfo.Password);
            return result == PasswordVerificationResult.Success ? admin : null;
        }
    }
}