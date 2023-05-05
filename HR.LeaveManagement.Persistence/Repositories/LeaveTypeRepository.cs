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
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext hrDatabaseContext) : base(hrDatabaseContext)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
        }
    }
}
