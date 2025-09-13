
using ClienteApi.Models;
using ClienteApi.Models.Login;
using ClienteApi.Models.Ponto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public interface Ipontoservice
    {

        Task<IEnumerable<ponto>> GetPonto();
        Task CreatePonto(ponto ponto);
        Task UpdatePonto(ponto ponto);
        Task DeletePonto(ponto ponto);
        Task<ponto> GetPontoById(string email);
    }
}
