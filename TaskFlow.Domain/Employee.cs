using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Domain
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpRole { get; set; }
        public ICollection<WorkItem> WorkItem { get; set; }

        public string EmpPassowrd {  get; set; }

        public string EmpEmailId { get; set; }


    }
}
