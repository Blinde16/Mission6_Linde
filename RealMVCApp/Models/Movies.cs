using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealMVCApp.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string LentTo { get; set; }
        public bool CopiedToPlex { get; set; }
        public string Notes { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
