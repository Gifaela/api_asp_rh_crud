using ClienteApi.Context;
using ClienteApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly AppDbContext _context; //?????????? aqui que chama a conexão com o bb

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<funcionario>> GetFuncionarios()
        {
            return await _context.funcionarios.ToArrayAsync();
        }

        public async Task<IEnumerable<funcionario>> GetFuncionarioByName(string name)
        {

            IEnumerable<funcionario> funcionarios;
            if (!string.IsNullOrWhiteSpace(name))
            {
                funcionarios = await _context.funcionarios.Where(n => n.Myemail.Contains(name)).ToListAsync();
            }
            else
            {
                funcionarios = await GetFuncionarios();
            }
            return funcionarios;
        }
        public async Task<funcionario> GetFuncionarioById(int id)
        {
            var funcionario = await _context.funcionarios.FindAsync(id);
            return funcionario;
        }

      

        public async Task CreateFuncionario(funcionario funcionario)
        {
           _context.funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFuncionario(funcionario funcionario)
        {
            _context.funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFuncionario(funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      
    }
}
