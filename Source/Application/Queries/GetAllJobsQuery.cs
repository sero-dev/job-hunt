using Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries
{
    public class GetAllJobsQuery : IRequest<ListResponse<Job>>
    {
        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, ListResponse<Job>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllJobsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<ListResponse<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Job> jobs = await _unitOfWork.Jobs.GetAllAsync();
                ListResponse<Job> response = _mapper.Map<ListResponse<Job>>(jobs);
                return response;
            }
        }
    }
}
