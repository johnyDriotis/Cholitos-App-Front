using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.UseCases;
using CholitosAppFront.Core.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CholitosAppFront.Controllers
{
    public class MembershipController : Controller
    {
        private IMembershipUseCase _membershipUseCase;

        public MembershipController(IMembershipUseCase membershipUseCase)
        {
            _membershipUseCase = membershipUseCase ?? throw new ArgumentNullException(nameof(membershipUseCase));
        }

        [HttpGet]
        public IActionResult AddMensualidad()
        {
            return View(viewName: "~/Views/Memberships/AddMensualidad.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddMembership(MerbershipRequest membershipRequest)
        {
            GenericResponse<MembershipDto> membershipResponse = new GenericResponse<MembershipDto>();

            try
            {
                membershipResponse = await _membershipUseCase.AddMembership(membershipRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"MembershipController - AddMembership - Ocurrio un error al guardar la membresia: " + ex.Message);
            }

            return Json(membershipResponse);
        }

        [HttpGet]
        public IActionResult AddQuincena()
        {
            return View(viewName: "~/Views/Memberships/AddQuincena.cshtml");
        }
    }
}
