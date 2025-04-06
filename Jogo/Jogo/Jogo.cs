using System;
using SeuProjeto.Personagens;
using SeuProjeto.Mundo;

namespace SeuProjeto.Jogo
{
    class Jogo
    {
        private Jogador jogador;

        public void Iniciar()
        {
            Historia.Introducao();

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
                Console.WriteLine($"\n🚨 Missão {i + 1}: Derrote {inimigos[i]}!\n");

                Inimigo inimigo = new Inimigo(inimigos[i], i < inimigos.Length - 1 ? 50 + i * 10 : 150);
                Batalha batalha = new Batalha(jogador, inimigo);
                batalha.Iniciar();

                if (jogador.Vida <= 0)
                {
                    Console.WriteLine("\n⚰️ Você foi destruído no campo de batalha. Fim de linha.");
                    return;
                }
            }

            Console.WriteLine("\n🎉 Parabéns! Você derrotou o Rei Maldrik e libertou Valvulândia!");
            Console.WriteLine("A cidade pode finalmente respirar alívio. Um novo futuro começa.");
        }
    }
}
