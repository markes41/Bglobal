using Bglobal.Web.Models.Comunes;
using System.ComponentModel.DataAnnotations;

namespace Bglobal.Web.ViewModels
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Patente es obligatorio")]
        public string Patente { get; set; }
        [Required(ErrorMessage = "El campo Marca es obligatorio")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El campo Modelo es obligatorio")]
        public string Modelo { get; set; }
        [Range(1, 8, ErrorMessage = "Debe elegir entre {1} y {2} puertas.")]
        public int Puertas { get; set; }
        [Display(Name = "Titular")]
        public int Id_Titular { get; set; }
        public Titular Titular { get; set; }
        public List<Titular> Titulares { get; set; }
    }
}
