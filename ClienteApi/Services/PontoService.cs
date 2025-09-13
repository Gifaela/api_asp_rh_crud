using ClienteApi.Context;
using ClienteApi.Models.Ponto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public class PontoService : Ipontoservice
    {
        private readonly AppDbContext _context;

        public PontoService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<ponto>> GetPonto()
        {
            return await _context.ponto.ToArrayAsync();
        }

        public async Task<ponto> GetPontoById(string email)
        {
            var ponto = await _context.ponto.FindAsync(email);
            return ponto;
        }
        
        public async Task CreatePonto(ponto ponto)
        {
            _context.ponto.Add(ponto);
            await _context.SaveChangesAsync();

        }

        public async Task UpdatePonto(ponto ponto)
        {
            _context.Entry(ponto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePonto(ponto ponto)
        {
            _context.ponto.Remove(ponto);
            await _context.SaveChangesAsync();

        }
    }
}
