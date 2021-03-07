using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetJobByIdQuery : IRequest<object>
    {
        public string Id { get; }

        public GetJobByIdQuery(string id)
        {
            Id = id;
        }

        public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, object>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetJobByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<object> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                Job job = await _unitOfWork.Jobs.GetAsync(request.Id);
                return job;
            }
        }
    }
}
