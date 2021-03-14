using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands
{
    /// <summary>
    /// Command for deleting a job using MediatR's IRequest
    /// </summary>
    public class DeleteJobCommand : IRequest<bool>
    {
        private Guid Id { get; set; }

        /// <summary>
        /// Command for deleting a job using MediatR's IRequest
        /// </summary>
        /// <param name="id">The ID of the Job</param>
        public DeleteJobCommand(Guid id)
        {
            Id = id;
        }
        
        public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<DeleteJobCommandHandler> _logger;
            public DeleteJobCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteJobCommandHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            
            public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    long recordsDeleted = await _unitOfWork.Jobs.RemoveAsync(request.Id);
                    if (recordsDeleted == 0)
                    {
                        _logger.LogWarning("No records were deleted");
                        return false;
                    }

                    if (recordsDeleted > 1)
                    {
                        _logger.LogWarning("More than one record was deleted with one ID");
                    }
                    
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e.Message);
                    return false;
                }
            }
        }
    }
}