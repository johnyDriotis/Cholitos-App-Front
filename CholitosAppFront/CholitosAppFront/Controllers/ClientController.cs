using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CholitosAppFront.Controllers
{
    public class ClientController : Controller
    {
        private IClientUseCase _clientUseCase;

        public ClientController(IClientUseCase clientUeCase)
        {
            _clientUseCase = clientUeCase ?? throw new ArgumentNullException(nameof(clientUeCase));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GenericResponse<List<ClientDto>> response = new GenericResponse<List<ClientDto>>();

            try
            {
                response = await _clientUseCase.GetAllClients();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ClientController - Index - Ocurrio un error al recuperar los clientes: " + ex.Message);
            }

            return View(
                viewName: "~/Views/Clients/Index.cshtml",
                model: response
            );
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View(viewName: "~/Views/Clients/AddClient.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientRequest clientRequest)
        {
            GenericResponse<ClientDto> clientResponse = new GenericResponse<ClientDto>();

            try
            {
                clientResponse = await _clientUseCase.AddClient(clientRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"ClientController - AddClient - Ocurrio un error al guardar el cliente: " + ex.Message);
            }

            return Json(clientResponse);
        }

        [HttpGet]
        public async Task<IActionResult> ModifyClient(int idCliente)
        {
            GenericResponse<ClientDto> response = new GenericResponse<ClientDto>();

            try
            {
                response = await _clientUseCase.GetClientById(idCliente);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ClientController - ModifyClient - Ocurrio un error al buscar el cliente: " + ex.Message);
            }

            return View(
                    viewName: "~/Views/Clients/ModifyClient.cshtml",
                    model: response.Item
            );
        }

        [HttpPost]
        public async Task<IActionResult> ModifyClient(ClientRequest clientRequest)
        {
            GenericResponse<ClientDto> clientResponse = new GenericResponse<ClientDto>();

            try
            {
                clientResponse = await _clientUseCase.ModifyClient(clientRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"ClientController - ModifyClient - Ocurrio un error al actualizar el cliente: " + ex.Message);
            }

            return Json(clientResponse);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(ClientRequest clientRequest)
        {
            GenericResponse<ClientDto> clientEliminated = new GenericResponse<ClientDto>();

            try
            {
                clientEliminated = await _clientUseCase.DeleteClient(clientRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"ClientController - DeleteClient - Ocurrio un error al eliminar cliente: " + ex.Message);
            }

            return Json(clientEliminated);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStateClient(ClientRequest clientRequest)
        {
            GenericResponse<ClientDto> clientState = new GenericResponse<ClientDto>();

            try
            {
                clientState = await _clientUseCase.ChangeStateClient(clientRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"ClientController - ChangeStateClient - Ocurrio un error al cambiar estado del cliente: " + ex.Message);
            }

            return Json(clientState);
        }

        [HttpGet]
        public async Task<IActionResult> ClientDetails(int idCliente)
        {
            GenericResponse<ClientDto> response = new GenericResponse<ClientDto>();

            try
            {
                response = await _clientUseCase.GetClientById(idCliente);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ClientController - ModifyClient - Ocurrio un error al buscar el cliente: " + ex.Message);
            }

            return View(
                    viewName: "~/Views/Clients/ClientDetails.cshtml",
                    model: response.Item
            );
        }
    }
}
