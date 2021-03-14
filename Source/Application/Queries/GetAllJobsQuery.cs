using Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{
    public class GetAllJobsQuery : IRequest<ListResponse<Job>>
    {
        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, ListResponse<Job>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllJobsQueryHandler> _logger;

            public GetAllJobsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetAllJobsQueryHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ListResponse<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Job> jobs = await _unitOfWork.Jobs.GetAllAsync();

                if (!jobs.Any())
                {
                    _logger.LogWarning("No jobs have returned from the database");
                }
                
                ListResponse<Job> response = _mapper.Map<ListResponse<Job>>(jobs);
                return response;
            }
        }
    }
}
