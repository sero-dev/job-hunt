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
            private readonly IJobRepository _jobRepository;

            public GetJobByIdQueryHandler(IJobRepository jobRepository)
            {
                _jobRepository = jobRepository;
            }

            public async Task<object> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                await _jobRepository.GetAsync(request.Id);
                return null;
            }
        }
    }
}
