﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealMVCApp.Models
{
    //Movies table here 
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        //Required and Error message tags
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        //Setting range for Year to be 1888 to any year in the future.
        [Required(ErrorMessage = "Year is Required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited field is required")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "CopiedToPlex is required.")]
        //Setting max length to 25 for notes
        public bool CopiedToPlex { get; set; }
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        //Setting the Foreign key for Category

        [ForeignKey("CategoryId")]
        
        public Category Category { get; set; }
    }
}
