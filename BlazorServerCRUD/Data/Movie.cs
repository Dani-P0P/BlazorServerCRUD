namespace BlazorServerCRUD.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
    }
}
