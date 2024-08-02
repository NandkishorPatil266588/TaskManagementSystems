using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;
using TaskFlow.Persistence;

namespace TaskFlow.Application.AddWorkItem
{
    public class AddWorkItemCommandHandler : IRequestHandler<AddWorkItemCommand, string>
    {
        private readonly AppDbContext _context;

        public AddWorkItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(AddWorkItemCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Validate the request
                if (string.IsNullOrEmpty(request.Title) || request.EmpId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid data provided.");
                }

                // Create a new Task entity
                var task = new WorkItem
                {
                    TaskId = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    EmpId = request.EmpId,
                    IsCompleted = false
                };

                // Add the task to the context
                _context.WorkItems.Add(task);
                await _context.SaveChangesAsync(cancellationToken);

                // Return the TaskId of the created task
                return task.TaskId.ToString();

            }catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
