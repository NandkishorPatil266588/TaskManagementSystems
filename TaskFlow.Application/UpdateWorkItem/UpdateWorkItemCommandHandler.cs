using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Persistence;

namespace TaskFlow.Application.UpdateWorkItem
{
    public class UpdateWorkItemCommandHandler : IRequestHandler<UpdateWorkItemCommand, bool>
    {

        private readonly AppDbContext _context;

        public UpdateWorkItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _context.WorkItems.FindAsync(request.TaskId);

                if (task == null)
                {

                    return false;
                }


                task.Title = request.Title;
                task.Description = request.Description;
                task.IsCompleted = request.IsCompleted;
                task.DueDate = request.DueDate;
                task.EmpId = request.EmpId;


                await _context.SaveChangesAsync(cancellationToken);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
