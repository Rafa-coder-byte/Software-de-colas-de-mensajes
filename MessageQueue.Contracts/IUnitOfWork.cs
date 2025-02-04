﻿
namespace MessageQueue.Contracts
{
    /// <summary>Interfaz que define el contrato para el UnitOfWork.</summary>
    public interface IUnitOfWork
    {
        /// <summary>Guarda los cambios realizados en el contexto.</summary>
        void SaveChanges();
    }
}
