﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bd_labEntities : DbContext
    {
        public bd_labEntities()
            : base("name=bd_labEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fact_alergia> fact_alergia { get; set; }
        public virtual DbSet<fact_area> fact_area { get; set; }
        public virtual DbSet<fact_banco> fact_banco { get; set; }
        public virtual DbSet<fact_concreto_est> fact_concreto_est { get; set; }
        public virtual DbSet<fact_concreto_situacion> fact_concreto_situacion { get; set; }
        public virtual DbSet<fact_concreto_tipo> fact_concreto_tipo { get; set; }
        public virtual DbSet<fact_ensaye_esp_est> fact_ensaye_esp_est { get; set; }
        public virtual DbSet<fact_especimen_tipo> fact_especimen_tipo { get; set; }
        public virtual DbSet<fact_est_clte> fact_est_clte { get; set; }
        public virtual DbSet<fact_est_clte_obra_rpt> fact_est_clte_obra_rpt { get; set; }
        public virtual DbSet<fact_est_obra> fact_est_obra { get; set; }
        public virtual DbSet<fact_est_usr> fact_est_usr { get; set; }
        public virtual DbSet<fact_estcivil> fact_estcivil { get; set; }
        public virtual DbSet<fact_genero> fact_genero { get; set; }
        public virtual DbSet<fact_perfil> fact_perfil { get; set; }
        public virtual DbSet<fact_prosp_est> fact_prosp_est { get; set; }
        public virtual DbSet<fact_prosp_giro> fact_prosp_giro { get; set; }
        public virtual DbSet<fact_prosp_taccion> fact_prosp_taccion { get; set; }
        public virtual DbSet<fact_prosp_tcont> fact_prosp_tcont { get; set; }
        public virtual DbSet<fact_prosp_tserv> fact_prosp_tserv { get; set; }
        public virtual DbSet<fact_tipo_escolar> fact_tipo_escolar { get; set; }
        public virtual DbSet<fact_tipo_rfc> fact_tipo_rfc { get; set; }
        public virtual DbSet<fact_tipo_servicio> fact_tipo_servicio { get; set; }
        public virtual DbSet<inf_clte> inf_clte { get; set; }
        public virtual DbSet<inf_clte_contacto> inf_clte_contacto { get; set; }
        public virtual DbSet<inf_clte_obra_rpt> inf_clte_obra_rpt { get; set; }
        public virtual DbSet<inf_clte_obras> inf_clte_obras { get; set; }
        public virtual DbSet<inf_emp> inf_emp { get; set; }
        public virtual DbSet<inf_ensaye_esp> inf_ensaye_esp { get; set; }
        public virtual DbSet<inf_prosp_cont> inf_prosp_cont { get; set; }
        public virtual DbSet<inf_prosp_seg> inf_prosp_seg { get; set; }
        public virtual DbSet<inf_prospectos> inf_prospectos { get; set; }
        public virtual DbSet<inf_rpc> inf_rpc { get; set; }
        public virtual DbSet<inf_sepomex> inf_sepomex { get; set; }
        public virtual DbSet<inf_usr_bancario> inf_usr_bancario { get; set; }
        public virtual DbSet<inf_usr_contacto> inf_usr_contacto { get; set; }
        public virtual DbSet<inf_usr_escolar> inf_usr_escolar { get; set; }
        public virtual DbSet<inf_usr_medicos> inf_usr_medicos { get; set; }
        public virtual DbSet<inf_usr_personales> inf_usr_personales { get; set; }
        public virtual DbSet<inf_usr_rh> inf_usr_rh { get; set; }
        public virtual DbSet<inf_usuario> inf_usuario { get; set; }
    }
}
