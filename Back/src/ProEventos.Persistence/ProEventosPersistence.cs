using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext context;

        public ProEventosPersistence(ProEventosContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            this.context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0; //se me retornar maior que 0, significa
            // que houve alterações, logo retorno true
        }
        

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = this.context.Eventos; 
            if (includePalestrantes){
                // a cada evento oncluir o palestrante
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            IQueryable<Evento> query = this.context.Eventos; 
            if (includePalestrantes){
                // a cada evento oncluir o palestrante
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }
            //dado um evento e uma tema, converte para LowerCase e verifica se contêm o tema
            query = query.OrderBy(e => e.Id).Where(e => e.Id == id);
            // como retorno apenas um elemento, então p o retorno é First
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = this.context.Eventos; 
            if (includePalestrantes){
                // a cada evento oncluir o palestrante
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }
            //dado um evento e uma tema, converte para LowerCase e verifica se contêm o tema
            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes; 
            if (includeEventos){
                // a cada palestrante incluir o evento
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes; 
            if (includeEventos){
                // a cada evento oncluir o palestrante
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }
            //dado um evento e uma tema, converte para LowerCase e verifica se contêm o tema
            query = query.OrderBy(e => e.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes; 
            if (includeEventos){
                // a cada evento oncluir o palestrante
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }
            //dado um evento e uma tema, converte para LowerCase e verifica se contêm o tema
            query = query.OrderBy(p => p.Id).Where(p => p.Id == id);
            // como retorno apenas um elemento, então p o retorno é First
            return await query.FirstOrDefaultAsync();
        }

    }
}