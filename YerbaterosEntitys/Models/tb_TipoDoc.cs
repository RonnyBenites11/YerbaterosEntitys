//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YerbaterosEntitys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_TipoDoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TipoDoc()
        {
            this.tb_Cliente = new HashSet<tb_Cliente>();
        }
    
        public int Cod_TipoDoc { get; set; }
        public string Descripcion_TipoDoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Cliente> tb_Cliente { get; set; }
    }
}
