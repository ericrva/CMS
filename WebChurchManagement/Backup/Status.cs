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

    public partial class Status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status()
        {
            this.Membros = new HashSet<Membros>();
        }

        public int Id_Status { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        [MaxLength(15, ErrorMessage = "Campo deve conter no m�ximo 15 caracteres.")]
        public string Nm_Status { get; set; }
        [Required(ErrorMessage = "Campo n�o pode ser nulo.")]
        [MaxLength(50, ErrorMessage = "Campo deve conter no m�ximo 50 caracteres.")]
        public string Desc_Status { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membros> Membros { get; set; }
    }
}
