using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop_Models.Entities
{
    [Table("NguoiDung")]
    public class NguoiDung : IdentityUser
    {
        public Guid Id { get; set; }
        public string? MaNguoiDung { get; set; }
        //public string? Password { get; set; } 
        public int TrangThai { get; set; }
        public string? TenNguoiDung { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public bool? GioiTinh { get; set; }


    }
}
