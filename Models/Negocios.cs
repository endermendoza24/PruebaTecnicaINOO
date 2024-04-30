namespace PruebaTecnicaIOON.Models
{
    public class Negocios
    {
        public int NegociosId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string RUC { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
