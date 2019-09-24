using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTEngine.Regras
{
    public interface ICadastroDeRegras
    {
        Task CadastraRegra(CadastroDeRegraRequest request);

        Task AtualizaRegra(string nome, CadastroDeRegraRequest request);

        Task ExcluiRegra(string nome);
    }
}
