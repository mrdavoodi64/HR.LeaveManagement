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
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext hrDatabaseContext) : base(hrDatabaseContext)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.leaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.leaveRequests
                .Where(q => q.RequestingEmployeeId.Equals(userId))
                .Include(q => q.LeaveType).ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest= await _context.leaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q=>q.Id==id);

            return leaveRequest;
        }
    }
}
