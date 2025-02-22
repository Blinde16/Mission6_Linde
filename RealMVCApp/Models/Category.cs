using System.ComponentModel.DataAnnotations;

namespace RealMVCApp.Models
{
    //Category Table class here. 
    public class Category
    {
        [Key]

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
