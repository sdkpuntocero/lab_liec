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
    
    public partial class inf_usr_rh
    {
        public System.Guid usr_rh_ID { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public int area_ID { get; set; }
        public int perfil_ID { get; set; }
        public string jefe_inmediato { get; set; }
        public string comentarios { get; set; }
        public System.Guid usuario_ID { get; set; }
        public Nullable<System.DateTime> registro { get; set; }
    
        public virtual fact_area fact_area { get; set; }
        public virtual fact_perfil fact_perfil { get; set; }
        public virtual inf_usuario inf_usuario { get; set; }
    }
}
