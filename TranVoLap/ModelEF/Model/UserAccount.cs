namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [Key]
        [StringLength(30)]
        public string IDUser { get; set; }

        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(30)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung")]
        [StringLength(30)]
        public string UserType { get; set; }
    }
}
