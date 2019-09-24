using System;
using System.Collections.Generic;
using System.Text;

namespace System.DomainModel
{
    public abstract class Entity
    {
        public byte[] Version { get; private set; }

        protected Entity()
        {
            Version = new byte[] { 0 };
        }

        public void SetVersion(byte[] newVersion)
        {
            Version = newVersion;
        }

        #region Infraestrutura

        protected Entity(byte[] version)
        {
            Version = version;
        }

        #endregion
    }
}
