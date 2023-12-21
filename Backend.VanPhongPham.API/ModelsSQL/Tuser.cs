using System;
using System.Collections.Generic;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class Tuser
{
    public Guid Iduser { get; set; }

    public string? ImageUrl { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public DateTime? Birth { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsUser { get; set; }

    public bool? IsBlogger { get; set; }

    public DateTime? CreateAt { get; set; }
}
