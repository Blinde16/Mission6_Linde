using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealMVCApp.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieFormId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }
    }
}
