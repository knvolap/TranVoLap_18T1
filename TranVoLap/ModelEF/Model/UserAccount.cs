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

        [Required(ErrorMessage = "Nhập tên tài khoản")]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nhập số điện thoại")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        
        public bool? Status { get; set; }

        [Required(ErrorMessage = "Nhập chức vụ")]
        [StringLength(30)]
        public string UserType { get; set; }
    }
}
