using System;
using System.Collections.Generic;
using System.Text;

namespace MTEngine.Regras
{
    public class CadastroDeRegraRequest
    {
        public string Nome { get; set; }

        public string PathDeCidades { get; set; }

        public string PathDoNomeDaCidade { get; set; }

        public string PathDoNumeroDeHabitantesDaCidade { get; set; }

        public string PathDeBairros { get; set; }

        public string PathDoNomeDoBairro { get; set; }

        public string PathDoNumeroDeHabitantesDoBairro { get; set; }

        public TipoDeFormato TipoDeFormato { get; set; }
    }
}
