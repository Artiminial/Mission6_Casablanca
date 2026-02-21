using System.ComponentModel.DataAnnotations;

namespace Mission6_Casablanca.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

    }
}
