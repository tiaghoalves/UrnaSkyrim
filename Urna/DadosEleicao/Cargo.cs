using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosEleicao
{
    public class Cargo
    {
        public int IDCargo { get; private set; }
        public string Nome { get; private set; }
        public char Situacao { get; set; }

        public Cargo(string nome, char situacao)
        {
            this.Nome = nome;
            this.Situacao = situacao;
        }

        public Cargo(string nome)
        {
            this.Nome = nome;
            this.Situacao = 'A';
        }

    }
}
