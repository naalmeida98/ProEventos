using System;
using System.Threading.Tasks;
using ProEventos.Application.Contrato;
using ProEventos.Domain;
using ProEventos.Persistence.Contrato;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProEventos.Application
{
    public class ProEventosService : IProEventosService
    {
        private readonly IProEventosPersistence persistence;
        private Task<Evento[]> x;

        public ProEventosService(IProEventosPersistence persistence)
        {
            this.persistence = persistence;
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                persistence.Add<T>(entity);
            }
            catch (System.Exception)
            {
                throw new Exception("Erro ao adicionar");
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            try
            {
                persistence.Delete<T>(entity);
            }
            catch (System.Exception)
            {
                throw new Exception("Erro ao deletar");
            }
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            try
            {
                persistence.DeleteRange<T>(entity);
            }
            catch (System.Exception)
            {
                throw new Exception("Erro ao Deletar");
            }
        }

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}