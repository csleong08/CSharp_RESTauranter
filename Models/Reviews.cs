using System;
using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;


namespace RESTauranter.Models
{
    public class Reviews
    {
        [Key]
        public long idreviews { get; set; }
        [Required]
        public string reviewer { get; set; }
        [Required]
        public string restaurant { get; set; }
        [Required]
        [MinLength(10)]
        // [Display(Name = "REVIEW")]
        public string review { get; set; }
        [Required]
        public DateTime visitdate { get; set; }
        [Required]
        public int star { get; set; }
        [Required]
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
        [Required]
        public DateTime created_at { get; set; }
    }
}