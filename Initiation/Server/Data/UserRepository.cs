using Initiation.Server.Helpers;
using Initiation.Server.Helpers.PagedParams;
using Initiation.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Initiation.Server.Data
{
    public interface IUserRepository 
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExits(string userName);
    }
    public class UserRepository : Repository, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context):base(context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            user.Created = DateTime.Now;
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswaordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private void CreatePasswordHash(string password, out byte[] passwaordHash, out byte[] passwaordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwaordSalt = hmac.Key;
                passwaordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswaordSalt))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwaordHash, byte[] passwaordSalt)
        {
            using(var hmac = new HMACSHA512(passwaordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwaordHash[i])
                        return false;
                }
            }
            return true;
        }
        public async Task<bool> UserExits(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
