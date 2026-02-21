using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mission6_Casablanca.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "You need to select a category")]
        public int? CategoryId { get; set; }   // <- foreign key property

        [ValidateNever]
        public Categories Category { get; set; } // <- navigation property

        public string Title { get; set; }


        [Range(1888, 2026, ErrorMessage = "Year must be between 1888 and 2026.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }
}

