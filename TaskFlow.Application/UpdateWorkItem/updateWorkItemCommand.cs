using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.UpdateWorkItem
{

    public class UpdateWorkItemCommand : IRequest<bool>
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public Guid EmpId { get; set; } // Assuming you might want to update the associated employee ID
    }
}
