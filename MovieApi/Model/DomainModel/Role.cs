using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
