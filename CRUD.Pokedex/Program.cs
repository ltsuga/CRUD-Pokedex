using System;

namespace CRUD.Pokedex
{
    class Program
    {
        static PokRepositorio repositorio = new PokRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarPokemons();
                        break;
                    case "2":
                        InserirPokemon();
                        break;
                    case "3":
                        AtualizarPokemon();
                        break;
                    case "4":
                        ExcluirPokemon();
                        break;
                    case "5":
                        VisualizarPokemon();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ExcluirPokemon()
		{
			Console.Write("Digite o id do Pokemon: ");
			int indicePok = int.Parse(Console.ReadLine());

			repositorio.Exclui(indicePok);
		}

        private static void VisualizarPokemon()
		{
			Console.Write("Digite o id do Pokemon: ");
			int indicePok = int.Parse(Console.ReadLine());

			var pokemon = repositorio.RetornaPorId(indicePok);

			Console.WriteLine(pokemon);
		}        

        private static void AtualizarPokemon()
		{
			Console.Write("Digite o id do Pokemon: ");
			int indicePok = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o número na Dex: ");
			int entradaDex = int.Parse(Console.ReadLine());

            Console.Write("Digite o peso: ");
			double entradaPeso = double.Parse(Console.ReadLine());

            Console.Write("Digite a altura: ");
			double entradaAltura = double.Parse(Console.ReadLine());


			Pokemon atualizaPok = new Pokemon(id: indicePok,
                                        nome: entradaNome,
										numeroDex: entradaDex,
                                        altura: entradaAltura,
                                        peso: entradaPeso,

                                        tipo:(Tipo)entradaTipo);

			repositorio.Atualiza(indicePok, atualizaPok);
		}


        public static void ListarPokemons()
        {
            Console.WriteLine("Listar Pokemons: ");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Pokemon encontrado!");
                return;
            }

            foreach(var pok in lista)
            {
                Console.WriteLine("#ID {0}: - {1}",pok.retornaId(),pok.retornaNome());

            }

        }

        private static void InserirPokemon()
		{
			Console.WriteLine("Inserir novo Pokemon");
			
			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o número na Dex: ");
			int entradaDex = int.Parse(Console.ReadLine());

            Console.Write("Digite o peso: ");
			double entradaPeso = double.Parse(Console.ReadLine());

            Console.Write("Digite a altura: ");
			double entradaAltura = double.Parse(Console.ReadLine());


			Pokemon novoPok = new Pokemon(id: repositorio.ProximoId(),
                                        nome: entradaNome,
										numeroDex: entradaDex,
                                        altura: entradaAltura,
                                        peso: entradaPeso,
                                        tipo:(Tipo)entradaTipo);
            repositorio.Insere(novoPok);
		}


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a sua opção: ");
            Console.WriteLine("1 - Listar Pokemons.");
            Console.WriteLine("2 - Inserir Novo Pokemon.");
            Console.WriteLine("3 - Modificar Pokemon.");
            Console.WriteLine("4 - Inativar Pokemon.");
            Console.WriteLine("5 - Visualizar Pokemon.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
