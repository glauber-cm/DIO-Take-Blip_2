using CadSeriesDIO.Classes;
using CadSeriesDIO.Interfaces;
using System.Collections.Generic;

namespace CadSeriesDIO.Repositorio
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{
		private List<Filme> listaFilme = new List<Filme>();
		public void Atualizar(int id, Filme objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Excluir(int id)
		{
			listaFilme[id].Excluir();
		}

		public void Inserir(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Listar()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme RetornaPorId(int id)
		{
			return listaFilme[id];
		}
	}
}

