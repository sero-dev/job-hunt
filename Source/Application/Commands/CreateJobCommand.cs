using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateJobCommand : IRequest<bool>
    {
        public Job Job { get; }

        public CreateJobCommand(Job job)
        {
            Job = job;
        }

        public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, bool>
        {
            private IJobRepository _jobRepository;

            public CreateJobCommandHandler(IJobRepository jobRepository)
            {
                _jobRepository = jobRepository;
            }

            public async Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {
                await _jobRepository.AddAsync(request.Job);
                return true;
            }
        }
    }
}
