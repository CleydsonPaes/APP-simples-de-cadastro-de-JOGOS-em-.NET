using System;
using APPSimplesCadastro.Interfaces;
using APPSimplesCadastro.Classes;
using APPSimplesCadastro.Enum;

namespace APPSimplesCadastro
{
    class Program
    {

        static JogosRespositorio respositorio = new JogosRespositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = OpcoesUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1": ListarJogos(); break;
                    case "2": inserirJogo(); break;
                    case "3": AtualizarJogo(); break;
                    case "4": DeletarJogo(); break;
                    case "5": getIDJogo(); break;
                    case "X": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException(); 
                }
            }
        }

        private static string OpcoesUsuario()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("NETGAMES PASS");    
            Console.WriteLine("Digite o número para selecionar uma opção");
            Console.WriteLine("-------------------------------------------------");  
            Console.WriteLine(" "); 
            Console.WriteLine(" ");    
            
            Console.WriteLine("1-Listar jogos");    
            Console.WriteLine("2-Inserir novo jogo");    
            Console.WriteLine("3-Atualizar jogo");    
            Console.WriteLine("4-Excluir jogo");    
            Console.WriteLine("5-Visualizar informações do jogo");    
            Console.WriteLine("6-Limpar tela");    
            Console.WriteLine("X-Sair"); 
            Console.WriteLine("-------------------------------------------------"); 

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;       
        }
        private static void ListarJogos()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("LISTAR JOGOS");
            Console.WriteLine("-------------------------------------------------");

            var lista = respositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo encontrado!");
                OpcoesUsuario();
            }
            
            foreach (var jogos in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", jogos.getID, jogos.getNome);
            }
        }
        private static void inserirJogo()
        {
             Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("INSERIR NOVO JOGO");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            int idJogoProximo = respositorio.proximoId();

            respositorio.set(infoJogo(idJogoProximo));

            Console.WriteLine("Novo Jogo inserido");
        }
        private static void AtualizarJogo()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ATUALIZAR JOGO");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Digite o id do jogo: ");
            int idJogo = int.Parse(Console.ReadLine());

            respositorio.atualizar(idJogo, infoJogo(idJogo));
            Console.WriteLine("Jogo atualizado!");
        }
        private static void DeletarJogo()
        {
             Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("DELETAR JOGO");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Digite o id do jogo: ");
            int idJogo = int.Parse(Console.ReadLine()); 

            respositorio.del(idJogo);

            Console.WriteLine("Jogo deletado!");
        }
        private static void getIDJogo()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("VISUALIZAR JOGO");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Digite o id do jogo: ");
            int idJogo = int.Parse(Console.ReadLine());

            var jogo = respositorio.getID(idJogo); 
            Console.WriteLine(jogo);
        }
        private static Jogos infoJogo(int idJogo)
        {
            /*
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            */

            Console.WriteLine("Digite o genero entre as opções acima: ");
            int Genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do jogo: ");
            string Nome = Console.ReadLine();

            Console.WriteLine("Densevolvedora: ");
            string Desenvolvedora = Console.ReadLine();

            Console.WriteLine("Ano: ");
            int Ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Descrição: ");
            string Descricao = Console.ReadLine();

            //Opçao de singleplayer-----------------------------------------------------
            Console.WriteLine("Digite 1 caso tenha singlePlayer ou 0 caso não tenha: ");
            int OpcaoSingle = int.Parse(Console.ReadLine());
            bool SinglePlayer = false; 
            while (OpcaoSingle > 1 || OpcaoSingle < 0 )
            {
                Console.WriteLine("Opcao inválida!");
                Console.WriteLine("Digite 1 caso tenha singlePlayer ou 0 caso não tenha: ");
                OpcaoSingle = int.Parse(Console.ReadLine());
            }

            if(OpcaoSingle == 1)
            {
                SinglePlayer = true;
            }

            //Opçao de Multplayer-----------------------------------------------------
            Console.WriteLine("Digite 1 caso tenha MultPlayer ou 0 caso não tenha: ");
            int OpcaoMult = int.Parse(Console.ReadLine());
            bool MultPlayer = false; 
            while (OpcaoMult > 1 || OpcaoMult < 0 )
            {
                Console.WriteLine("Opcao inválida!");
                Console.WriteLine("Digite 1 caso tenha MultPlayer ou 0 caso não tenha: ");
                OpcaoMult = int.Parse(Console.ReadLine());
            }
            if(OpcaoMult == 1)
            {
                MultPlayer = true;
            }

            
            //Cria Jogo
            Jogos Jogo = new Jogos( id: idJogo, 
                                        genero: (Genero)Genero, 
                                        nome: Nome, 
                                        descricao: Descricao,
                                        dev: Desenvolvedora, 
                                        ano: Ano,
                                        single: SinglePlayer, 
                                        mult: MultPlayer);

            return Jogo;
        }
    }
}