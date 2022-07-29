using BusinessLayer.ValidationRules.UserAdmin;
using BusinessLayer.Features.Commands.AdminUser.CreateUser;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class UserAdminController : Controller
    {
        readonly IMediator _mediator;

        public UserAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewUser(CreateUserAdminCommandRequest request)
        {
            UserCreateValidation validations = new UserCreateValidation();
            ValidationResult result = validations.Validate(request);

            if (result.IsValid)
            {
                CreateUserAdminCommandResponse response = await _mediator.Send(request);
                return RedirectToAction("Index", "UserAdmin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            
            return View();
        }
        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
