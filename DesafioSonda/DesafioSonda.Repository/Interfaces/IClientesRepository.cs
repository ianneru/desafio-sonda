using DesafioSonda.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DesafioSonda.Repositories
{
    public interface IClientesRepository : IDisposable
    {
        ICollection<Clientes> GetAll();

        void Add(Clientes cliente);
        
        void Update(Clientes cliente);

        void Remove(Guid Id);

        Clientes GetById(Guid Id);
    }
}
