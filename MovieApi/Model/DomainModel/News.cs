using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Image { get; set; }
        public int Status { get; set; } = 1;
        public News() { Status = 1; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

    }
}
