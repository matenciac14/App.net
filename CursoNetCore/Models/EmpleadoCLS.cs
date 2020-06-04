using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoNetCore.Models
{
    public class EmpleadoCLS
    {
        public  int iidempleado { get; set; }

        [Display(Name = "Nombre Empleado")]
        [StringLength(100, ErrorMessage = "Longitud maxima es 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        [Required]
        public string appaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        [Required]
        public string apmaterno { get; set; }

        [Display(Name = "Fecha de Contrato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechacontrato { get; set; }

        [Display(Name = "Sueldo")]
        [Required]
        public decimal sueldo { get; set; }

        [Display(Name = "Tipo Usuario")]
        [StringLength(4, ErrorMessage = "Longitud maxima es 4")]
        [Required]
        public int iidtipousuario { get; set; }

        [Display(Name = "Tipo contrato")]
        [StringLength(4, ErrorMessage = "Longitud maxima es 4")]
        [Required]
        public int iidtipocontrato { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(4, ErrorMessage = "Longitud maxima es 4")]
        [Required]
        public int iidsexo { get; set; }


        /////propiedades adicionales
        public string nombreTipoContrato { get; set; }
        public string nombretipoUsuario { get; set; }


    }
}