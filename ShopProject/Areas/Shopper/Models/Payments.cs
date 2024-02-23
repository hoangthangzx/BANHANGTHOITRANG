namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payments
    {
        [Key]
        public int paymentID { get; set; }

        [Required]
        [StringLength(20)]
        public string orderID { get; set; }

        [Required]
        [StringLength(50)]
        public string paymentAmount { get; set; }

        public DateTime paymentDate { get; set; }

        [StringLength(50)]
        public string paymentMethod { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
