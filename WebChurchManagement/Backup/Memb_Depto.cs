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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Memb_Depto
    {
        public int Id_Memb { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        public int Id_Deptos { get; set; }
        public DateTime Dt_Ini { get; set; }
        public DateTime Dt_Fim { get; set; }
        [DefaultValue(true)]
        public bool Lider { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        public virtual Departamentos Departamentos { get; set; }
        public virtual Membros Membros { get; set; }
    }
}
