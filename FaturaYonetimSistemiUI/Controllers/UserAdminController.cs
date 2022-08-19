using BusinessLayer.ValidationRules.UserAdmin;
using BusinessLayer.Features.Commands.AdminUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation.Results;
using BusinessLayer.Features.Queries.AdminUser.GetAllUser;
using BusinessLayer.Features.Commands.AdminUser.UpdateUser;
using BusinessLayer.Features.Queries.AdminUser.GetByIdUser;
using BusinessLayer.Features.Commands.AdminUser.RemoveUser;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class UserAdminController : Controller
    {
        readonly IMediator _mediator;

        public UserAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GetAllUserQueryRequest getAllUserQueryRequest)
        {
            GetAllUserQueryResponse response = await _mediator.Send(getAllUserQueryRequest);
            return View(response);
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
                return View();
            }
            
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQueryRequest);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserCommandRequest)
        {
            UserUpdateValidation validations = new UserUpdateValidation();
            ValidationResult result = validations.Validate(updateUserCommandRequest);

            if (result.IsValid)
            {
                UpdateUserCommandResponse response = await _mediator.Send(updateUserCommandRequest);
                return RedirectToAction("Index", "UserAdmin");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("UpdateUser",updateUserCommandRequest.Id.ToString());
            }       
            
        }

        public async Task<IActionResult> DeleteUser(RemoveUserCommandRequest removeUserCommandRequest)
        {
            RemoveUserCommandResponse response = await _mediator.Send(removeUserCommandRequest);
            return RedirectToAction("Index", "UserAdmin");
        }
    }
}
