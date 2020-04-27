using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoNetCore.Models
{
    public class ClienteCLS
    {
        [Display(Name="ID Cliente")]
        public int iidcliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        [StringLength(100,ErrorMessage ="Longitud maxima es 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(150, ErrorMessage = "Longitud maxima es 150")]
        [Required]
        public string appaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(150, ErrorMessage = "Longitud maxima es 150")]
        [Required]
        public string apmaterno { get; set; }

        [Display(Name = "Email")]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        [EmailAddress(ErrorMessage = "Ingrese un Email Valido")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }

        public string telefonofijo { get; set; }

        [Display(Name = "Celular")]
        [StringLength(10, ErrorMessage = "Longitud maxima es 10")]
        [Required]
        public string telefonocelular { get; set; }
        public int bhabilitado { get; set; }
    }
}