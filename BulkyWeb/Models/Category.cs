using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Display Order Should Be Between 1 to 100")]
        public int Display {  get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
