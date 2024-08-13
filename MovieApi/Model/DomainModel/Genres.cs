using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Genres
    {
        [Key]
        public Guid Id {  get; set; }
        public string Name { get; set; }
        // set defaul valuse Status = 1
        public int Status { get; set; } = 1;
        public Genres() { Status = 1; }
    }
}
