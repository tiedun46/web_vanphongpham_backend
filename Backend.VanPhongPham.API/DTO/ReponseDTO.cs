namespace Backend.VanPhongPham.API.DTO
{
    public class ReponseDTO
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Description{ get; set; }
        public bool? isSuccess { get; set; }
    }
}
