using AutoMapper;
using DesafioSonda.Domain.Entities;
using DesafioSonda.Repositories;
using DesafioSonda.Application.DTOs;
using DesafioSonda.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace DesafioSonda.Application
{
    public class ClientesService : IClientesService
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IMapper mapper, IClientesRepository clientesRepository)
        {
            _mapper = mapper;
            _clientesRepository = clientesRepository;
        }

        public ICollection<ClientesDTO> GetAll()
        {
            var clientes = _clientesRepository.GetAll();

            return _mapper.Map<ICollection<ClientesDTO>>(clientes);
        }

        public ClientesDTO GetById(Guid Id)
        {
            var cliente = _clientesRepository.GetById(Id);

            return _mapper.Map<ClientesDTO>(cliente);
        }

        public void Update(ClientesDTO clientesDTO)
        {
            var cliente = _mapper.Map<Clientes>(clientesDTO);

            cliente.Validate();

            cliente.RemoveCaracteresCpf();

            _clientesRepository.Update(cliente);
        }

        public void Remove(Guid Id)
        {
             _clientesRepository.Remove(Id);
        }

        public void Add(ClientesDTO clientesDTO)
        {
            var cliente = _mapper.Map<Clientes>(clientesDTO);

            cliente.Validate();

            cliente.RemoveCaracteresCpf();

            _clientesRepository.Add(cliente);
        }
    }
}
