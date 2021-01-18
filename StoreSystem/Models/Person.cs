using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Needs a name")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Needs a lastname")]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public short Age { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }
    }
}
