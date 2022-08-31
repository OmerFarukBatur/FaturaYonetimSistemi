using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.FA;
using DataAccessLayer.Repositories.Housing;
using DataAccessLayer.Repositories.User;
using DataAccessLayer.ViewModels.FA;
using EntityLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.FA.GetAllFA
{
    public class GetAllFAQueryHandler : IRequestHandler<GetAllFAQueryRequest, GetAllFAQueryResponse>
    {
        private readonly IHousingReadRepository _housingReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IFAReadRepository _faReadRepository;


        public GetAllFAQueryHandler(IHousingReadRepository housingReadRepository, IUserReadRepository userReadRepository, IFAReadRepository faReadRepository)
        {
            _housingReadRepository = housingReadRepository;
            _userReadRepository = userReadRepository;
            _faReadRepository = faReadRepository;
        }

        public async Task<GetAllFAQueryResponse> Handle(GetAllFAQueryRequest request, CancellationToken cancellationToken)
        {
            
            // Aşağıdaki ile aynı çıktıyı vermekte fakat tek seferde 4 (faAll,housingAll,userAll ve join) sorgu ile veriler çekilmektedir.

            //var faAll = await _faReadRepository.GetAll(false).ToListAsync();
            //var housingAll = await _housingReadRepository.GetAll(false).ToListAsync();
            //var userAll = await _userReadRepository.GetAll(false).ToListAsync();          

            //var fa = (from u in userAll
            //         join h in housingAll on u.id equals h.UserId 
            //         join f in faAll on u.id equals f.UserId 
            //         select new VM_CreateFA
            //         {
            //             FirstName= u.FirstName,
            //             LastName= u.LastName,
            //             BlockNumber = h.BlockNumber,
            //             HousNumber = h.HousNumber,
            //             id = f.id.ToString(),
            //             FAType = f.FAType,
            //             Amount = f.Amount,
            //             Status = f.Status,
            //             DueDate = f.DueDate,
            //             CreatedDate = f.CreatedDate,
            //             UpdatedDate = f.UpdatedDate
            //         }).ToList();



            // Aşağıdaki ile aynı çıktıyı vermekte fakat tek seferde tek sorgu ile veriler çekilmektedir.
            var fanew = await _userReadRepository.GetAll(false)
                .Join(_housingReadRepository.GetAll(false), user => user.id, house => house.UserId,(u, h) => new { u,h })
                .Join(_faReadRepository.GetAll(false),us => us.u.id,f => f.UserId,(use,fa) => new {use,fa})
                .Select(a => new VM_CreateFA
                {
                    FirstName = a.use.u.FirstName,
                    LastName = a.use.u.LastName,
                    BlockNumber = a.use.h.BlockNumber,
                    HousNumber = a.use.h.HousNumber,
                    id = a.fa.id.ToString(),
                    FAType = a.fa.FAType,
                    Amount = a.fa.Amount,
                    Status = a.fa.Status,
                    DueDate = a.fa.DueDate,
                    CreatedDate = a.fa.CreatedDate,
                    UpdatedDate = a.fa.UpdatedDate
                }).ToListAsync();


            return new()
            {
                FAs = fanew
            };
        }
    }
}
