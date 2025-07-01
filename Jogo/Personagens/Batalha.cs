using System;
using System.Media;
using SeuProjeto.Personagens;

namespace SeuProjeto.Jogo
{
    public class Batalha
    {
        private Jogador jogador;
        private Inimigo inimigo;
        private SoundPlayer player;

        public Batalha(Jogador jogador, Inimigo inimigo)
        {
            this.jogador = jogador;
            this.inimigo = inimigo;
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

        public void Iniciar()
        {
  
            string caminhoMusica = @"C:\Users\clevi\OneDrive\Documentos\GitHub\JOGO-LINGUAGEM-CSHARP\Jogo\Assets\batalha.wav";

            try
            {
                player = new SoundPlayer(caminhoMusica);
                player.PlayLooping();  
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro ao tocar música: " + ex.Message);
                Console.ResetColor();
                Console.ReadKey();
            }

            Console.Clear();

            EscreverCentralizado("╔════════════════════════════════════════════════════════════════╗", ConsoleColor.Cyan);
            EscreverCentralizado($"⚔️ BATALHA: {jogador.Nome.ToUpper()} VS {inimigo.Nome.ToUpper()} ⚔️", ConsoleColor.Cyan);
            EscreverCentralizado("╚════════════════════════════════════════════════════════════════╝", ConsoleColor.Cyan);
            Console.WriteLine();

            jogador.ReiniciarHabilidadeEspecial();

            while (jogador.Vida > 0 && inimigo.Vida > 0)
            {
                Console.WriteLine();

                EscreverCentralizado("SEU TURNO", ConsoleColor.Yellow);
                EscreverCentralizado("1 - Atacar", ConsoleColor.Yellow);
                EscreverCentralizado("2 - Usar Ferramenta Giratória (Habilidade Especial)", ConsoleColor.Yellow);
                EscreverCentralizado("3 - Repor Óleo (Curar)", ConsoleColor.Yellow);
                Console.WriteLine();

                EscreverCentralizado("Escolha uma ação: ", ConsoleColor.White);
                Console.SetCursorPosition((Console.WindowWidth / 2) + 9, Console.CursorTop - 1);
                string escolha = Console.ReadLine();

                Console.Clear();

                switch (escolha)
                {
                    case "1":
                        EscreverCentralizado($"Você ataca {inimigo.Nome}!", ConsoleColor.Green);
                        jogador.Atacar(inimigo);
                        break;
                    case "2":
                        EscreverCentralizado($"Você usa a habilidade especial contra {inimigo.Nome}!", ConsoleColor.Magenta);
                        jogador.UsarHabilidadeEspecial(inimigo);
                        break;
                    case "3":
                        jogador.Curar(15);
                        EscreverCentralizado($"{jogador.Nome} repôs 15 de óleo (vida).", ConsoleColor.Blue);
                        break;
                    default:
                        EscreverCentralizado("Ação inválida! Você perdeu o turno!", ConsoleColor.Red);
                        break;
                }

                if (inimigo.Vida <= 0)
                {
                    EscreverCentralizado($"✅ {inimigo.Nome} foi derrotado!", ConsoleColor.Green);
                    jogador.GanharExperiencia(50);
                    break;
                }

                EscreverCentralizado("TURN DO INIMIGO", ConsoleColor.Red);
                inimigo.Atacar(jogador);

                if (jogador.Vida <= 0)
                {
                    EscreverCentralizado($"❌ {jogador.Nome} foi destruído!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine();

                EscreverCentralizado("📊 STATUS", ConsoleColor.Cyan);
                EscreverCentralizado($"{jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima} HP", ConsoleColor.Cyan);
                EscreverCentralizado($"{inimigo.Nome}: {inimigo.Vida} HP", ConsoleColor.Cyan);
            }

       
            if (player != null)
            {
                player.Stop();
            }

            Console.WriteLine();
            EscreverCentralizado("⚙️ Batalha encerrada.", ConsoleColor.DarkGray);
            Console.WriteLine();
        }
    }
}
