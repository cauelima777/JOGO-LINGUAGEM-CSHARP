using System;
using System.Collections.Generic;

namespace SeuProjeto.Personagens
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public int Vida { get; set; }
        public int VidaMaxima { get; set; }
        public int Moedas { get; set; }
        private int usosHabilidadeEspecial;
        public List<PecasSobressalentes> PecasSobressalentes { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Vida = 100;
            VidaMaxima = 100;
            Moedas = 50;
            usosHabilidadeEspecial = 2;
            PecasSobressalentes = new List<PecasSobressalentes>();
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
            if (Vida > VidaMaxima) Vida = VidaMaxima;
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

        public void GanharMoedas(int quantidade)
        {
            Moedas += quantidade;
            Console.WriteLine($"Você ganhou {quantidade} moedas! Total: {Moedas}");
        }

        public void ComprarPeca(PecasSobressalentes peca)
        {
            if (Moedas >= peca.Preco)
            {
                Moedas -= peca.Preco;
                PecasSobressalentes.Add(peca);
                Console.WriteLine($"Você comprou {peca.Nome} por {peca.Preco} moedas!");
            }
            else
            {
                Console.WriteLine("Moedas insuficientes para comprar esta peça!");
            }
        }

        public void ListarPecas()
        {
            Console.WriteLine("\n📦 Peças Sobressalentes:");
            if (PecasSobressalentes.Count == 0)
            {
                Console.WriteLine("Você não possui peças sobressalentes.");
                return;
            }

            for (int i = 0; i < PecasSobressalentes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {PecasSobressalentes[i].Nome}");
            }
        }

        public void MostrarStatus()
        {
            
            Console.WriteLine("\n📊 Status do Jogador:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Vida: {Vida}/{VidaMaxima}");
            Console.WriteLine($"Moedas: {Moedas}");
            Console.WriteLine($"Peças: {PecasSobressalentes.Count} ({(PecasSobressalentes.FindAll(p => p.EstaEquipada).Count)} equipadas)");
        }
    }
}