using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using HR.LeaveManagement.Domain;
using MediatR;


namespace Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //query database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(HR.LeaveManagement.Domain.LeaveType), request.Id);
            //convert data to dto object

            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveType);

            //return dto object
            return data;
        }
    }
}
