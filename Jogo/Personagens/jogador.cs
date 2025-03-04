using System;

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

        public void Atacar(Inimigo inimigo)
        {
            int dano = new Random().Next(10, 20);
            inimigo.SofrerDano(dano);
            Console.WriteLine($"{Nome} atacou {inimigo.Nome} e causou {dano} de dano!");
        }

        public void UsarHabilidadeEspecial(Inimigo inimigo)
        {
            int dano = new Random().Next(20, 30);
            inimigo.SofrerDano(dano);
            Console.WriteLine($"{Nome} usou uma habilidade especial em {inimigo.Nome} e causou {dano} de dano!");
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
            if (Vida > 100) Vida = 100; // Limita a vida máxima a 100
            Console.WriteLine($"{Nome} se curou em {cura} pontos! Vida atual: {Vida}");
        }
    }
}