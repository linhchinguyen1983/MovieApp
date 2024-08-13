using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Genres
    {
        [Key]
        public Guid Id {  get; set; }
        public string Name { get; set; }
    }
}
