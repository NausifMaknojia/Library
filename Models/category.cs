using System;
using System.ComponentModel.DataAnnotations;

namespace Library1.Models
{
	public class Category
	{
		public Category()
		{
		}

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1,100,ErrorMessage ="Order between 1 to 100")]
        public int DisplayOrder { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

 