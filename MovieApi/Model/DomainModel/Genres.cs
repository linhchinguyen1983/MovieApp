using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Genres
    {
        [Key]
        public Guid Id {  get; set; }

        private string _name;
    }
}
