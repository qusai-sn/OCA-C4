using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mini_school.Models
{

    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // Foreign key for Class
        public int ClassId { get; set; }
        public Classes Class { get; set; }
    }

    public class Classes
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public Classes()
        {
            Students = new List<Student>();
            Assignments = new List<Assignment>();
        }
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Email { get; set; }

        public int ClassId { get; set; }
        public Classes Class { get; set; }
    }

    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }

}