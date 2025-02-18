using System.ComponentModel.DataAnnotations;

namespace RealMVCApp.Models
{
    public class Category
    {
        [Key]

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
