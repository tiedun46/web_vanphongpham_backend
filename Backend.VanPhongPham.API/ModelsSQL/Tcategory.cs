using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class Tcategory
{
    public Guid Idcategory { get; set; }

    public string? CategoryName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }
}
