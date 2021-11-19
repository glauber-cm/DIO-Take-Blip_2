﻿using System;

namespace ApiCatalogoFilmes.ViewModel
{
    public class FilmeViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        public double Preco { get; set; }
    }
}
