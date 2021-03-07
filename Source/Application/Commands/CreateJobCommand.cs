using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
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
            private IUnitOfWork _unitOfWork;

            public CreateJobCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {
                GenerateId(request.Job);
                await _unitOfWork.Jobs.AddAsync(request.Job);
                return true;
            }

            private void GenerateId(Job job)
            {
                job.Id = Guid.NewGuid().ToString();
            }
        }
    }
}
