//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab_liec
{
    using System;
    using System.Collections.Generic;
    
    public partial class fact_ensaye_esp_est
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fact_ensaye_esp_est()
        {
            this.inf_ensaye_esp = new HashSet<inf_ensaye_esp>();
        }
    
        public int ensaye_esp_est_ID { get; set; }
        public string ensaye_esp_est_desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_ensaye_esp> inf_ensaye_esp { get; set; }
    }
}
