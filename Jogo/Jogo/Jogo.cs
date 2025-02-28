using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeuProjeto.Personagens; // Importando a pasta de Personagens


namespace SeuProjeto.Jogo
{
    class Jogo
    {
        private Jogador jogador;

        public void Iniciar()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            jogador = new Jogador(nome);

            Console.WriteLine($"\nBem-vindo, {jogador.Nome}!\n");
            LoopPrincipal();
        }

        private void LoopPrincipal()
        {
            bool jogando = true;

            while (jogando)
            {
                Console.WriteLine("\nEscolha uma ação:");
                Console.WriteLine("1 - Explorar");
                Console.WriteLine("2 - Descansar");
                Console.WriteLine("3 - Sair");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Explorar();
                        break;
                    case "2":
                        jogador.Curar(10);
                        break;
                    case "3":
                        jogando = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida.");
                        break;
                }
            }

            Console.WriteLine("\nObrigado por jogar!");
        }

        private void Explorar()
        {
            Console.WriteLine("\nVocê encontrou um inimigo!");
            jogador.SofrerDano(20);
        }
    }
}

