using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult= await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid LeaveType",validationResult);
            //convert to domain entity
            var leaveTypeRequest = _mapper.Map<HR.LeaveManagement.Domain.LeaveType>(request);

            //add to database

            await _leaveTypeRepository.CreateAsync(leaveTypeRequest);

            //return record id

            return leaveTypeRequest.Id;
        }
    }
}
