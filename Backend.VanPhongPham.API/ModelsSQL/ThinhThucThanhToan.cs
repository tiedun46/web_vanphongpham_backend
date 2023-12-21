using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class ThinhThucThanhToan
{
    public Guid IdhinhThucThanhToan { get; set; }

    public string? HinhThucThanhToan { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }
}
