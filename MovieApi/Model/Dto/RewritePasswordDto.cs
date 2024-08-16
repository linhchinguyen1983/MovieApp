using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class RewritePasswordDto
    {
        [Required(ErrorMessage ="New Password cannot be blank!")]
        public string NewPassword { get; set; }
    }
}
