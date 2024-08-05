using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        // Navigate Properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
