using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class Tblog
{
    public Guid Idblog { get; set; }

    public Guid? Idtopic { get; set; }

    public string? Title { get; set; }

    public string? Subtitle { get; set; }

    public string? Contents { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? Status { get; set; }

    public Guid? Idauthor { get; set; }
}
