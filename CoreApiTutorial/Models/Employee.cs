using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApiTutorial.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name can not exceed 50 characters")]
        public string Name { get; set; }
    }
}
