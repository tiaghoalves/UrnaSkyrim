using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosEleicao
{
   class Candidato
    {
        public int IDCandidato { get; private set; }
        public string NomeCompleto { get; private set; }
        public string NomePopular { get; private set; }
        public int DataNascimento { get; private set; }
        public int RegistroTRE { get; private set; }
        public int IDPartido { get; private set; }
        public int Numero { get; private set; }
        public int IDCargo { get; private set; }
        public bool Exibe { get; private set; }

        public Candidato(String NomeCompleto, String NomePopular, int DataNascimento, int RegistroTRE, int IDPartido, int Numero, int IDCargo)
        {
            this.NomeCompleto = NomeCompleto;
            this.NomePopular = NomePopular;
            this.DataNascimento = DataNascimento;
            this.RegistroTRE = RegistroTRE;
            this.IDPartido = IDPartido;
            this.Numero = Numero;
            this.IDCargo = IDCargo;

        }
    }
}
