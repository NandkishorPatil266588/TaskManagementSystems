using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey("TaskId")]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public WorkItem WorkItem { get; set; }


    }
}
