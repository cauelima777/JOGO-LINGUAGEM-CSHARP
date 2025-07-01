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
            MostrarTelaBoasVindas();

            Console.Write("🛠️ Digite o nome do seu robô: ");
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
                EscreverBarra();
                EscreverCentralizado($"🚨 MISSÃO {i + 1} – DERROTE: {nomeInimigo} 🚨");
                EscreverBarra();
                Console.WriteLine();

                MostrarHistoriaComInteracao(nomeInimigo, jogador.Nome);
                EscreverCentralizado("\n🔫 Pressione qualquer tecla para iniciar a batalha...");
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
                    TelaGameOver();
                    return;
                }
            }

            if (jogador.Vida > 0)
            {
                TelaVitoria();
            }
        }

        private void MostrarTelaBoasVindas()
        {
            Console.Clear();
            EscreverBarra();
            EscreverCentralizado("🤖 BEM-VINDO A...");
            EscreverCentralizado(@"██╗   ██╗ █████╗ ██╗     ██╗   ██╗██╗     █████╗ ███╗   ██╗██████╗ ██╗ █████╗ 
██║   ██║██╔══██╗██║     ██║   ██║██║    ██╔══██╗████╗  ██║██╔══██╗██║██╔══██╗
██║   ██║███████║██║     ██║   ██║██║    ███████║██╔██╗ ██║██║  ██║██║███████║
╚██╗ ██╔╝██╔══██║██║     ██║   ██║██║    ██╔══██║██║╚██╗██║██║  ██║██║██╔══██║
 ╚████╔╝ ██║  ██║███████╗╚██████╔╝███████╗██║  ██║██║ ╚████║██████╔╝██║██║  ██║
  ╚═══╝  ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚═╝  ╚═╝");
            EscreverBarra();
            Console.WriteLine();
        }

        private void TelaVitoria()
        {
            Console.Clear();
            EscreverBarra();
            EscreverCentralizado("🎉 MISSÃO COMPLETA!");
            EscreverCentralizado("Você derrotou o 👑 Rei Maldrik e libertou Valvulândia!");
            EscreverCentralizado("⚙️ A cidade pode finalmente respirar alívio.");
            EscreverCentralizado("✨ Um novo futuro começa graças a você!");
            EscreverBarra();
        }

        private void TelaGameOver()
        {
            Console.Clear();
            EscreverBarra();
            EscreverCentralizado("⚰️ GAME OVER");
            EscreverCentralizado("Você foi destruído no campo de batalha.");
            EscreverCentralizado("Talvez em uma próxima versão... 🛠️");
            EscreverBarra();
        }

        private void MostrarHistoriaComInteracao(string inimigo, string nomeJogador)
        {
            Console.Clear();
            EscreverBarra();
            EscreverCentralizado("📖 CENA NARRATIVA");
            EscreverBarra();
            Console.WriteLine();

            switch (inimigo)
            {
                case "Soldado de Bronze":
                    EscreverCentralizado("⚙️ Zona 1: Você pisa no metal corroído e sente o vapor subindo.");
                    EscreverCentralizado("👮 Soldado de Bronze: \"Identifique-se, intruso.\"");
                    EscreverCentralizado($"🤖 {nomeJogador}: \"Minha identidade é liberdade.\"");
                    break;

                case "Canhão Ambulante":
                    EscreverCentralizado("💣 Passos pesados ecoam. Surge o Canhão Ambulante.");
                    EscreverCentralizado("💣: \"Você será vaporizado.\"");
                    EscreverCentralizado($"🤖 {nomeJogador}: \"Não antes de você.\"");
                    break;

                case "Sentinela de Vapor":
                    EscreverCentralizado("🌫️ A névoa densa revela uma lança incandescente.");
                    EscreverCentralizado("🛡️ Sentinela: \"Volte para seu posto, rebelde.\"");
                    EscreverCentralizado($"🤖 {nomeJogador}: \"Não sou mais peça do seu sistema!\"");
                    break;

                case "👑 Rei Maldrik":
                    EscreverCentralizado("🔥 Diante do Trono das Fornalhas, ele aguarda.");
                    EscreverCentralizado("👑 Maldrik: \"Liberdade é ilusão.\"");
                    EscreverCentralizado($"🤖 {nomeJogador}: \"Então eu sou a realidade.\"");
                    break;

                default:
                    EscreverCentralizado("⚠️ História não disponível para este inimigo.");
                    break;
            }
        }

        private void MenuEntreBatalhas()
        {
            while (true)
            {
                Console.Clear();
                EscreverBarra();
                EscreverCentralizado("🛠️ MENU ENTRE MISSÕES");
                EscreverBarra();
                jogador.MostrarStatus();

                Console.WriteLine();
                Console.WriteLine("1️⃣ - Continuar para a próxima missão");
                Console.WriteLine("2️⃣ - Visitar a loja 🔧");
                Console.WriteLine("3️⃣ - Ver peças sobressalentes 🔩");
                Console.WriteLine("4️⃣ - Sair do jogo ❌");
                Console.Write("\nEscolha uma opção: ");

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
                        Console.WriteLine("❌ Opção inválida! Pressione uma tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GerenciarPecas()
        {
            Console.Clear();
            EscreverBarra();
            EscreverCentralizado("🔩 PEÇAS SOBRESSALENTES");
            EscreverBarra();

            if (jogador.PecasSobressalentes.Count == 0)
            {
                EscreverCentralizado("🧰 Você não possui peças sobressalentes.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            for (int i = 0; i < jogador.PecasSobressalentes.Count; i++)
            {
                jogador.PecasSobressalentes[i].ExibirInformacoes();
            }

            Console.WriteLine("\nPressione uma tecla para voltar...");
            Console.ReadKey();
        }

        private void EscreverCentralizado(string texto)
        {
            int larguraConsole = Console.WindowWidth;
            int posicaoX = Math.Max((larguraConsole - texto.Length) / 2, 0);
            Console.SetCursorPosition(posicaoX, Console.CursorTop);
            Console.WriteLine(texto);
        }

        private void EscreverBarra()
        {
            Console.WriteLine(new string('═', Console.WindowWidth));
        }
    }
}
