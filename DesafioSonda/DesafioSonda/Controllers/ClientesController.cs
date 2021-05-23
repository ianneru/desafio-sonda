using AutoMapper;
using DesafioSonda.Core.Exceptions;
using DesafioSonda.Application.DTOs;
using DesafioSonda.Application.Interfaces;
using DesafioSonda.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DesafioSonda.Controllers
{
    [Route("Clientes")]
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;

        public ClientesController(IMapper mapper,IClientesService clientesService)
        {
            _clientesService = clientesService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var clientes = _clientesService.GetAll();

            return View(clientes);
        }

        public ActionResult Adicionar()
        {
            return View(new CreateClientesViewModel());
        }

        public ActionResult Atualizar(Guid id)
        {
            return View(_mapper.Map<UpdateClientesViewModel>(_clientesService.GetById(id)));
        }

        public ActionResult Remover(Guid id)
        {
            _clientesService.Remove(id);
         
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Atualizar(UpdateClientesViewModel updateClientesViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(updateClientesViewModel);

                var clienteDTO = _mapper.Map<ClientesDTO>(updateClientesViewModel);

                _clientesService.Update(clienteDTO);

                return RedirectToAction("Index");
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError("Erros", string.Join(", ", ex.Errors.ToArray()));
                return View(updateClientesViewModel);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CreateClientesViewModel createClientesViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createClientesViewModel);

                var clienteDTO = _mapper.Map<ClientesDTO>(createClientesViewModel);

                _clientesService.Add(clienteDTO);

                return RedirectToAction("Index");
            }
            catch(DomainException ex)
            {
                ModelState.AddModelError("Erros", string.Join(", ", ex.Errors.ToArray()));
                return View(createClientesViewModel);
            }
        }

    }
}