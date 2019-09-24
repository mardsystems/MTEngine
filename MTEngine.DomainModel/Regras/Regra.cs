using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Text;

namespace MTEngine.Regras
{
    /// <summary>
    /// Regra de transformação de diversos tipos de formatos de entrada.
    /// </summary>
    public class Regra : Entity
    {
        public string Nome { get; internal set; }

        public string PathDeCidades { get; internal set; }

        public string PathDoNomeDaCidade { get; internal set; }

        public string PathDoNumeroDeHabitantesDaCidade { get; internal set; }

        public string PathDeBairros { get; internal set; }

        public string PathDoNomeDoBairro { get; internal set; }

        public string PathDoNumeroDeHabitantesDoBairro { get; internal set; }

        public TipoDeFormato TipoDeFormato { get; internal set; }
    }
}
