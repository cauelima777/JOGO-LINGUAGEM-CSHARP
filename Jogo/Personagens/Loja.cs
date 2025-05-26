using System;
using System.Collections.Generic;
using SeuProjeto.Personagens;

namespace SeuProjeto.Mundo
{
    public class Loja
    {
        private List<PecasSobressalentes> estoque;

        public Loja()
        {
            estoque = new List<PecasSobressalentes>
            {

                // PEÇA - TIPO DEFESA - NÍVEL - CUSTO - QUANTO DE HP - QUANTO DE DANO
                new PecasSobressalentes("Juntas Reforçadas", "Defesa", 1, 30, 15, 0),
                new PecasSobressalentes("Serra Afiada", "Ataque", 1, 40, 0, 5),
                new PecasSobressalentes("Tanque de Óleo XL", "Vida", 2, 50, 25, 0),
                new PecasSobressalentes("Motor Turbo", "Ataque", 3, 70, 0, 10),
                new PecasSobressalentes("Blindagem de Aço", "Defesa", 4, 90, 40, 0),
                new PecasSobressalentes("Garras Giratórias", "Ataque", 5, 120, 0, 15)
            };
        }

        public void Visitar(Jogador jogador)
        {
            Console.WriteLine("\n🔧 Bem-vindo à Loja de Peças Sobressalentes!");
            Console.WriteLine("Aqui você pode melhorar seu robô com peças incríveis!\n");

            while (true)
            {
                Console.WriteLine($"\n Moedas: {jogador.Moedas}");
                Console.WriteLine("\n1 - Comprar peças");
                Console.WriteLine("2 - Ver peças compradas");
                Console.WriteLine("3 - Equipar peças");
                Console.WriteLine("4 - Sair da loja");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MostrarEstoque(jogador);
                        break;
                    case "2":
                        jogador.ListarPecas();
                        break;
                    case "3":
                        GerenciarEquipamentos(jogador);
                        break;
                    case "4":
                        Console.WriteLine("\nObrigado pela visita! Volte sempre!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }


// +++++++++++++++++++++++++++++++++++Verificar++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void MostrarEstoque(Jogador jogador)
        {
            Console.WriteLine("\n Estoque da Loja:");
            for (int i = 0; i < estoque.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {estoque[i].Nome} ({estoque[i].Preco} moedas)");
                Console.WriteLine($"   +{estoque[i].BonusVida} HP, +{estoque[i].BonusDano} de dano");
            }

            Console.Write("\nDigite o número da peça que deseja comprar (ou 0 para voltar): ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= estoque.Count)
            {
                jogador.ComprarPeca(estoque[escolha - 1]);
            }
        }

        private void GerenciarEquipamentos(Jogador jogador)
        {
            if (jogador.PecasSobressalentes.Count == 0)
            {
                Console.WriteLine("Você não possui peças para equipar.");
                return;
            }

            Console.WriteLine("\n Peças disponíveis para equipar:");
            for (int i = 0; i < jogador.PecasSobressalentes.Count; i++)
            {
                var peca = jogador.PecasSobressalentes[i];
                Console.WriteLine($"{i + 1} - {peca.Nome} ({(peca.EstaEquipada ? "Equipada" : "Não equipada")})");
            }

            Console.Write("\nDigite o número da peça para equipar/desequipar (ou 0 para voltar): ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= jogador.PecasSobressalentes.Count)
            {
                var peca = jogador.PecasSobressalentes[escolha - 1];
                if (peca.EstaEquipada)
                {
                    peca.Desequipar(jogador);
                }
                else
                {
                    peca.Equipar(jogador);
                }
            }
        }
    }
}