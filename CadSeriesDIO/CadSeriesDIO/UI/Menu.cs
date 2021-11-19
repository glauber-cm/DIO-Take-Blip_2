using System;

namespace CadSeriesDIO.UI
{
    public class Menu
    {

        public char OpcaoUsuario { get; set; }

        public Menu()
        {

        }
        public Menu(char op)
        {
            this.OpcaoUsuario = op;
        }

        public static string ObterOpcaoUsuario(char entradaTipo)
        {

            string tipo = string.Empty;

            if (entradaTipo == 'f' || entradaTipo == 'F')
            {
                tipo = "Filmes";
            }
            else
                tipo = "Séries";


            Console.WriteLine();
            Console.WriteLine("DIO " + tipo + " a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar " + tipo);
            Console.WriteLine("2- Inserir nova(o) " + tipo);
            Console.WriteLine("3- Atualizar " + tipo);
            Console.WriteLine("4- Excluir " + tipo);
            Console.WriteLine("5- Visualizar " + tipo);
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
