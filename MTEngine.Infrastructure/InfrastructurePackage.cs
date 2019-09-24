using MTEngine.Regras;
using MTEngine.Transformacoes;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MTEngine
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeRegras, CadastroDeRegrasService>();

            container.Register<IRegrasRepository, RegrasDbRepository>();

            container.Register<IUnitOfWork, ScopedTransactionManager>();

            container.Register<ITransformacaoDeMensagens, TransformacaoDeMensagensService>();

            container.RegisterSingleton<TransformacaoDeMensagensXmlService>();

            //container.RegisterSingleton<MTEngineDbContext>();
        }
    }
}
