using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORM.Homework.Models
{
    public class Group
    {
        public Group() { Students = new List<Student>(); }
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Number { get; set; }
        public ICollection<Student> Students { get; set; }
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
