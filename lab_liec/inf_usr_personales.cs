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
    
    public partial class inf_usr_personales
    {
        public System.Guid usr_personales_ID { get; set; }
        public string nombres { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public int genero_ID { get; set; }
        public int estcivil_ID { get; set; }
        public Nullable<int> hijos { get; set; }
        public Nullable<System.DateTime> cumple { get; set; }
        public string licencia { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public string nss { get; set; }
        public System.Guid usuario_ID { get; set; }
        public Nullable<System.DateTime> registro { get; set; }
    
        public virtual fact_estcivil fact_estcivil { get; set; }
        public virtual fact_genero fact_genero { get; set; }
        public virtual inf_usuario inf_usuario { get; set; }
    }
}
