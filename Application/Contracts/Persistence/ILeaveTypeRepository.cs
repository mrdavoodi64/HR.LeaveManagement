﻿using HR.LeaveManagement.Domain;

namespace Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}