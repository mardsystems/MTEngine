using MTEngine.Regras;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MTEngine.Transformacoes
{
    public class TransformacaoDeMensagensService : ITransformacaoDeMensagens
    {
        private readonly IRegrasRepository regrasRepository;

        private readonly TransformacaoDeMensagensXmlService transformacaoDeMensagensXmlService;

        public TransformacaoDeMensagensService(IRegrasRepository regrasRepository, TransformacaoDeMensagensXmlService transformacaoDeMensagensXmlService)
        {
            this.regrasRepository = regrasRepository;

            this.transformacaoDeMensagensXmlService = transformacaoDeMensagensXmlService;
        }

        public async Task<MensagemDeSaida> Transforma(MensagemDeEntrada mensagemDeEntrada)
        {
            var regra = await regrasRepository.ObtemRegraPeloNome(mensagemDeEntrada.Regra);

            XmlDocument mensagemXml;

            switch (regra.TipoDeFormato)
            {
                case TipoDeFormato.Xml:
                    mensagemXml = new XmlDocument();

                    mensagemXml.LoadXml(mensagemDeEntrada.Conteudo);

                    break;

                case TipoDeFormato.JSON:

                    mensagemXml = JsonConvert.DeserializeXmlNode(mensagemDeEntrada.Conteudo);

                    break;

                default:

                    throw new InvalidCastException();
            }

            var mensagem = await transformacaoDeMensagensXmlService.Transforma(mensagemXml, regra);

            var mensagemDeSaida = new MensagemDeSaida
            {
                Result = mensagem
            };

            return mensagemDeSaida;
        }
    }
}
