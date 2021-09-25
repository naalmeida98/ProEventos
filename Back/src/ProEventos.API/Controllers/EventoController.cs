using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //define a minha rota
    public class EventoController : ControllerBase
    {
        private readonly DataContext Context;

        public EventoController(DataContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get() //retornar um array
        {
            return Context.Eventos; 
        }

        [HttpGet("{id}")]
        public Evento GetById(int id) //retornar um array
        {
            return Context.Eventos.FirstOrDefault(evento => evento.EventoId == id); 
        }

        [HttpPost]
        public string Post()
        {
            return "testando Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"testando Put com id: {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"testando Delete com id: {id}";
        }
    }
}
