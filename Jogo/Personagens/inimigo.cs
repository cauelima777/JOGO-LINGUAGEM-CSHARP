using System;

namespace SeuProjeto.Personagens
{
    class Inimigo
    {
        public string Nome { get; private set; }
        public int Vida { get; private set; }

        public Inimigo(string nome, int vida)
        {
            Nome = nome;
            Vida = vida;
        }

        public void Atacar(Jogador jogador)
        {
            int dano = new Random().Next(10, 20);
            jogador.SofrerDano(dano);
            Console.WriteLine($"{Nome} atacou {jogador.Nome} e causou {dano} de dano!");
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"{Nome} sofreu {dano} de dano! Vida restante: {Vida}");
        }
    }
}