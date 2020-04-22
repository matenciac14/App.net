using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoNetCore.Models
{
    public class SucursalCLS
    {
        [Display(Name="ID Sucursal")]
        public int iidsucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [StringLength(100,ErrorMessage ="Longitud maxima es 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Direccion Sucursal")]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Telefono Sucursal")]
        [StringLength(10, ErrorMessage = "Longitud maxima es 10")]
        [Required]
        public string telefono { get; set; }

        [Display(Name = "Email Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud maxima es 100")]
        [EmailAddress(ErrorMessage ="Ingrese un email Valido")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Fecha Apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Required]
        public DateTime fechaapertura { get; set; }


        public int bhabilitado { get; set; }
    }
}