using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentSubject
    {
        [Column("Student_id")]
        public int Id { get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey(nameof(Subject))]
        public string? SubjectCode { get; set; }
        public string? grade { get; set; }
        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
    }
}
