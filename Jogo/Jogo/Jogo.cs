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

                Console.WriteLine($"\n🚨 Missão {i + 1}: Derrote {inimigos[i]}!\n");

                Inimigo inimigo = new Inimigo(inimigos[i], i < inimigos.Length - 1 ? 50 + i * 10 : 150);
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

            Console.WriteLine("\n⚙️ Suas peças sobressalentes:");
            for (int i = 0; i < jogador.PecasSobressalentes.Count; i++)
            {
                jogador.PecasSobressalentes[i].ExibirInformacoes();
            }
        }
    }
}