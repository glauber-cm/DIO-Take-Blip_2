using ApiCatalogoFilmes.InputModel;
using ApiCatalogoFilmes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoFilmes.Services
{
    public interface IFilmeService: IDisposable
    {
        Task<List<FilmeViewModel>> Obter(int pagina, int qtd);
        Task<FilmeViewModel> Obter(Guid id);
        Task<FilmeViewModel> Inserir(FilmeInputModel filme);
        Task Atualizar(Guid id, FilmeInputModel filme);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
