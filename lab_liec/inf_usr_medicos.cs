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
    
    public partial class inf_usr_medicos
    {
        public System.Guid usr_medicos_ID { get; set; }
        public string estatura { get; set; }
        public string peso { get; set; }
        public string tipo_sangre { get; set; }
        public Nullable<int> alergia_ID { get; set; }
        public string alergia { get; set; }
        public string tratamiento { get; set; }
        public System.Guid usuario_ID { get; set; }
    
        public virtual fact_alergia fact_alergia { get; set; }
        public virtual inf_usuario inf_usuario { get; set; }
    }
}
