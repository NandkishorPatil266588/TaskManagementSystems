using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain
{
    public class WorkItem
    {
        [Key]
        public Guid TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }

        [ForeignKey("EmpId")]
        public Guid EmpId { get; set; }

        [ForeignKey(nameof(EmpId))]
        public Employee Employee { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
