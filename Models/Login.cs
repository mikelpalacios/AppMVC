using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models
{
    public class Login
    {
        [Key]

        public int Id { get; set; } 

        [Required(ErrorMessage = "El link es obligatorio")]

        public string Link { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]

        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]

        public string Contraseña { get; set; }

    }
}
