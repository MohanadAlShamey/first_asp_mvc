using System.ComponentModel.DataAnnotations;

namespace first_asp_mvc.Models
{
    public class CategoryApplication
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }


    }
}
