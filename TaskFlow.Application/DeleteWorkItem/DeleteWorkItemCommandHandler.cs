using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Persistence;

namespace TaskFlow.Application.DeleteWorkItem
{
    public class DeleteWorkItemCommandHandler : IRequestHandler<DeleteWorkItemCommand, bool>
    {
         private readonly AppDbContext _appDbContext;

        public DeleteWorkItemCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteWorkItemCommand command , CancellationToken cancellationToken)
        {
            try
            {
                var task = await _appDbContext.WorkItems.FindAsync(command.TaskId);

                if (task == null)
                {
                    return false;
                }else
                {
                    _appDbContext.WorkItems.Remove(task);
                    _appDbContext.SaveChanges();

                    return true;
                }
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
