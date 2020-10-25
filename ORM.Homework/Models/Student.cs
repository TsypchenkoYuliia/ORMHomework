using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORM.Homework.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string LastName { get; set; }
        [MinLength(2)]
        [MaxLength(25)]
        public string MiddleName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
