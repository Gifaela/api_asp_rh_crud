
using ClienteApi.Models;
using ClienteApi.Models.Login;
using ClienteApi.Models.Ponto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace ClienteApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<login> login { get; set; }
        public DbSet<funcionario> funcionarios { get; set; }
        public DbSet<ponto> ponto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<funcionario>().HasData(
                new funcionario
                {
                    Id = 1,
                    MyName = "Rodrigo",
                    MyCpf = 0000000000,
                    Myemail = "rodrigo_toledo@outlook.com",
                    Mybirthdate = "00000",
                    Myferias = "teste",
                    MyPhone = 119765,
                    MyCargo = "Pleno",
                    MySalario = 5000,




                },
                new funcionario
                {
                    Id = 2,
                    MyName = "Giulia",
                    MyCpf = 0000000000,
                    Myemail = "giulia@outlook.com",
                    Mybirthdate = "00000",
                    Myferias = "teste",
                    MyPhone = 119765,
                    MyCargo = "Pleno",
                    MySalario = 5000,

                }
               );


            modelBuilder.Entity<login>().HasData(
                new login
                {
                    Email = "rodrigo_toledo@outlook.com",
                    Password = "1234"
                },
                new login
                {
                    Email = "giulia@outlook.com",
                    Password = "4321"
                }
);
            modelBuilder.Entity<ponto>().HasData(
                new ponto
                {
                    PontoId = 1,
                    Email = "rodrigo_toledo@outlook.com",
                    Entrada = DateTime.Now,
                    Saida =  DateTime.Now


                },
                new ponto
                {
                    PontoId = 2,
                    Email = "giulia@outlook.com",
                    Entrada = DateTime.Now,
                    Saida = DateTime.Now
                }
);

        }
    }
}
