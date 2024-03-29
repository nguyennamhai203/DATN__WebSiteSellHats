﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Models.Entities
{
    [Table("ThongKe")]
    public class ThongKe
    {
        public Guid Id { get; set; }
        public Guid HoaDonId { get; set; }
        public Guid SanPhamChiTietId { get; set; }
        public int Ngay { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public virtual ChiTietSanPham? ChiTietSanPham { get; set; }
        public virtual HoaDon? HoaDon { get; set; }

    }
}
