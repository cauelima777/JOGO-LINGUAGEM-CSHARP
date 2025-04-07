using System;

namespace SeuProjeto.Personagens
{
    class Jogador
    {
        public string Nome { get; private set; }
        public int Vida { get; private set; }
        private int usosHabilidadeEspecial;

        public Jogador(string nome)
        {
            Nome = nome;
            Vida = 100;
            usosHabilidadeEspecial = 2;
        }

        public void Atacar(Inimigo inimigo)
        {
            int dano = new Random().Next(0, 20);
            inimigo.SofrerDano(dano);
            Console.WriteLine($"{Nome} atacou {inimigo.Nome} e causou {dano} de dano!");
        }

        public void UsarHabilidadeEspecial(Inimigo inimigo)
        {
            if (usosHabilidadeEspecial > 0)
            {
                int dano = new Random().Next(15, 25);
                inimigo.SofrerDano(dano);
                usosHabilidadeEspecial--;
                Console.WriteLine($"{Nome} usou Ferramenta Giratória em {inimigo.Nome} causando {dano} de dano! ({usosHabilidadeEspecial} uso(s) restante(s))");
                    

            }
            else
            {
                Console.WriteLine("⚠️ Habilidade especial esgotada nesta batalha.");
            }
        }

        public void Curar(int cura)
        {   
            Vida += cura;
            if (Vida > 100) Vida = 100;
            Console.WriteLine($"{Nome} repôs óleo e curou {cura} pontos! Vida atual: {Vida}");
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"{Nome} sofreu {dano} de dano! Vida restante: {Vida}");
        }

        public void ReiniciarHabilidadeEspecial()
        {
            usosHabilidadeEspecial = 2;
        }

        public void GanharExperiencia(int xp)
        {
            Console.WriteLine($"{Nome} ganhou {xp} de experiência!");
        }
    }
}
