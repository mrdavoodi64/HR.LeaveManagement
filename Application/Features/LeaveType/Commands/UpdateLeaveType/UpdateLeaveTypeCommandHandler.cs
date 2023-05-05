using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.UpdateLeaveType
{
    internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data

            //convert to domain entity object

            var leaveTypeToUpdate = _mapper.Map<HR.LeaveManagement.Domain.LeaveType>(request);

            //update record in database

           await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            //return unit

            return Unit.Value;
        }
    }
}
