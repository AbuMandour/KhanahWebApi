using System;
using System.ComponentModel.DataAnnotations;
namespace Khanah.Api.Models
{
    public class Quote
    {         
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
    }
}