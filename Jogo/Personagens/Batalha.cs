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
            Console.WriteLine($"\n⚔️ Batalha entre {jogador.Nome} e {inimigo.Nome}!\n");

            jogador.ReiniciarHabilidadeEspecial();

            while (jogador.Vida > 0 && inimigo.Vida > 0)
            {
                Console.WriteLine("\nSeu turno:");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar Ferramenta Giratória (Habilidade Especial)");
                Console.WriteLine("3 - Repor Óleo (Curar)");
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
                        jogador.Curar(15);
                        break;
                    default:
                        Console.WriteLine("Ação inválida. Você perdeu o turno!");
                        break;
                }

                if (inimigo.Vida <= 0)
                {
                    Console.WriteLine($"\n✅ {inimigo.Nome} foi derrotado!");
                    jogador.GanharExperiencia(50);
                    break;
                }

                Console.WriteLine("\nTurno do inimigo:");
                inimigo.Atacar(jogador);

                if (jogador.Vida <= 0)
                {
                    Console.WriteLine($"\n❌ {jogador.Nome} foi destruído!");
                    break;
                }

                Console.WriteLine("\n📊 Status:");
                Console.WriteLine($"{jogador.Nome}: {jogador.Vida} HP");
                Console.WriteLine($"{inimigo.Nome}: {inimigo.Vida} HP");
            }

            Console.WriteLine("\n⚙️ Batalha encerrada.");
        }
    }
}
