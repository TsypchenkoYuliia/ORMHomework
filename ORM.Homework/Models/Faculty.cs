using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORM.Homework.Models
{
    public class Faculty
    {
        public Faculty() { Groups = new List<Group>(); }
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Number { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
