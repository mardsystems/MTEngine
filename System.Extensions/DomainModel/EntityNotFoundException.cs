using System;
using System.Collections.Generic;
using System.Text;

namespace System.DomainModel
{
    public class EntityNotFoundException<TEntity> : Exception
        where TEntity : Entity
    {
        public EntityNotFoundException()
             : base(string.Format("Entidade '{0}' não encontrada.\n({1})", typeof(TEntity).Name, typeof(TEntity).Namespace))
        {

        }

        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
