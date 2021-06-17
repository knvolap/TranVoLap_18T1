namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            UserOders = new HashSet<UserOder>();
        }

        [Key]
        [StringLength(30)]
        public string IDProduct { get; set; }
        
        [StringLength(30)]
        public string IDCategory { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(200)]
        public string NameProduct { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(200)]
        public string MetaName { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        public double? UnitCost { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(100)]
        public string Image { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(200)]
        public string Author { get; set; }
        
        [StringLength(300)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        public bool? Status { get; set; }
     
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserOder> UserOders { get; set; }
    }
}
