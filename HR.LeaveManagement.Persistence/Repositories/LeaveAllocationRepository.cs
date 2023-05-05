using Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext hrDatabaseContext) : base(hrDatabaseContext)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return _context.leaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                                         && q.LeaveTypeId == leaveTypeId
                                                         && q.Period == period);
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            return _context.leaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            return _context.leaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType).ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _context.leaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            throw new NotImplementedException(); 
        }
    }
}
