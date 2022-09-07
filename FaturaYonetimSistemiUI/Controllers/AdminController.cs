using BusinessLayer.Features.Queries.AdminUI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class AdminController : Controller
    {
        readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(AdminUIQueryRequest adminUIQueryRequest)
        {
            AdminUIQueryResponse response = await _mediator.Send(adminUIQueryRequest);
            return View(response);
        }       
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}
