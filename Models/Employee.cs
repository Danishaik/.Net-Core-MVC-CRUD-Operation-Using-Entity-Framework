using System.ComponentModel.DataAnnotations;

namespace MvcCrud.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required (ErrorMessage ="*Name can't be blank!")]
  
        public string Name { get; set; }
        
        [Required (ErrorMessage ="*Age cannot be blank!")]
        
        public int Age { get; set; }
        
        [Required (ErrorMessage ="*Dept cannot be blank!")]
        
        public string Dept { get; set; }
        
        [Required (ErrorMessage ="* Salary cannot be blank!")]
        
        public double Salary { get; set; }
    
    }
}
