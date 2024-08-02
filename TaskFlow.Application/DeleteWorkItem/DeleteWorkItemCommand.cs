using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.DeleteWorkItem
{
   public class DeleteWorkItemCommand : IRequest<bool>
    {
        public Guid TaskId { get; set; }
    }
}
