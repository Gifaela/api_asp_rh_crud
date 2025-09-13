using ClienteApi.Models.Login;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Services.Login
{
    public interface ILoginService
    {
        Task<IEnumerable<login>> GetLogin();
        Task<login> GetLoginById(string email);
        Task CreateLogin(login login);
        Task UpdateLogin(login login);
        Task DeleteLogin(login login);
    }
}
