using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ban_2
{
    public class NhanVien
    {
        public string ma_NV;
        public string ma_PB;
        public string hoten;
        public string cccd;
        public string gioitinh;
        private string ngaysinh;
        public string sdt;
        public string email;
        public string diachi;
        public string hocvan;
        private string chucvu;

        public NhanVien() { }

        public NhanVien(string ma_NV, string ma_PB, string hoten, string cccd, string gioitinh, string sdt, string email, string diachi, string hocvan, string chucvu, string ngaysinh = null)
        {
            this.ma_NV = ma_NV;
            this.ma_PB = ma_PB;
            this.hoten = hoten;
            this.cccd = cccd;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.email = email;
            this.diachi = diachi;
            this.hocvan = hocvan;
            this.chucvu = chucvu;
            this.ngaysinh = ngaysinh;
        }

        public string Ma_NV { get => ma_NV; set => ma_NV = value; }
        public string Ma_PB { get => ma_PB; set => ma_PB = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Hocvan { get => hocvan; set => hocvan = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
}
