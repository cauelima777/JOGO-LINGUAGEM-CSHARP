using System;

namespace SeuProjeto.Personagens
{
    public class PecasSobressalentes
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int NivelRequerido { get; set; }
        public int Preco { get; set; }
        public int BonusVida { get; set; }
        public int BonusDano { get; set; }
        public bool EstaEquipada { get; private set; }

        public PecasSobressalentes(string nome, string tipo, int nivelRequerido, int preco, int bonusVida, int bonusDano)
        {
            Nome = nome;
            Tipo = tipo;
            NivelRequerido = nivelRequerido;
            Preco = preco;
            BonusVida = bonusVida;
            BonusDano = bonusDano;
            EstaEquipada = false;
        }

        public void Equipar(Jogador jogador)
        {
            EstaEquipada = true;
            jogador.Vida += BonusVida;
            Console.WriteLine($"{Nome} equipado! +{BonusVida} HP e +{BonusDano} de dano em ataques!");
        }

        public void Desequipar(Jogador jogador)
        {
            if (EstaEquipada)
            {
                EstaEquipada = false;
                jogador.Vida -= BonusVida;
                Console.WriteLine($"{Nome} desequipado!");
            }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Nível Requerido: {NivelRequerido}");
            Console.WriteLine($"Preço: {Preco} moedas");
            Console.WriteLine($"Bônus: +{BonusVida} HP, +{BonusDano} de dano");
            Console.WriteLine($"Equipada: {(EstaEquipada ? "Sim" : "Não")}\n");
        }
    }
}