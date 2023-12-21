using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class TdonHang
{
    public Guid IddonHang { get; set; }

    public Guid? Iduser { get; set; }

    public string TongTien { get; set; } = null!;

    public Guid IdhinhThucThanhToan { get; set; }

    public DateTime? CreateAt { get; set; }
}
