using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Text;
using System.Threading.Tasks;

namespace MTEngine.Regras
{
    public class RegrasDbRepository : DbRepository<MTEngineDbContext, Regra>, IRegrasRepository
    {
        public RegrasDbRepository(MTEngineDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Regra>> ObtemRegras()
        {
            try
            {
                var regras = await context.Regras.ToListAsync();

                return regras;
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task<Regra> ObtemRegraPeloNome(string nome)
        {
            try
            {
                var regra = await context.Regras.FindAsync(nome);

                if (regra == null)
                {
                    throw new EntityNotFoundException<Regra>($"Regra (nome: '{nome}') não foi encontrada.");
                }

                return regra;
            }
            catch (DbUpdateException)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }
    }
}
