using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;

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

            public CreateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<string> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    Job job = _mapper.Map<Job>(request.NewJobRequest);
                    await _unitOfWork.Jobs.AddAsync(job);
                    return job.Id;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    }
}
