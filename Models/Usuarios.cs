using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaIOON.Models
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string  Pass { get; set; }
        public Negocios Negocios { get; set; }

    }
}
