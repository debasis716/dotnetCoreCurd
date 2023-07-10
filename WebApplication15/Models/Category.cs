using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage="Display Order must be between 1-1000")]
        public int DisplayOrder { get; set; }
    }
}
