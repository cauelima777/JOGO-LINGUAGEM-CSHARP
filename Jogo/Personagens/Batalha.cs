using System;
using SeuProjeto.Personagens;

namespace SeuProjeto.Jogo
{
    class Batalha
    {
        private Jogador jogador;
        private Inimigo inimigo;

        public Batalha(Jogador jogador, Inimigo inimigo)
        {
            this.jogador = jogador;
            this.inimigo = inimigo;
        }

        public void Iniciar()
        {
            Console.WriteLine($"\nUma batalha começou entre {jogador.Nome} e {inimigo.Nome}!\n");

            while (jogador.Vida > 0 && inimigo.Vida > 0)
            {
                // Turno do jogador
                Console.WriteLine("\nSeu turno:");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar habilidade especial");
                Console.WriteLine("3 - Curar");
                Console.Write("Escolha uma ação: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        jogador.Atacar(inimigo);
                        break;
                    case "2":
                        jogador.UsarHabilidadeEspecial(inimigo);
                        break;
                    case "3":
                        jogador.Curar(15); // Cura 15 pontos de vida
                        break;
                    default:
                        Console.WriteLine("Ação inválida. Você perdeu o turno!");
                        break;
                }

                // Verifica se o inimigo foi derrotado
                if (inimigo.Vida <= 0)
                {
                    Console.WriteLine($"\n{inimigo.Nome} foi derrotado!");
                    break;
                }

                // Turno do inimigo
                Console.WriteLine("\nTurno do inimigo:");
                inimigo.Atacar(jogador);

                // Verifica se o jogador foi derrotado
                if (jogador.Vida <= 0)
                {
                    Console.WriteLine($"\n{jogador.Nome} foi derrotado!");
                    break;
                }

                // Exibe status após cada turno
                Console.WriteLine("\nStatus após o turno:");
                Console.WriteLine($"{jogador.Nome}: {jogador.Vida} HP");
                Console.WriteLine($"{inimigo.Nome}: {inimigo.Vida} HP");
            }

            Console.WriteLine("\nA batalha terminou!");
        }
    }
}