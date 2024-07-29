using System.ComponentModel.DataAnnotations;
using System.Web;

namespace login_app.Models
{
    public class UserProfileViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

         [Display(Name = "Profile Image")]
        public HttpPostedFileBase ProfileImage { get; set; }

         public string ProfileImagePath { get; set; }
    }
}
