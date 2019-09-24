using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Text;
using System.Threading.Tasks;

namespace MTEngine.Regras
{
    public interface IRegrasRepository : IRepository<Regra>
    {
        Task<IEnumerable<Regra>> ObtemRegras();

        Task<Regra> ObtemRegraPeloNome(string nome);
    }
}
