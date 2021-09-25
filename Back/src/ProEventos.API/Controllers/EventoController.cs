using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //define a minha rota
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() { //meu primeiro evento
                EventoId = 1,
                Local = "SB",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "Civil",
                QtdPessoas = 200,
                Lote = "1542",
                ImagemURL = "foto.png"
            }, 
            new Evento() { //meu primeiro evento
                EventoId = 2,
                Local = "SB",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "Casamento",
                QtdPessoas = 200,
                Lote = "1542",
                ImagemURL = "foto2.png"
            } 
        };
        

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get() //retornar um array
        {
            return _evento; 
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id) //retornar um array
        {
            return _evento.Where(evento => evento.EventoId == id); 
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
