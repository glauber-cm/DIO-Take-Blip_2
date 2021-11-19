using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoFilmes.Entities
{
    public class Filme
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        public double Preco { get; set; }
    }
}
