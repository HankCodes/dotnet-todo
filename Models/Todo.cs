using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoApp.Models.Enums;

namespace TodoApp.Models
{

    [Table("Todo")]
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "An item must have a title.")]
        [MaxLength(50, ErrorMessage = "A title cannot be longer than 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "An item must have a description.")]
        [MaxLength(500, ErrorMessage = "A description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; } = "ToBeDone";
    }
}
