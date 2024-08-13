using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Actors
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName {get; set;}
        public DateTime Birthdate {get; set;}
        public bool Sex {get; set;}
        public string Country {get; set;}
        public string Avatar { get; set; }
    }
}
