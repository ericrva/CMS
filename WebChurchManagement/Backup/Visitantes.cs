//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebChurchManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Visitantes
    {
        public int Id_Visit { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        [MaxLength(50, ErrorMessage = "Campo deve conter no m�ximo 50 caracteres.")]
        public string Nm_Visit { get; set; }
        public DateTime Dt_Nasc { get; set; }
        public string Tel { get; set; }
    }
}
