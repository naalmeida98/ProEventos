using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Application.Contrato
{
    public interface IProEventosService
    {
        void Add<T>(T entity) where T: class; //adicionar
        void Update<T>(T entity) where T: class; //atualizar
        void Delete<T>(T entity) where T: class; //deletar apenas 1
        void DeleteRange<T>(T[] entity) where T: class; //deletar + de 1
        Task<bool> SaveChangesAsync(); //salvar
    
        //EVENTOS:
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);

        //PALESTRANTES:
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos);
       
    }
}
