using System.ComponentModel.DataAnnotations;

namespace SoftLanding.Areas.AdminPanel.ViewModels
{
    public class UpdatePeopleVM
    {
        
        public IFormFile? Photo { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength (30)]
        public string Job { get; set; }
        [Required]
        [MinLength (3)]
        [MaxLength(80)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
