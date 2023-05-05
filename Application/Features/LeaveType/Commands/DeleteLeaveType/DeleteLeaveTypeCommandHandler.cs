using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //retrieve domain entity object
            var leaveTypeToDelete = _leaveTypeRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(HR.LeaveManagement.Domain.LeaveType), request.Id);

            //remove from databse
            await _leaveTypeRepository.DeleteAsync(await leaveTypeToDelete);


            //return unit
            return Unit.Value;
        }
    }
}
