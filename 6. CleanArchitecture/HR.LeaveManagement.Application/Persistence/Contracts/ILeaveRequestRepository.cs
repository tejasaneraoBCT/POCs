﻿using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task ChangeLeaveRequestApproval(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
