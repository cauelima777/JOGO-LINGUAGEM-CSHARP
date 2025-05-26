using System;
using SeuProjeto.Personagens;
using SeuProjeto.Mundo;

namespace SeuProjeto.Jogo
{
    public class Jogo
    {
        private Jogador jogador;
        private Loja loja;

        public Jogo()
        {
            loja = new Loja();
        }

        public void Iniciar()
        {
            Historia.Introducao();

            Console.Clear();
            Console.WriteLine("Bem-vindo ao jogo!\n");

            Console.Write("Digite o nome do seu robô: ");
            string nome = Console.ReadLine();
            jogador = new Jogador(nome);

            Console.WriteLine($"\n🔧 Bem-vindo, {jogador.Nome}!\n");

            string[] inimigos = new string[]
            {
                "Soldado de Bronze",
                "Canhão Ambulante",
                "Sentinela de Vapor",
                "Engrenador Sombrio",
                "Golem de Ferrugem",
                "Drone de Inspeção",
                "Besta a Vapor",
                "Servo de Maldrik",
                "Autômato Veloz",
                "Guardião das Fornalhas",
                "👑 Rei Maldrik"
            };

            for (int i = 0; i < inimigos.Length; i++)
            {
                MenuEntreBatalhas();

                if (jogador.Vida <= 0) break;

                string nomeInimigo = inimigos[i];
                Console.Clear();
                Console.WriteLine($"\n🔔 Missão {i + 1}: Derrote {nomeInimigo}!\n");

                MostrarHistoriaComInteracao(nomeInimigo, jogador.Nome);

                Console.WriteLine("\nPressione qualquer tecla para iniciar a batalha...");
                Console.ReadKey();

                Inimigo inimigo = new Inimigo(nomeInimigo, i < inimigos.Length - 1 ? 50 + i * 10 : 150);
                Batalha batalha = new Batalha(jogador, inimigo);
                batalha.Iniciar();

                if (jogador.Vida > 0)
                {
                    jogador.GanharMoedas(20 + i * 5);
                }
                else
                {
                    Console.WriteLine("\n⚰️ Você foi destruído no campo de batalha. Fim de linha.");
                    return;
                }
            }

            if (jogador.Vida > 0)
            {
                Console.WriteLine("\n🎉 Parabéns! Você derrotou o Rei Maldrik e libertou Valvulândia!");
                Console.WriteLine("A cidade pode finalmente respirar alívio. Um novo futuro começa.");
            }
        }

        private void MostrarHistoriaComInteracao(string inimigo, string nomeJogador)
        {
            Console.WriteLine("📖 Cena narrativa:\n");

            switch (inimigo)
            {
                case "Soldado de Bronze":
                    Console.WriteLine("Você adentra os limites enferrujados da Zona 1. As engrenagens rangem e o vapor sobe das rachaduras do solo.");
                    Console.WriteLine("Um vulto metálico caminha em sua direção: é o Soldado de Bronze, o primeiro obstáculo entre você e Valvulândia.");
                    Console.WriteLine("\n👮 Soldado de Bronze: \"Identificação, intruso. Você não tem permissão para prosseguir.\"");
                    Console.WriteLine($"🤖 {nomeJogador}: \"Minha permissão é minha vontade de libertar Valvulândia. Prepare-se.\"");
                    Console.WriteLine("👮 Soldado de Bronze: \"Iniciando protocolo de eliminação.\"");
                    break;

                case "Canhão Ambulante":
                    Console.WriteLine("As muralhas do Setor Beta tremem com o som de passos pesados.");
                    Console.WriteLine("O Canhão Ambulante surge, com suas armas carregadas com vapor fervente.");
                    Console.WriteLine("\n💣 Canhão Ambulante: \"Você será vaporizado antes de dar mais um passo.\"");
                    Console.WriteLine($"🤖 {nomeJogador}: \"Veremos quem vai parar quem.\"");
                    Console.WriteLine("💣 Canhão Ambulante: \"Mira travada. Eliminando.\"");
                    break;

                case "Sentinela de Vapor":
                    Console.WriteLine("Nuvens de vapor bloqueiam sua visão enquanto uma silhueta mecânica emerge.");
                    Console.WriteLine("A Sentinela de Vapor ergue sua lança incandescente.");
                    Console.WriteLine("\n🛡️ Sentinela de Vapor: \"Nenhum robô rebelde passa pela torre central.\"");
                    Console.WriteLine($"🤖 {nomeJogador}: \"Nem todo robô se curva ao sistema.\"");
                    Console.WriteLine("🛡️ Sentinela de Vapor: \"Prepare-se para ser desmantelado.\"");
                    break;

                // Adicione outras histórias aqui conforme desejar...

                case "👑 Rei Maldrik":
                    Console.WriteLine("Você atravessa o portão principal do Palácio das Fornalhas.");
                    Console.WriteLine("O ar está denso. Chamas e vapor dançam em volta do trono metálico.");
                    Console.WriteLine("👑 O próprio Rei Maldrik, criador da tirania, se ergue com seus braços flamejantes.");
                    Console.WriteLine("\n👑 Rei Maldrik: \"Então você chegou até aqui... um robô sonhador que acredita em liberdade.\"");
                    Console.WriteLine($"🤖 {nomeJogador}: \"E você é só mais uma engrenagem prestes a quebrar.\"");
                    Console.WriteLine("👑 Rei Maldrik: \"Venha, mostre-me se é digno de desafiar um rei!\"");
                    break;

                default:
                    Console.WriteLine("⚠️ História ainda não disponível para este inimigo.");
                    break;
            }
        }

        private void MenuEntreBatalhas()
        {
            while (true)
            {
                jogador.MostrarStatus();
                Console.WriteLine("\n1 - Continuar para próxima batalha");
                Console.WriteLine("2 - Visitar a loja");
                Console.WriteLine("3 - Ver peças sobressalentes");
                Console.WriteLine("4 - Sair do jogo");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        return;
                    case "2":
                        loja.Visitar(jogador);
                        break;
                    case "3":
                        GerenciarPecas();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void GerenciarPecas()
        {
            if (jogador.PecasSobressalentes.Count == 0)
            {
                Console.WriteLine("Você não possui peças sobressalentes.");
                return;
            }

            Console.WriteLine("\nSuas peças sobressalentes:");
            for (int i = 0; i < jogador.PecasSobressalentes.Count; i++)
            {
                jogador.PecasSobressalentes[i].ExibirInformacoes();
            }
        }
    }
}
