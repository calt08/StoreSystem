using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class SellDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public short Quantity { get; set; }

        [ForeignKey("Item")]
        [Required]
        public int Item { get; set; }

        [ForeignKey("Sell")]
        [Required]
        public int SellID { get; set; }
    }
}
