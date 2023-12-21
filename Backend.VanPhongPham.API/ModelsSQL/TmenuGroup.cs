using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class TmenuGroup
{
    public Guid MenuGroupId { get; set; }

    public string? MenuGroupName { get; set; }

    public string? Url { get; set; }

    public DateTime? CreateAt { get; set; }
}
