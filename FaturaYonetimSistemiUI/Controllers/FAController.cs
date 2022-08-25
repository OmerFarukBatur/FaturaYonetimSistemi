using BusinessLayer.Features.Commands.FA.CreateFA;
using BusinessLayer.Features.Queries.FA.GetAllFA;
using BusinessLayer.Features.Queries.FA.GetAllUserFA;
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
        public IActionResult UpdateFA()
        {
            return View();
        }
        public IActionResult DeleteFA()
        {
            return View();
        }
    }
}
