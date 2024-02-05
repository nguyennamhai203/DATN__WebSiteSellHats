using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Models.Entities
{
    [Table("GioHangChiTiet")]
    public class GioHangChiTiet
    {
        [Key]
        public Guid Id { get; set; }
        public Guid GioHangId { get; set; }
        public Guid ChiTietSanPhamId { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public int GiaGoc { get; set; }
        public int TrangThai { get; set; }
        public virtual GioHang? GioHang { get; set; }
        public virtual ChiTietSanPham? ChiTietSanPham { get; set; }

    }
}
