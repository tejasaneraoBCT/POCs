using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Queries
{
    public class GetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
