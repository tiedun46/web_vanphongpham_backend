using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class TdonHangChiTiet
{
    public Guid IddonHangChiTiet { get; set; }

    public Guid? IddonHang { get; set; }

    public Guid? IdsanPham { get; set; }

    public int SoLuong { get; set; }

    public string GiaDonHang { get; set; } = null!;

    public DateTime? CreateAt { get; set; }
}
