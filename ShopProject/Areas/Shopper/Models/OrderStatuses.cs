namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderStatuses
    {
        [Key]
        public int statusID { get; set; }

        [Required]
        [StringLength(50)]
        public string statusName { get; set; }

        [StringLength(20)]
        public string cusPhone { get; set; }
    }
}
