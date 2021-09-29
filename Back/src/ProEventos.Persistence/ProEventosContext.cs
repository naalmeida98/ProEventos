using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext //herda DbContext 
    {
        //o meu construtor abaixo vai passar para o pai DbContext as minhas informações do contextp
        //e de qual BD estou usando (em outras palavras, tudo o que está sendo implemntadp em 
        //ConfigureServices() no Startup.cs
        public ProEventosContext (DbContextOptions<ProEventosContext> options) : base(options){ } 
        public DbSet<Evento> Eventos{ get; set; } //criando minha tabela
        public DbSet<Palestrante> Palestrantes{ get; set; } //criando minha tabela
        public DbSet<PalestranteEvento> PalestrantesEventos{ get; set; } //criando minha tabela

        //fazer associação entre palestrantes de eventos:

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }

    }
}