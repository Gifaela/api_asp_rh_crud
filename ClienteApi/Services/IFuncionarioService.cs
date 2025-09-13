using ClienteApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<funcionario>> GetFuncionarios();
        Task<funcionario> GetFuncionarioById(int id);
        Task<IEnumerable<funcionario>> GetFuncionarioByName(string email);

        Task CreateFuncionario(funcionario funcionario);
        Task UpdateFuncionario(funcionario funcionario);
        Task DeleteFuncionario(funcionario funcionario);
    }
}
