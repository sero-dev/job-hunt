using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Application.Commands
{
    public class CreateJobCommand : IRequest<string>
    {
        private CreateJobRequest NewJobRequest { get; }

        public CreateJobCommand(CreateJobRequest newJobRequest)
        {
            NewJobRequest = newJobRequest;
        }

        public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, string>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ILogger<CreateJobCommandHandler> _logger;

            public CreateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateJobCommandHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<string> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    Job job = _mapper.Map<Job>(request.NewJobRequest);
                    await _unitOfWork.Jobs.AddAsync(job);
                    return job.Id.ToString();
                }
                catch(Exception e)
                {
                    _logger.LogError(e.Message);
                    return null;
                }
            }
        }
    }
}
