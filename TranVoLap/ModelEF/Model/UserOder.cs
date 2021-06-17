namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserOder")]
    public partial class UserOder
    {
        [Key]
        [StringLength(30)]
        public string IDOder { get; set; }

        [StringLength(30)]
        public string IDProduct { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public int? Quantity { get; set; }

        public double? Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DayBuy { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool? Status { get; set; }

        public virtual Product Product { get; set; }
    }
}
