using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class TsanPham
{
    public Guid IdsanPham { get; set; }

    public Guid Idcategory { get; set; }

    public string? ImageUrl { get; set; }

    public string? Title { get; set; }

    public string? SubTitle { get; set; }

    public int SoLuong { get; set; }

    public int? DaBan { get; set; }

    public string GiaDung { get; set; } = null!;

    public string GiaGoc { get; set; } = null!;

    public int? PhanTramGiam { get; set; }

    public string? MoTaChiTiet { get; set; }

    public DateTime? CreateAt { get; set; }
}
