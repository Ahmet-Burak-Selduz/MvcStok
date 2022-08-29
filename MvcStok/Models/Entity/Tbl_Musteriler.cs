//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Tbl_Musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Musteriler()
        {
            this.Tbl_Satislar = new HashSet<Tbl_Satislar>();
        }
    
        public int MusteriId { get; set; }

        [Required(ErrorMessage = "M��teri Ad�n� Giriniz.")]
        [StringLength(50,ErrorMessage ="Ad Alan� 0-50 Karakter Olmal�")]
        public string MusteriAd { get; set; }

        [Required(ErrorMessage = "M��teri Soyad�n� Giriniz.")]
        [StringLength(50, ErrorMessage = "Soyad Alan� 0-50 Karakter Olmal�")]
        public string MusteriSoyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Satislar> Tbl_Satislar { get; set; }
    }
}