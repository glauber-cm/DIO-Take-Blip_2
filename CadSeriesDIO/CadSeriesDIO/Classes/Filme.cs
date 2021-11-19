using System;

namespace CadSeriesDIO.Classes
{
    public class Filme: EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; } 
        private string Diretor { get; set; }
        private bool Excluido { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano, string diretor)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Diretor = diretor;
            this.Excluido = false;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
           this.Excluido = true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Sinopse: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Diretor: " + this.Diretor + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido + Environment.NewLine;
            return retorno;
        }
    }
}
