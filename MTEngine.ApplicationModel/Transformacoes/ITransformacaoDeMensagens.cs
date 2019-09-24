using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTEngine.Transformacoes
{
    /// <summary>
    /// Interface de transformação de mensagens.
    /// </summary>
    public interface ITransformacaoDeMensagens
    {
        Task<MensagemDeSaida> Transforma(MensagemDeEntrada mensagemDeEntrada);
    }
}
