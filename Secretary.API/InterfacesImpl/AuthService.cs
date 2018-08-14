using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class AuthService : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Usuario> Login(string username, string password)
        {
            Console.WriteLine("login");
            var user = await _context.Usuario.Include(u => u.Publicador).FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHarsh, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (computerHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Usuario> Register(Usuario usuario, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            usuario.PasswordHarsh = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Usuario.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}