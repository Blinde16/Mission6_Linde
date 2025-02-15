using System.ComponentModel.DataAnnotations;

namespace RealMVCApp.Models
{
    public class Application
    {
        [Key]
        public int MovieFormID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }


    }
}
