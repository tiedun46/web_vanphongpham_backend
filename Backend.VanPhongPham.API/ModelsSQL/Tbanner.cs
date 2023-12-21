using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class Tbanner
{
    public Guid Idbanner { get; set; }

    public string? BannerName { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? Status { get; set; }
}
