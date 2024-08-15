using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Model.DomainModel
{
    public class Movies
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int AgeRating{get; set;}
        public int Status { get; set; } = 1;
        public string Poster { get; set; }
        public int ExpectedEpisode {  get; set; }
        public bool Type { get; set;}
        //true : phim bo, false : phim le 
        [NotMapped]
        public bool SetType { set => Type = ExpectedEpisode > 1; }


    }
}
