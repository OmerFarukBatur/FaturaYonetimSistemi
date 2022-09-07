using DataAccessLayer.Repositories.Contact;
using DataAccessLayer.Repositories.FA;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.AdminUI
{
    public class AdminUIQueryHandler : IRequestHandler<AdminUIQueryRequest, AdminUIQueryResponse>
    {
        private readonly IFAReadRepository _faReadRepository;
        private readonly IContactReadRepository _contactReadRepository;

        public AdminUIQueryHandler(IFAReadRepository faReadRepository, IContactReadRepository contactReadRepository)
        {
            _faReadRepository = faReadRepository;
            _contactReadRepository = contactReadRepository;
        }

        public async Task<AdminUIQueryResponse> Handle(AdminUIQueryRequest request, CancellationToken cancellationToken)
        {
            float allAmountSum = await _faReadRepository.GetAll(false).SumAsync(f => f.Amount);
            float amountTrueSum = await _faReadRepository.GetWhere(ft => ft.Status == true).SumAsync(ft => ft.Amount);
            float oneWeekSum = await _faReadRepository
                .GetWhere(f => f.Status == true && ((f.UpdatedDate.Year == DateTime.Now.Year) && (f.UpdatedDate.Month == DateTime.Now.Month) && (f.UpdatedDate.Day >= DateTime.Now.Day || f.UpdatedDate.Day <= DateTime.Now.Day)))
                .SumAsync(f => f.Amount);
            int oneDayMessage = _contactReadRepository.GetWhere(ft => ft.Status == true).Count();

            return new()
            {
                AllAmountSum = allAmountSum,
                AmountTrueSum = amountTrueSum,
                OneWeekSum = oneWeekSum,
                OneDayMessage = oneDayMessage,
            };
        }
    }
}
