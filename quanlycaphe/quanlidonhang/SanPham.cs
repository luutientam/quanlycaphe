using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlycaphe.quanlidonhang
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public string MaKhuyenMai { get; set; }

        public SanPham(string maSanPham, string tenSanPham, double gia , string maKhuyenMai)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            Gia = gia;
            MaKhuyenMai = maKhuyenMai;
        }
    }

}
