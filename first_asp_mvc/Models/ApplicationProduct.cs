using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first_asp_mvc.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class ApplicationProduct
    {
        [Key]
        public Guid Id { get; set; }
        
        public string  Name{ get; set; }
        public double  price{ get; set; }
        public string  description{ get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryApplication CategoryApplication { get; set; }
        public Guid? CategoryId { get; set; }

    }
}
