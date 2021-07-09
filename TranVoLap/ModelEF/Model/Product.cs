namespace ModelEF.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Chưa nhập tên sách")]
        [StringLength(200)]
        public string NameProduct { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên sách")]
        [StringLength(200)]
        public string MetaName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng > 0")]
        [Required(ErrorMessage = "Chưa nhập nhập số lượng ")]
        public int? Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá tiền > 0")]
        [Required(ErrorMessage = "Chưa nhập nhập giá tiền")]
        public double? UnitCost { get; set; }

        [Required(ErrorMessage = "Chưa chọn ảnh")]
        [StringLength(100)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên tác giả")]
        [StringLength(200)]
        public string Author { get; set; }
        
        [StringLength(300)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Chọn tình trạng sản phẩm")]
        public bool? Status { get; set; }
     
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserOder> UserOders { get; set; }
    }
}
