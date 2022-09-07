using BusinessLayer.Features.Queries.User.GetByIdFA;
using BusinessLayer.Features.Queries.User.GetByIdHousing;
using BusinessLayer.Features.Queries.User.GetByIdVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class UserController : Controller
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Vehicle(GetByIdVehicleQueryRequest getByIdVehicleQueryRequest)
        {
            GetByIdVehicleQueryResponse response = await _mediator.Send(getByIdVehicleQueryRequest);
            return View(response.AllVehicle);
        }
        public async Task<IActionResult> Housing(GetByIdHousingQueryRequest getByIdHousingQueryRequest)
        {
            GetByIdHousingQueryResponse response = await _mediator.Send(getByIdHousingQueryRequest);
            return View(response.AllHousing);
        }
        
        public async Task<IActionResult> FA(GetByIdFAQueryRequest getByIdFAQueryRequest)
        {
            GetByIdFAQueryResponse response = await _mediator.Send(getByIdFAQueryRequest);
            return View(response.AllFA);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
