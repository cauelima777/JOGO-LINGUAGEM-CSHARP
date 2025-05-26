using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Mundo
{
    public static class LoreDosInimigos
    {
        private static Dictionary<string, string> loreInimigos = new Dictionary<string, string>
        {
            { "Soldado de Bronze", "Antigo defensor dos portões de Valvulândia, agora controlado por Maldrik através de engrenagens corrompidas." },
            { "Canhão Ambulante", "Construído para demolir paredes de aço, hoje é usado para esmagar rebeldes." },
            { "Sentinela de Vapor", "Projetada para vigiar as ruas enfumaçadas, essa máquina nunca dorme, nunca hesita." },
            { "Engrenador Sombrio", "Um mecanismo misterioso vindo dos subterrâneos, seu olhar queima como brasa." },
            { "Golem de Ferrugem", "Criado a partir de peças descartadas, ele se move lentamente, mas com força destrutiva." },
            { "Drone de Inspeção", "Antes usado para manutenções, agora espia e ataca qualquer movimento suspeito." },
            { "Besta a Vapor", "Uma fera criada em laboratório, alimentada por vapor e ódio programado." },
            { "Servo de Maldrik", "Um dos primeiros robôs pessoais do tirano, transformado em guarda-costas letal." },
            { "Autômato Veloz", "Projetado para corridas e entregas rápidas, agora uma arma ágil e mortal." },
            { "Guardião das Fornalhas", "Protege os fornos centrais de Valvulândia — último obstáculo antes do castelo." },
            { "👑 Rei Maldrik", "O próprio tirano de ferro. Cruel, frio e obcecado pelo Núcleo Eterno." }
        };

        public static string ObterHistoria(string nomeInimigo)
        {
            return loreInimigos.TryGetValue(nomeInimigo, out var historia)
                ? historia
                : "Nenhuma informação disponível sobre esse inimigo.";
        }
    }
}
