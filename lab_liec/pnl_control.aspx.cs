using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab_liec
{
    public partial class pnl_control : System.Web.UI.Page
    {
        public static Guid guid_emp;
        public static Guid guid_idusr;
        static private int int_idperf = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    inf_usr_oper();
                }
                else
                {
                }
            }
            catch
            {
                Response.Redirect("acceso.aspx");
            }
        }

        private void inf_usr_oper()
        {
            guid_idusr = (Guid)(Session["ss_idusr"]);

            using (bd_labEntities m_usuario = new bd_labEntities())
            {
                var i_usuario = (from i_u in m_usuario.inf_usuario
                                 join i_up in m_usuario.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                 join i_uh in m_usuario.inf_usr_rh on i_u.usuario_ID equals i_uh.usuario_ID
                                 join i_pu in m_usuario.fact_perfil on i_uh.perfil_ID equals i_pu.perfil_ID
                                 join i_e in m_usuario.inf_emp on i_u.empresa_ID equals i_e.empresa_ID
                                 where i_u.usuario_ID == guid_idusr
                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.cod_usr,
                                     i_up.nombres,
                                     i_up.apaterno,
                                     i_up.amaterno,
                                     i_pu.perfil_desc,
                                     i_pu.perfil_ID,
                                     i_e.empresa_ID,
                                     i_e.empresa_nom

                                 }).FirstOrDefault();

                lbl_usr_oper.Text = i_usuario.nombres + " " + i_usuario.apaterno + " " + i_usuario.amaterno;
                lbl_tusr.Text = i_usuario.perfil_desc;
                int_idperf = i_usuario.perfil_ID;
                lbl_emp_oper.Text = i_usuario.empresa_nom;
                guid_emp = Guid.Parse(i_usuario.empresa_ID.ToString());
            }
        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }

        #region menu
        protected void lkb_arqu_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_cali_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_capt_Click(object sender, EventArgs e)
        {
            pnl_desa_tec.Visible = false;
            pnl_desa_tec.Focus();
            up_desa_tec.Update();

            pnl_cont.Visible = false;
            pnl_cont.Focus();
            up_cont.Update();

            pnl_recu_hum.Visible = false;
            pnl_recu_hum.Focus();
            up_recu_hum.Update();

            pnl_capt.Visible = true;
            pnl_capt.Focus();
            up_capt.Update();
        }

        protected void lkb_cobr_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_cont_Click(object sender, EventArgs e)
        {
            pnl_recu_hum.Visible = false;
            pnl_recu_hum.Focus();
            up_recu_hum.Update();

            pnl_cont.Visible = true;
            pnl_cont.Focus();
            up_cont.Update();

            pnl_desa_tec.Visible = false;
            pnl_desa_tec.Focus();
            up_desa_tec.Update();

            pnl_capt.Visible = false;
            pnl_capt.Focus();
            up_capt.Update();
        }

        protected void lkb_coor_labcent_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_desa_tec_Click(object sender, EventArgs e)
        {
            pnl_recu_hum.Visible = false;
            pnl_recu_hum.Focus();
            up_recu_hum.Update();

            pnl_cont.Visible = false;
            pnl_cont.Focus();
            up_cont.Update();

            pnl_capt.Visible = false;
            pnl_capt.Focus();
            up_capt.Update();

            pnl_desa_tec.Visible = true;
            pnl_desa_tec.Focus();
            up_desa_tec.Update();
        }

        protected void lkb_desa_neg_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_estr_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_gere_adm_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_gere_cal_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_gere_gen_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_gere_tec_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_mant_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_meca_sue_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_pers_obra_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_recep_Click(object sender, EventArgs e)
        {

        }

        protected void lkb_recu_hum_Click(object sender, EventArgs e)
        {
            pnl_desa_tec.Visible = false;
            pnl_desa_tec.Focus();
            up_desa_tec.Update();

            pnl_cont.Visible = false;
            pnl_cont.Focus();
            up_cont.Update();



            pnl_capt.Visible = false;
            pnl_capt.Focus();
            up_capt.Update();
            pnl_recu_hum.Visible = true;
            pnl_recu_hum.Focus();
            up_recu_hum.Update();

        }

        protected void lkb_supe_Click(object sender, EventArgs e)
        {

        }


        #endregion

        protected void lkb_recu_hum_i_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_recursos_humanos.aspx");
        }

        protected void lkb_cont_i_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_cont.aspx");
        }

        protected void lkb_desa_tec_i_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_desa_tec.aspx");
        }

        protected void lkb_capt_i_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_captura.aspx");
        }
    }
}