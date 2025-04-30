using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        [Column("Code")]
        public string? Id { get; set; }
        public string? course_Name { get; set; }
        public int hours { get; set; }
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
        [NotMapped]
        public string? grade { get; set; }
    }
}
