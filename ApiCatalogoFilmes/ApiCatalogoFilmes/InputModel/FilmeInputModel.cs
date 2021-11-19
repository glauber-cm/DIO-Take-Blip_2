﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoFilmes.InputModel
{
    public class FilmeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do filme deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="O gênero do filme deve conter entre 3 e 100 caracteres")]
        public string Genero { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage ="O nome do diretor(a) deve conter entre 3 e 100 caracteres")]
        public string Diretor { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
