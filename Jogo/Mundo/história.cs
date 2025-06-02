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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      ⚙️  *OFICINA DAS CENTELHAS* ⚙️                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("🕰️ Ano 2894. Em um mundo movido por vapor, engrenagens e ambição.");
            Console.WriteLine("A grande cidade de Valvulândia sobrevive envolta em névoa, fumaça e faíscas.");
            Console.WriteLine("Criaturas mecânicas percorrem os trilhos, enquanto aristocratas engravatados");
            Console.WriteLine("observam das alturas em dirigíveis a carvão.\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⚒️ Dentro de uma oficina esquecida pelo tempo, um robô operário desperta.");
            Console.WriteLine("Sem nome, sem passado. Apenas marcas enferrujadas e um número de série ilegível.");
            Console.WriteLine("Ele consertava caldeiras. Apertava parafusos. Obedecia ordens.");
            Console.WriteLine("Mas tudo mudou naquela manhã de fumaça e fogo...\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("🚨 Tropas do Rei Maldrik invadiram Valvulândia.");
            Console.WriteLine("Maldrik, o tirano de ferro, que governa com mão de cobre e coração de engrenagem fria.");
            Console.WriteLine("Ele procura uma peça lendária: o Núcleo Eterno — capaz de conceder poder infinito a quem a controlar.");
            Console.WriteLine("Para isso, destruirá tudo em seu caminho.\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("⚡ No calor do ataque, algo acendeu dentro daquele velho robô.");
            Console.WriteLine("Não era um curto-circuito... Era desejo. Era coragem. Era identidade.");
            Console.WriteLine("Ele não sabia seu nome, mas sabia que precisava lutar.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🔧 Com uma chave inglesa em mãos e vapor no peito, ele parte...");
            Console.WriteLine("...não por vingança. Mas por justiça. Por liberdade.");
            Console.WriteLine("\nSua jornada começa agora.\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("⚙️ Prepare-se para girar as engrenagens do destino...");
            Console.WriteLine("Pressione qualquer tecla para continuar.");

            Console.ReadKey();

            // PARAR
            if (player != null)
            {
                player.Stop();
            }

            Console.ResetColor();
            Console.Clear();
        }
    }
}
