using CadSeriesDIO.Classes;
using CadSeriesDIO.Repositorio;
using CadSeriesDIO.UI;
using System;

namespace CadSeriesDIO
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha uma Opcao: ");
            Console.WriteLine("F - Filmes");
            Console.WriteLine("S - Séries ");

            char entradaTipo = char.Parse(Console.ReadLine());

            string opcaoUsuario = Menu.ObterOpcaoUsuario(entradaTipo);

            if (entradaTipo == 'S' || entradaTipo == 's')
            {
                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = Menu.ObterOpcaoUsuario(entradaTipo);
                }
            }
            else if (entradaTipo == 'F' || entradaTipo == 'f')
            {
                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarFilmes();
                            break;
                        case "2":
                            InserirFilme();
                            break;
                        case "3":
                            AtualizarFilme();
                            break;
                        case "4":
                            ExcluirFilme();
                            break;
                        case "5":
                            VisualizarFilme();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = Menu.ObterOpcaoUsuario(entradaTipo);
                }
            }
            

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }


        #region Exclusao
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }
        private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Excluir(indiceFilme);
        }
        #endregion

        #region Visualização
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void VisualizarFilme()
        {
            Console.Write("Digite o id da filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);

        }
        #endregion

        #region Atualização
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Diretor da Série: ");
            string entradaDiretor = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        diretor: entradaDiretor
                                        );

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }
        private static void AtualizarFilme()
        {
            Console.WriteLine("****Atualização do Filme****");

            Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descricao do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Diretor do Filme: ");
            string entradaDiretor = Console.ReadLine();


            Filme atualizafilme = new Filme(id: repositorioFilme.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno,
                                            diretor: entradaDiretor);

            repositorioFilme.Atualizar(indiceFilme, atualizafilme);
        }
        #endregion

        #region Lista
        private static void ListarSeries()
        {
            Console.WriteLine("****Listar séries****");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0} : - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("***Listar Filmes****");

            var lista = repositorioFilme.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0} : - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        #endregion

        #region Insercao
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Diretor da Série: ");
            string entradaDiretor = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        diretor: entradaDiretor
                                        );

            repositorio.Inserir(novaSerie);
        }
        private static void InserirFilme()
        {
            Console.WriteLine("**Inserir novo Filme**");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Diretor do Filme: ");
            string entradaDiretor = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        diretor: entradaDiretor
                                        );

            repositorioFilme.Inserir(novoFilme);

        }
        #endregion

      
    }
}
