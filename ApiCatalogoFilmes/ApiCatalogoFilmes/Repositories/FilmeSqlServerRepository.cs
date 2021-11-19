using ApiCatalogoFilmes.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoFilmes.Repositories
{
    public class FilmeSqlServerRepository
    {
        private readonly SqlConnection sqlConnection;

        public FilmeSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Filme>> Obter(int pagina, int quantidade)
        {
            var filmes = new List<Filme>();

            var comandosql = $"SELECT *FROM Filmes BY id OFFSET{((pagina - 1) * quantidade)} ROWS FETCH NEXT {quantidade} ROWS ONLY";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                filmes.Add(new Filme
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Genero = (string)sqlDataReader["Genero"],
                    Diretor = (string)sqlDataReader["Diretor"],
                    Preco = (double)sqlDataReader["Preco"]
                });
            }

            await sqlConnection.CloseAsync();

            return filmes;
        }

        public async Task<Filme> Obter(Guid id)
        {
            Filme filme = null;

            var comandosql = $"SELECT *FROM Filmes WHERE Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                filme = new Filme
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Genero = (string)sqlDataReader["Genero"],
                    Diretor = (string)sqlDataReader["Diretor"],
                    Preco = (double)sqlDataReader["Preco"]
                };
            }

            await sqlConnection.CloseAsync();

            return filme;
        }

        public async Task<List<Filme>> Obter(string nome, string diretor)
        {
            var filmes = new List<Filme>();

            var comandosql = $"SELECT *FROM Filmes WHERE Nome = '{nome}' and Diretor = '{diretor}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                filmes.Add(new Filme
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Genero = (string)sqlDataReader["Genero"],
                    Diretor = (string)sqlDataReader["Diretor"],
                    Preco = (double)sqlDataReader["Preco"]
                });
            }

            await sqlConnection.CloseAsync();

            return filmes;
        }

        public async Task Inserir(Filme filme)
        {
            var comandosql = $"INSERT Filmes(Id, Nome, Genero, Diretor, Preco) VALUES ('{filme.Id}', '{filme.Genero}', '{filme.Nome}', '{filme.Diretor}', '{filme.Preco.ToString().Replace(",", ".")}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Filme filme)
        {
            var comandosql = $"UPDATE Filmes SET Nome = '{filme.Nome}', Genero = '{filme.Genero}', Diretor = '{filme.Diretor}', Preco = {filme.Preco.ToString().Replace(",", ".")} WHERE Id = '{filme.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comandosql = $"DELETE FROM Filmes WHERE Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comandosql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
