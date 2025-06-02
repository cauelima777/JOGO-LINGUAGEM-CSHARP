using System;
using System.Collections.Generic;
using System.Media;
using SeuProjeto.Personagens;

namespace SeuProjeto.Mundo
{
    public class Loja
    {
        private List<PecasSobressalentes> estoque;
        private SoundPlayer player;

        public Loja()
        {
            estoque = new List<PecasSobressalentes>
            {
                new PecasSobressalentes("Juntas Reforçadas", "Defesa", 1, 30, 15, 0),
                new PecasSobressalentes("Serra Afiada", "Ataque", 1, 40, 0, 5),
                new PecasSobressalentes("Tanque de Óleo XL", "Vida", 2, 50, 25, 0),
                new PecasSobressalentes("Motor Turbo", "Ataque", 3, 70, 0, 10),
                new PecasSobressalentes("Blindagem de Aço", "Defesa", 4, 90, 40, 0),
                new PecasSobressalentes("Garras Giratórias", "Ataque", 5, 120, 0, 15)
            };

            player = new SoundPlayer(@"Assets\musica.wav");
        }

        private void EscreverCentralizado(string texto, ConsoleColor cor = ConsoleColor.White)
        {
            int larguraConsole = Console.WindowWidth;
            int posicao = (larguraConsole - texto.Length) / 2;
            if (posicao < 0) posicao = 0;
            Console.ForegroundColor = cor;
            Console.SetCursorPosition(posicao, Console.CursorTop);
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public void Visitar(Jogador jogador)
        {
            Console.Clear();

            try
            {
                player = new SoundPlayer(@"C:\Users\clevi\OneDrive\Documentos\GitHub\JOGO-LINGUAGEM-CSHARP\Jogo\Assets\loja.wav");

                player.PlayLooping();
            }
            catch
            {
                EscreverCentralizado("⚠️ Erro ao tentar tocar a música da loja.", ConsoleColor.Red);
            }

            EscreverCentralizado("╔════════════════════════════════════════════════════════════════╗", ConsoleColor.Cyan);
            EscreverCentralizado("🔧 LOJA DE PEÇAS SOBRESSALENTES 🔧", ConsoleColor.Cyan);
            EscreverCentralizado("╚════════════════════════════════════════════════════════════════╝", ConsoleColor.Cyan);
            Console.WriteLine();

            while (true)
            {
                EscreverCentralizado($"Moedas disponíveis: {jogador.Moedas}", ConsoleColor.Yellow);
                Console.WriteLine();

                EscreverCentralizado("1 - Comprar peças", ConsoleColor.Green);
                EscreverCentralizado("2 - Ver peças compradas", ConsoleColor.Green);
                EscreverCentralizado("3 - Equipar peças", ConsoleColor.Green);
                EscreverCentralizado("4 - Sair da loja", ConsoleColor.Green);
                Console.WriteLine();

                EscreverCentralizado("Escolha uma opção: ", ConsoleColor.White);
                Console.SetCursorPosition((Console.WindowWidth / 2) + 9, Console.CursorTop - 1);
                string opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        MostrarEstoque(jogador);
                        break;
                    case "2":
                        Console.Clear();
                        EscreverCentralizado("Peças Compradas", ConsoleColor.Magenta);
                        Console.WriteLine();
                        jogador.ListarPecas();
                        Console.WriteLine("\nPressione qualquer tecla para voltar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        GerenciarEquipamentos(jogador);
                        break;
                    case "4":
                        EscreverCentralizado("\nObrigado pela visita! Volte sempre!", ConsoleColor.Cyan);
                        Console.WriteLine();
                        player.Stop(); // Para a música ao sair da loja
                        return;
                    default:
                        EscreverCentralizado("Opção inválida! Tente novamente.", ConsoleColor.Red);
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void MostrarEstoque(Jogador jogador)
        {
            Console.Clear();
            EscreverCentralizado("╔════════════════════ ESTOQUE DA LOJA ════════════════════╗", ConsoleColor.Cyan);
            Console.WriteLine();

            for (int i = 0; i < estoque.Count; i++)
            {
                var peca = estoque[i];
                EscreverCentralizado($"{i + 1} - {peca.Nome} (Preço: {peca.Preco} moedas)", ConsoleColor.Green);
                EscreverCentralizado($"    +{peca.BonusVida} HP, +{peca.BonusDano} de dano", ConsoleColor.White);
                Console.WriteLine();
            }

            EscreverCentralizado("Digite o número da peça que deseja comprar (ou 0 para voltar):", ConsoleColor.Yellow);
            Console.SetCursorPosition((Console.WindowWidth / 2) + 18, Console.CursorTop - 1);
            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                if (escolha == 0)
                {
                    Console.Clear();
                    return;
                }
                else if (escolha > 0 && escolha <= estoque.Count)
                {
                    jogador.ComprarPeca(estoque[escolha - 1]);
                }
                else
                {
                    EscreverCentralizado("Escolha inválida. Pressione qualquer tecla para voltar.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
            else
            {
                EscreverCentralizado("Entrada inválida. Pressione qualquer tecla para voltar.", ConsoleColor.Red);
                Console.ReadKey();
            }
            Console.Clear();
        }

        private void GerenciarEquipamentos(Jogador jogador)
        {
            Console.Clear();

            if (jogador.PecasSobressalentes.Count == 0)
            {
                EscreverCentralizado("Você não possui peças para equipar.", ConsoleColor.Red);
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            EscreverCentralizado("╔══════════════ PEÇAS DISPONÍVEIS PARA EQUIPAR ══════════════╗", ConsoleColor.Cyan);
            Console.WriteLine();

            for (int i = 0; i < jogador.PecasSobressalentes.Count; i++)
            {
                var peca = jogador.PecasSobressalentes[i];
                string status = peca.EstaEquipada ? "Equipada" : "Não equipada";
                ConsoleColor corStatus = peca.EstaEquipada ? ConsoleColor.Green : ConsoleColor.Gray;

                EscreverCentralizado($"{i + 1} - {peca.Nome} ({status})", corStatus);
            }

            Console.WriteLine();
            EscreverCentralizado("Digite o número da peça para equipar/desequipar (ou 0 para voltar):", ConsoleColor.Yellow);
            Console.SetCursorPosition((Console.WindowWidth / 2) + 25, Console.CursorTop - 1);

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                if (escolha == 0)
                {
                    Console.Clear();
                    return;
                }
                else if (escolha > 0 && escolha <= jogador.PecasSobressalentes.Count)
                {
                    var peca = jogador.PecasSobressalentes[escolha - 1];
                    if (peca.EstaEquipada)
                    {
                        peca.Desequipar(jogador);
                        EscreverCentralizado($"{peca.Nome} foi desequipada.", ConsoleColor.Red);
                    }
                    else
                    {
                        peca.Equipar(jogador);
                        EscreverCentralizado($"{peca.Nome} foi equipada.", ConsoleColor.Green);
                    }
                }
                else
                {
                    EscreverCentralizado("Escolha inválida. Pressione qualquer tecla para voltar.", ConsoleColor.Red);
                }
            }
            else
            {
                EscreverCentralizado("Entrada inválida. Pressione qualquer tecla para voltar.", ConsoleColor.Red);
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
