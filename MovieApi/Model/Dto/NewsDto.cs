using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class NewsDto
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
