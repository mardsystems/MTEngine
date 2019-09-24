using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MTEngine.Regras
{
    public class CadastroDeRegrasService : ICadastroDeRegras
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRegrasRepository regrasRepository;

        public CadastroDeRegrasService(IUnitOfWork unitOfWork, IRegrasRepository regrasRepository)
        {
            this.unitOfWork = unitOfWork;

            this.regrasRepository = regrasRepository;
        }

        public async Task CadastraRegra(CadastroDeRegraRequest request)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var regra = new Regra
                {
                    Nome = request.Nome,
                    PathDeCidades = request.PathDeCidades,
                    PathDoNomeDaCidade = request.PathDoNomeDaCidade,
                    PathDoNumeroDeHabitantesDaCidade = request.PathDoNumeroDeHabitantesDaCidade,
                    PathDeBairros = request.PathDeBairros,
                    PathDoNomeDoBairro = request.PathDoNomeDoBairro,
                    PathDoNumeroDeHabitantesDoBairro = request.PathDoNumeroDeHabitantesDoBairro,
                    TipoDeFormato = request.TipoDeFormato
                };

                await regrasRepository.Add(regra);

                await unitOfWork.Commit();
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public Task AtualizaRegra(string nome, CadastroDeRegraRequest request)
        {
            throw new NotImplementedException("Não deu tempo de implementar.");
        }

        public Task ExcluiRegra(string nome)
        {
            throw new NotImplementedException("Não deu tempo de implementar.");
        }
    }
}
