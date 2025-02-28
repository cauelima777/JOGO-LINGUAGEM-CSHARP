using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuProjeto.Personagens
{
    class Jogador
    {
        public string Nome { get; private set; }
        public int Vida { get; private set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Vida = 100;
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"{Nome} sofreu {dano} de dano! Vida restante: {Vida}");
        }

        public void Curar(int cura)
        {
            Vida += cura;
            Console.WriteLine($"{Nome} se curou em {cura} pontos! Vida atual: {Vida}");
        }
    }
}
