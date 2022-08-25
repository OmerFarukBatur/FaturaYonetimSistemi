using BusinessLayer.Features.Queries.FA.GetAllUserFA;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Models.ViewComponents
{
    public class AllUsersFA : ViewComponent
    {
        readonly IMediator _mediator;

        public AllUsersFA(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(GetAllUserFAQueryRequest getAllUserFAQueryRequest)
        {
            GetAllUserFAQueryResponse response = await _mediator.Send(getAllUserFAQueryRequest);
            return View(response.Users);
        }
    }
}
