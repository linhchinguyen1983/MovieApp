using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Genres
    {
        [Key]
        public Guid Id {  get; set; }

        private string _name;

        public string Name { get { return _name; } set { _name = value; } }
    }
}
