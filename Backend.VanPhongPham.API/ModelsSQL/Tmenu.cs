using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class Tmenu
{
    public Guid MenuId { get; set; }

    public Guid? MenuGroupId { get; set; }

    public string? MenuName { get; set; }

    public string? Url { get; set; }

    public int? LevelMenu { get; set; }

    public DateTime? CreateAt { get; set; }
}
