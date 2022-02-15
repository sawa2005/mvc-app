using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models {
    public class CourseModel {
        // Properties
        [Display(Name = "Kurskod:")]
        [Required(ErrorMessage = "Ange en kurskod.")]
        public string? Code { get; set; }

        [Display(Name = "Kursnamn:")]
        [Required(ErrorMessage = "Ange ett namn.")]
        public string? Name { get; set; }

        [Display(Name = "URL till kurs:")]
        [Required(ErrorMessage = "Ange en URL till kursen.")]
        public string? Url { get; set; }

        [Display(Name = "Kursens progression:")]
        [Required(ErrorMessage = "Ange korrekt progression.")]
        [MaxLength(2)]
        public string? Progression { get; set; }
    }
}