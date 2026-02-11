using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;
        
        [StringLength(13)]
        public string? ISBN { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
        
        [Range(1, 10000)]
        public int Pages { get; set; }
        
        [StringLength(50)]
        public string? Genre { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
