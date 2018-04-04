using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ecard.Model
{
    public class Questions
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("1. How would you describe your experience with computer programming / web development? ")]
        [Display(Prompt = "Your experience")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string experience { get; set; }

        [DisplayName("2. What day would prefer to attend a study session?")]
        [Display(Prompt = "Preferd Date")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string attend { get; set; }

        [DisplayName("3. What would you like to study?")]
        [Display(Prompt = "Like to Study")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string study { get; set; }

        [DisplayName("4. What would you like to learn how to create?")]
        [Display(Prompt = "Your response")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string learn { get; set; }

        [DisplayName("5. Please describe any projects you have built in the past?")]
        [Display(Prompt = "Projects in the past")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string projects { get; set; }

        [DisplayName("6. Aside from our in-person study hours, how many hour(s) per week do you plan to spend studying on your own?")]
        [Display(Prompt = "Hours studying")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string studying { get; set; }

        [DisplayName("7. Would you like to eat afterwards?")]
        [Display(Prompt = "Eat after?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string eat { get; set; }

        [DisplayName("8. Where are you comimg from ?")]
        [Display(Prompt = "From")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string comingfrom { get; set; }

        [DisplayName("9. Any additional comments or quesitons you would like to share?")]
        [Display(Prompt = "Your comments")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string comments { get; set; }




        public string created { get; set; }

        public string created_ip { get; set; }
    }
}
