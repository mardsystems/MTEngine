using System;
using System.Collections.Generic;
using System.Text;

namespace MTEngine.Transformacoes
{
    public class RegistroDeCidade
    {
        public string Cidade { get; internal set; }

        public long Habitantes { get; internal set; }

        public virtual IEnumerable<Bairro> Bairros { get; internal set; }
    }
}
