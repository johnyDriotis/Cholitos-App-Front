using CholitosAppFront.Core.Dtos;
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
        // Atributos
        private IClientUseCase _clientUseCase;

        // Contructor
        public ClientController(IClientUseCase clientUeCase)
        {
            _clientUseCase = clientUeCase ?? throw new ArgumentNullException(nameof(clientUeCase));
        }

        // Metodos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //GenericResponse<List<ClientDto>> response = new GenericResponse<List<ClientDto>>();

            //try
            //{
            //    response = await _clientUseCase.GetAllClients();
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine("ClientController - Index - Ocurrio un error al recuperar los clientes: " + ex.Message);
            //}

            return View(
                viewName: "~/Views/Clients/Index.cshtml",
                model: new List<ClientDto>()
            );
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View(viewName: "~/Views/Clients/AddClient.cshtml");
        }

        [HttpPost]
        public async Task<GenericResponseFingerPrint<FingerPrintDto>> GetFingerPrintCaptures()
        {
            return await _clientUseCase.GetFingerPrintImages();
        }

        [HttpPost]
        public async Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest)
        {
            return await _clientUseCase.AddClient(clientRequest);
        }
    }
}
