using Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using AutoMapper;
using HR.LeaveManagement.Domain;

namespace Application.MappingProfiles
{
    public class LeaveTypeProfile: Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto,LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDTO > ().ReverseMap();
        }
    }
}
