using BusinessLayer.Features.Commands.Housing.CreateHousing;
using BusinessLayer.Features.Commands.Housing.RemoveHousing;
using BusinessLayer.Features.Commands.Housing.UpdateHousing;
using BusinessLayer.Features.Queries.Housing.GetAllHousing;
using BusinessLayer.Features.Queries.Housing.GetAllUserHousing;
using BusinessLayer.Features.Queries.Housing.GetByIdHousing;
using BusinessLayer.ValidationRules.Housing;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class HousingController : Controller
    {
        private readonly IMediator _mediator;

        public HousingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllHousingQueryRequest getAllHousingQueryRequest)
        {
            GetAllHousingQueryResponse response = await _mediator.Send(getAllHousingQueryRequest);
            return View(response.AllHousing);
        }

        [HttpGet]
        public async Task<IActionResult> NewHousing(GetAllUserHousingQueryRequest getAllUserHousingQueryRequest)
        {
            GetAllUserHousingQueryResponse response = await _mediator.Send(getAllUserHousingQueryRequest);
            return View(response.Users);
        }
        [HttpPost]
        public async Task<IActionResult> NewHousing(CreateHousingCommandRequest createHousingCommandRequest)
        {
            HousingCreateValidation validations = new HousingCreateValidation();
            ValidationResult result = validations.Validate(createHousingCommandRequest);

            if (result.IsValid)
            {
                CreateHousingCommandResponse response = await _mediator.Send(createHousingCommandRequest);
                return RedirectToAction("Index", "Housing");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return RedirectToAction("NewHousing", "Housing");
            }            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHousing(GetByIdHousingQueryRequest byIdHousingQueryRequest)
        {
            GetByIdHousingQueryResponse response = await _mediator.Send(byIdHousingQueryRequest);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHousing(UpdateHousingCommandRequest updateHousingCommandRequest)
        {
            HousingUpdateValidation validations = new HousingUpdateValidation();
            ValidationResult result = validations.Validate(updateHousingCommandRequest);

            if (result.IsValid)
            {
                UpdateHousingCommandResponse response = await _mediator.Send(updateHousingCommandRequest);
                return RedirectToAction("Index", "Housing");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);                    
                }
                return RedirectToAction("UpdateHousing", "Housing");
            }            
        }
        public async Task<IActionResult> DeleteHousing(RemoveHousingCommandRequest removeHousingCommandRequest)
        {
            RemoveHousingCommandResponse response = await _mediator.Send(removeHousingCommandRequest);
            return RedirectToAction("Index", "Housing");
        }
    }
}
