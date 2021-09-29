using System;
using System.Collections.Generic;

namespace ProEventos.Domain //nome do meu pacote
{
    public class Evento
    {
        public int Id { get; set; }

        public string Local { get; set; }
    
        public DateTime? DataEvento { get; set; } // a ? referencia que esse intem pode ser nulo

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }
    
        public string Lote { get; set; }

        public string ImagemURL { get; set; }
      
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}