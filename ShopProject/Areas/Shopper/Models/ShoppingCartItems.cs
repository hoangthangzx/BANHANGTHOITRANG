namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCartItems
    {
        [Key]
        public int cartItemID { get; set; }

        [Required]
        [StringLength(20)]
        public string cusPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string proID { get; set; }

        public int quantity { get; set; }

        [StringLength(10)]
        public string price { get; set; }

        public int? discount { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Products Products { get; set; }
    }
}
