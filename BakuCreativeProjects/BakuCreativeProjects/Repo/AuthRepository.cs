﻿using System.Threading.Tasks;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.DTO.User;
using BakuCreativeProjects.Models;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Repo
{
    public class AuthRepository:IAuthRepository
    { 
        private readonly DataContext _dataContext;
        
        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
         public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
         
         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
         {
             using (var hmac =new System.Security.Cryptography.HMACSHA512())
             {
                 passwordSalt = hmac.Key;
                 passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
             }
         }
        
        public async Task<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _dataContext.Users
                .FirstOrDefaultAsync(u => u.Name == userForLoginDto.Username.ToLower());
            if (user == null) return null;
            if (!VerifyPasswordHash(userForLoginDto.Password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }
            return user;
           
        }
    
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    
        public async Task<bool> UserExists(string userName)
        {
            if (!await _dataContext.Users.AnyAsync(u => u.Name == userName)) return false;
            return true;
        }
        
    }
}
