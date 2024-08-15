using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid MoviesId { get; set; }

        public Movies Movies { get; set; }
    }
}
