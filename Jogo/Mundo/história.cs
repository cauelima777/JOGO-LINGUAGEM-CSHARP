using System;
using System.Media;

namespace SeuProjeto.Mundo
{
    class Historia
    {
        public static void Introducao()
        {
            string caminhoMusica = @"C:\Users\clevi\OneDrive\Documentos\GitHub\JOGO-LINGUAGEM-CSHARP\Jogo\Assets\musica.wav";

            SoundPlayer player = null;

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

            // Centralização
            int larguraConsole = Console.WindowWidth;
            void EscreverCentralizado(string texto, ConsoleColor cor = ConsoleColor.White)
            {
                Console.ForegroundColor = cor;
                int pos = Math.Max(0, (larguraConsole - texto.Length) / 2);
                Console.SetCursorPosition(pos, Console.CursorTop);
                Console.WriteLine(texto);
            }

            EscreverCentralizado("╔══════════════════════════════════════════════════════════════════════╗", ConsoleColor.Cyan);
            EscreverCentralizado("║                      ⚙️  *OFICINA DAS ENGRENAGENS* ⚙️                ║", ConsoleColor.Cyan);
            EscreverCentralizado("╚══════════════════════════════════════════════════════════════════════╝\n", ConsoleColor.Cyan);

            EscreverCentralizado("🕰️ Ano 2894. Em um mundo movido por vapor, engrenagens e ambição.", ConsoleColor.Yellow);
            EscreverCentralizado("A grande cidade de Valvulândia sobrevive envolta em névoa, fumaça e faíscas.", ConsoleColor.Yellow);
            EscreverCentralizado("Criaturas mecânicas percorrem os trilhos, enquanto aristocratas engravatados", ConsoleColor.Yellow);
            EscreverCentralizado("observam das alturas em dirigíveis a carvão.\n", ConsoleColor.Yellow);

            EscreverCentralizado("⚒️ Dentro de uma oficina esquecida pelo tempo, um robô operário desperta.", ConsoleColor.Magenta);
            EscreverCentralizado("Sem nome, sem passado. Apenas marcas enferrujadas e um número de série ilegível.", ConsoleColor.Magenta);
            EscreverCentralizado("Ele consertava caldeiras. Apertava parafusos. Obedecia ordens.", ConsoleColor.Magenta);
            EscreverCentralizado("Mas tudo mudou naquela manhã de fumaça e fogo...\n", ConsoleColor.Magenta);

            EscreverCentralizado("🚨 Tropas do Rei Maldrik invadiram Valvulândia.", ConsoleColor.Red);
            EscreverCentralizado("Maldrik, o tirano de ferro, que governa com mão de cobre e coração de engrenagem fria.", ConsoleColor.Red);
            EscreverCentralizado("Ele procura uma peça lendária: o Núcleo Eterno — capaz de conceder poder infinito a quem a controlar.", ConsoleColor.Red);
            EscreverCentralizado("Para isso, destruirá tudo em seu caminho.\n", ConsoleColor.Red);

            EscreverCentralizado("⚡ No calor do ataque, algo acendeu dentro daquele velho robô.", ConsoleColor.DarkYellow);
            EscreverCentralizado("Não era um curto-circuito... Era desejo. Era coragem. Era identidade.", ConsoleColor.DarkYellow);
            EscreverCentralizado("Ele não sabia seu nome, mas sabia que precisava lutar.\n", ConsoleColor.DarkYellow);

            EscreverCentralizado("🔧 Com uma chave inglesa em mãos e vapor no peito, ele parte...", ConsoleColor.Green);
            EscreverCentralizado("...não por vingança. Mas por justiça. Por liberdade.", ConsoleColor.Green);
            EscreverCentralizado("\nSua jornada começa agora.\n", ConsoleColor.Green);

            EscreverCentralizado("⚙️ Prepare-se para girar as engrenagens do destino...", ConsoleColor.Cyan);
            EscreverCentralizado("Pressione qualquer tecla para continuar.", ConsoleColor.Cyan);

            Console.ReadKey();

            if (player != null)
                player.Stop();

            Console.ResetColor();
            Console.Clear();
        }
    }
}
