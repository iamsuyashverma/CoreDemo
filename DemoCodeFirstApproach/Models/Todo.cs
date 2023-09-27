using System.ComponentModel.DataAnnotations;

namespace DemoCodeFirstApproach.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        [Required]
        public string TaskDescription { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
