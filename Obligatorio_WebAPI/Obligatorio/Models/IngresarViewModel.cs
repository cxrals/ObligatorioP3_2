using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models {
    public class IngresarViewModel {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
