using BusinessLayer.Features.Commands.Vehicle.CreateVehicle;
using BusinessLayer.Features.Commands.Vehicle.RemoveVehicle;
using BusinessLayer.Features.Commands.Vehicle.UpdateVehicle;
using BusinessLayer.Features.Queries.Vehicle.GetAllUserVehicle;
using BusinessLayer.Features.Queries.Vehicle.GetAllVehicle;
using BusinessLayer.Features.Queries.Vehicle.GetByIdVehicle;
using BusinessLayer.ValidationRules.Vehicle;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class VehicleController : Controller
    {
        readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllVehicleQueryRequest getAllVehicleQueryRequest)
        {
            GetAllVehicleQueryResponse response = await _mediator.Send(getAllVehicleQueryRequest);
            return View(response.Vehicles);
        }
        [HttpGet]
        public async Task<IActionResult> NewVehicle(GetAllUserVehicleQueryRequest getAllUserVehicleQueryRequest)
        {
            GetAllUserVehicleQueryResponse response = await _mediator.Send(getAllUserVehicleQueryRequest);
            return View(response.Users);
        }

        [HttpPost]
        public async Task<IActionResult> NewVehicle(CreateVehicleCommandRequest createVehicleCommandRequest)
        {
            VehicleCreateValidation validations = new VehicleCreateValidation();
            ValidationResult result = validations.Validate(createVehicleCommandRequest);

            if (result.IsValid)
            {
                CreateVehicleCommandResponse response = await _mediator.Send(createVehicleCommandRequest);
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return RedirectToAction("NewVehicle", "Vehicle");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVehicle(GetByIdVehicleQueryRequest byIdVehicleQueryRequest)
        {
            GetByIdVehicleQueryResponse response = await _mediator.Send(byIdVehicleQueryRequest);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleCommandRequest updateVehicleCommandRequest)
        {
            VehicleUpdateValidation validations = new VehicleUpdateValidation();
            ValidationResult result = validations.Validate(updateVehicleCommandRequest);

            if (result.IsValid)
            {
                UpdateVehicleCommandResponse response = await _mediator.Send(updateVehicleCommandRequest);
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("UpdateVehicle", "Vehicle",updateVehicleCommandRequest.Id.ToString());
            }
        }
        public async Task<IActionResult> DeleteVehicle(RemoveVehicleCommandRequest removeVehicleCommandRequest)
        {
            RemoveVehicleCommandResponse response = await _mediator.Send(removeVehicleCommandRequest);
            return RedirectToAction("Index", "Vehicle");
        }
    }
}
