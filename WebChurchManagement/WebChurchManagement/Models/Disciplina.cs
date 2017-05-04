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
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Disciplinas")]
    public partial class Disciplina
    {
        [Key]
        public int Id_Disc { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        public int Id_Memb { get; set; }
        [MaxLength(50, ErrorMessage = "Campo deve conter no m�ximo 50 caracteres.")]
        public string Motivo { get; set; }
        public DateTime Dt_Ini { get; set; }
        public DateTime Dt_Fim { get; set; }

        public virtual Membro Membros { get; set; }
    }
}