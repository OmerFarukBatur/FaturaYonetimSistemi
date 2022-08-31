using BusinessLayer.Features.Commands.FA.CreateFA;
using BusinessLayer.Features.Commands.FA.RemoveFA;
using BusinessLayer.Features.Commands.FA.UpdateFA;
using BusinessLayer.Features.Queries.FA.GetAllFA;
using BusinessLayer.Features.Queries.FA.GetAllUserFA;
using BusinessLayer.Features.Queries.FA.GetByIdFA;
using BusinessLayer.ValidationRules.FA;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class FAController : Controller
    {
        readonly IMediator _mediator;

        public FAController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllFAQueryRequest getAllFAQueryRequest)
        {
            GetAllFAQueryResponse response = await _mediator.Send(getAllFAQueryRequest);
            return View(response.FAs);
        }

        [HttpGet]
        public async Task<IActionResult> NewFA(GetAllUserFAQueryRequest getAllUserFAQueryRequest)
        {
            GetAllUserFAQueryResponse response = await _mediator.Send(getAllUserFAQueryRequest);
            return View(response.Users);
        }

        [HttpPost]
        public async Task<IActionResult> NewFA(CreateFACommandRequest createFACommandRequest)
        {
            FACreateValidation validationRules = new FACreateValidation();
            ValidationResult result = validationRules.Validate(createFACommandRequest);

            if (result.IsValid)
            {
                CreateFACommandResponse response = await _mediator.Send(createFACommandRequest);
                return RedirectToAction("Index", "FA");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("NewFA", "FA");
            }            
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFA(GetByIdFAQueryRequest getByIdFAQueryRequest)
        {
            GetByIdFAQueryResponse response = await _mediator.Send(getByIdFAQueryRequest);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFA(UpdateFACommandRequest updateFACommandRequest)
        {
            FAUpdateValidation validations = new FAUpdateValidation();
            ValidationResult result = validations.Validate(updateFACommandRequest);

            if (result.IsValid)
            {
                UpdateFACommandResponse response = await _mediator.Send(updateFACommandRequest);
                return RedirectToAction("Index", "FA");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("UpdateFA", "FA",updateFACommandRequest.Id.ToString());
            }            
        }
        public async Task<IActionResult> DeleteFA(RemoveFACommandRequest removeFACommandRequest)
        {
            RemoveFACommandResponse response = await _mediator.Send(removeFACommandRequest);
            return RedirectToAction("Index", "FA");
        }
    }
}
