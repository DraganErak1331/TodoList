using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    //each item requires a preset id and a description
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
