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
    
    public partial class inf_usr_bancario
    {
        public System.Guid usr_bancario_ID { get; set; }
        public Nullable<int> banco_ID { get; set; }
        public string tarjeta { get; set; }
        public string clabe { get; set; }
        public string complementos { get; set; }
        public System.Guid usuario_ID { get; set; }
    
        public virtual fact_banco fact_banco { get; set; }
        public virtual inf_usuario inf_usuario { get; set; }
    }
}
