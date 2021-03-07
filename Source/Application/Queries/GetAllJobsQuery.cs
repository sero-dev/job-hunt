using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllJobsQuery : IRequest<IEnumerable<Job>>
    {
        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, IEnumerable<Job>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllJobsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                var jobs = await _unitOfWork.Jobs.GetAllAsync();
                return jobs;
            }
        }
    }
}
