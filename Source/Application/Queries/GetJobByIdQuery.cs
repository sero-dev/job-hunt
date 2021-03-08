using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetJobByIdQuery : IRequest<Job>
    {
        public string Id { get; }

        public GetJobByIdQuery(string id)
        {
            Id = id;
        }

        public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetJobByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Job> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                Job job = await _unitOfWork.Jobs.GetAsync(request.Id);
                return job;
            }
        }
    }
}
