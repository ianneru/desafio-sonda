using DesafioSonda.Application.DTOs;
using System;
using System.Collections.Generic;

namespace DesafioSonda.Application.Interfaces
{
    public interface IClientesService
    {
        ICollection<ClientesDTO> GetAll();

        ClientesDTO GetById(Guid Id);

        void Remove(Guid Id);

        void Add(ClientesDTO clientesDTO);

        void Update(ClientesDTO clientesDTO);
    }
}