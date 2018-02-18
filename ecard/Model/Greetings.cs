using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecard.Model
{
    public class Greetings
    {
        [Key]
        public int? ID { get; set; }

        [DisplayName("Your Friends Name")]
        [Display(Prompt = "Your friend's name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string friendsName { get; set; }

        [DisplayName("Your Friends Email Address")]
        [Display(Prompt = "Your friend's Email Address")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string friendsEmail { get; set; }

        [DisplayName("Your Subject")]
        [Display(Prompt = "Subject")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string subject { get; set; }

        [DisplayName("Your Message")]
        [Display(Prompt = "Enter your Message here")]
        [Required(ErrorMessage = "Required")]
        [StringLength(140, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string message { get; set; }

        [DisplayName("Your Name")]
        [Display(Prompt = "Your Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string yourName { get; set; }

        [DisplayName("Your Email Address")]
        [Display(Prompt = "Your Email Address")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string yourEmail { get; set; }


    }
}
