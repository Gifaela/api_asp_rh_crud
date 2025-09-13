using ClienteApi.Context;
using ClienteApi.Models;
using ClienteApi.Models.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteApi.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<login>> GetLogin()
        {
            return await _context.login.ToArrayAsync();
        }

        public async Task<login> GetLoginById(string email)
        {
            var login = await _context.login.FindAsync(email);
            return login;
        }

        public async Task CreateLogin(login login)
        {
            _context.login.Add(login);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteLogin(login login)
        {
            _context.login.Remove(login);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLogin(login login)
        {
            _context.Entry(login).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
