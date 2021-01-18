using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Employee needs a position")]
        public string Position { get; set; }
        
        public short Rating { get; set; }

        [ForeignKey("Person")]
        public int PersonID { get; set; }
    }
}
