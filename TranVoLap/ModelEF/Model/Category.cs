namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Vui long chon loai sach")]
        [Key]
        [StringLength(30)]
        public string IDCategory { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(200)]
        public string NameCategory { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
