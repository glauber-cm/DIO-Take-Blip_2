using ApiCatalogoFilmes.Entities;
using ApiCatalogoFilmes.InputModel;
using ApiCatalogoFilmes.Repositories;
using ApiCatalogoFilmes.ViewModel;
using ApiCatalogoFilmes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoFilmes.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<List<FilmeViewModel>> Obter(int pagina, int quantidade)
        {
            var filmes = await _filmeRepository.Obter(pagina, quantidade);

            return filmes.Select(filme => new FilmeViewModel
            {
                Id = filme.Id,
                Nome = filme.Nome,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Preco = filme.Preco
            }).ToList();
        }

        public async Task<FilmeViewModel> Obter(Guid id)
        {
            var filme = await _filmeRepository.Obter(id);

            if (filme == null)
            {
                return null;
            }

            return new FilmeViewModel
            {
                Id = filme.Id,
                Nome = filme.Nome,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Preco = filme.Preco
            };
        }

        public async Task<FilmeViewModel> Inserir(FilmeInputModel filme)
        {
            var entidadeFilme = await _filmeRepository.Obter(filme.Nome, filme.Diretor);

            var filmeInsert = new Filme
            {
                Id = Guid.NewGuid(),
                Nome = filme.Nome,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Preco = filme.Preco
            };

            await _filmeRepository.Inserir(filmeInsert);

            return new FilmeViewModel
            {
                Id = filmeInsert.Id,
                Nome = filme.Nome,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Preco = filme.Preco
            };
        }

        public async Task Atualizar(Guid id, FilmeInputModel filme)
        {
            var entidadeFilme = await _filmeRepository.Obter(id);

            if (entidadeFilme == null)
                throw new FilmeNaoCadastradoException();

            entidadeFilme.Nome = filme.Nome;
            entidadeFilme.Genero = filme.Genero;
            entidadeFilme.Diretor = filme.Diretor;
            entidadeFilme.Preco = filme.Preco;

            await _filmeRepository.Atualizar(entidadeFilme);

        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeFilme = await _filmeRepository.Obter(id);

            if (entidadeFilme == null)
                throw new FilmeNaoCadastradoException();

            entidadeFilme.Preco = preco;

            await _filmeRepository.Atualizar(entidadeFilme);
        }

        public async Task Remover(Guid id)
        {
            var filme = await _filmeRepository.Obter(id);

            if (filme == null)
                throw new FilmeNaoCadastradoException();

            await _filmeRepository.Remover(id);
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}
