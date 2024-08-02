using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;

namespace TaskFlow.Application.AddWorkItem
{
    public class AddWorkItemCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid EmpId { get; set; }
    }
}
