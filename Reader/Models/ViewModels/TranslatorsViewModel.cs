using System.ComponentModel.DataAnnotations;

namespace Reader.Models.ViewModels
{
    public class TranslatorsCreateViewModel
    {
        public int TranslatorID { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage = "Entering the name is required.")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Entering the lastname is required.")]
        public string Family { get; set; }
    }
}
