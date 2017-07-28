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
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Disciplinas")]
    public partial class Disciplina
    {
        [Key]
        [DisplayName("Id Disciplina")]
        public int Id_Disc { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        [DisplayName("Id Membro")]
        public int Id_Membros { get; set; }
        [MaxLength(50, ErrorMessage = "Campo deve conter no m�ximo 50 caracteres.")]
        [DisplayName("Motivo")]
        public string Motivo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", HtmlEncode = true)]
        [DisplayName("Inicio")]
        public DateTime Dt_Ini { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", HtmlEncode = true)]
        [DisplayName("Fim")]
        public DateTime Dt_Fim { get; set; }

        public virtual Membro Membros { get; set; }
    }
}
