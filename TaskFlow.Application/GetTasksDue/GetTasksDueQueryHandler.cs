using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Persistence;

namespace TaskFlow.Application.GetTasksDue
{

    public class GetTasksDueQueryHandler : IRequestHandler<GetTasksDueQuery, IEnumerable<WorkItemDto>>
    {
        private readonly AppDbContext _context;

        public GetTasksDueQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkItemDto>> Handle(GetTasksDueQuery request, CancellationToken cancellationToken)
        {
           
            return await _context.WorkItems
                .Where(t => t.DueDate >= request.StartDate && t.DueDate <= request.EndDate)
                .Select(t => new WorkItemDto
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    IsCompleted = t.IsCompleted,
                    EmployeeName = t.Employee.EmpName
                }).ToListAsync(cancellationToken);
        }
    }
}
