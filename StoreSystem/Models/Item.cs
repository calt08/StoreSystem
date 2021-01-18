using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class Item
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
        
        [Required]
        public long Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ItemCategory")]
        [Required]
        public int ItemCategoryID { get; set; }
    }
}
