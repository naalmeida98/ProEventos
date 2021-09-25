using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext //herda DbContext 
    {
        //o meu construtor abaixo vai passar para o pai DbContext as minhas informações do contextp
        //e de qual BD estou usando (em outras palavras, tudo o que está sendo implemntadp em 
        //ConfigureServices() no Startup.cs
        public DataContext (DbContextOptions<DataContext> options) : base(options){ } 
        public DbSet<Evento> Eventos{ get; set; } //criando minha tabela


    }
}