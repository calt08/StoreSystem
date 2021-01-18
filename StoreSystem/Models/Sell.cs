using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]                                
        public DateTime OrderDate { get; set; }

        [Required]
        public bool Approved{ get; set; }

        [ForeignKey("PaymentMethod")]
        [Required]
        public int PaymentMethodID { get; set; }

        [ForeignKey("Sell")]
        [Required]
        public int SellID { get; set; }
    }
}
