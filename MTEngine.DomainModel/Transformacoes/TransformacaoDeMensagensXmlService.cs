using MTEngine.Regras;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MTEngine.Transformacoes
{
    public class TransformacaoDeMensagensXmlService
    {
        public TransformacaoDeMensagensXmlService()
        {

        }

        public async Task<RegistroDeCidade[]> Transforma(XmlDocument mensagemXml, Regra regra)
        {
            var cidadeNodes = mensagemXml.SelectNodes(regra.PathDeCidades);

            var cidades = new List<RegistroDeCidade>(cidadeNodes.Count);

            for (int i = 0; i < cidadeNodes.Count; i++)
            {
                var cidadeNode = cidadeNodes[i];

                var bairrosNodes = cidadeNode.SelectNodes(regra.PathDeBairros);

                var bairros = new List<Bairro>(bairrosNodes.Count);

                for (int j = 0; j < bairrosNodes.Count; j++)
                {
                    var bairrosNode = bairrosNodes[j];

                    var bairro = new Bairro
                    {
                        Nome = bairrosNode.SelectField(regra.PathDoNomeDoBairro, nameof(regra.PathDoNomeDoBairro)),
                        Habitantes = Convert.ToInt64(bairrosNode.SelectField(regra.PathDoNumeroDeHabitantesDoBairro, nameof(regra.PathDoNumeroDeHabitantesDoBairro)))
                    };

                    bairros.Add(bairro);
                }

                var cidade = new RegistroDeCidade
                {
                    Cidade = cidadeNode.SelectField(regra.PathDoNomeDaCidade, nameof(regra.PathDoNomeDaCidade)),
                    Habitantes = Convert.ToInt64(cidadeNode.SelectField(regra.PathDoNumeroDeHabitantesDaCidade, nameof(regra.PathDoNumeroDeHabitantesDaCidade))),
                    Bairros = bairros.ToArray()
                };

                cidades.Add(cidade);
            }

            return await Task.FromResult(cidades.ToArray());
        }
    }

    internal static class XmlNodeExtension
    {
        internal static string SelectField(this XmlNode node, string path, string nomeDoCampo)
        {
            var nodes = node.SelectNodes(path);

            if (nodes.Count == 0)
            {
                throw new ApplicationException($"Não foi possível encontrar o {nomeDoCampo}.");
            }

            return nodes[0].InnerText;
        }
    }
}
