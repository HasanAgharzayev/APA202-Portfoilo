using System.ComponentModel.DataAnnotations;

namespace SoftLanding.Areas.AdminPanel.ViewModels
{
    public class CreatePeopleVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]

        public string Job { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Description { get; set; }
    }
}
