using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Personagens
{

    public class PecasSobressalentes
    {
        // Atributos
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int NivelRequerido { get; set; }
        public bool EstaEquipada { get; private set; }

        // Métodos
        public void Equipar()
        {
            EstaEquipada = true;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Tipo: {Tipo}, Nível Requerido: {NivelRequerido}, Equipada: {EstaEquipada}");
        }
    }

}
