using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab_liec
{
    public partial class pnl_captura : System.Web.UI.Page
    {
        public static int int_rppc, int_ensa_comp, int_idperf, int_dem = 0, int_est_esp = 0, int_prosp, int_clte, int_clte_obra, int_clte_cont;
        public static string str_clte, str_usr_oper, str_pnlID = null, nc = null;
        public static Guid guid_emp;
        public static Guid guid_idusr, usr_ID, guclte_ID;
        public static DateTime dt_fechacolado;

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

        [ScriptMethod()]
        [WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            List<String> columnData = new List<String>();
            string str_usr = prefixText.ToUpper();
            if (str_pnlID == "pnl_prosp")
            {
                string f_clte = prefixText.ToUpper();

                using (bd_labEntities m_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in m_usr.inf_prospectos

                                 where i_u.empresa.Contains(f_clte)
                                 select new
                                 {
                                     i_u.empresa,
                                     i_u.cod_prospecto,
                                 }).ToList();

                    foreach (var ff_usr in i_usr)
                    {
                        columnData.Add(ff_usr.empresa + " | " + ff_usr.cod_prospecto);
                    }
                }
            }
            else if (str_pnlID == "pnl_clte")
            {
                string f_clte = prefixText.ToUpper();

                using (bd_labEntities m_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in m_usr.inf_clte

                                 where i_u.razon_social.Contains(f_clte)
                                 select new
                                 {
                                     i_u.razon_social,
                                     i_u.cod_clte,
                                 }).ToList();

                    foreach (var ff_usr in i_usr)
                    {
                        columnData.Add(ff_usr.razon_social + " | " + ff_usr.cod_clte);
                    }
                }
            }
            else if (str_pnlID == "pnl_clte_obras")
            {
                string f_clte = prefixText.ToUpper();

                using (bd_labEntities m_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in m_usr.inf_clte_obras
                                 join i_up in m_usr.inf_clte on i_u.clte_ID equals i_up.clte_ID
                                 where i_u.clave_obra.Contains(f_clte)
                                 select new
                                 {
                                     i_u.clave_obra,
                                     i_up.razon_social,
                                     i_up.cod_clte
                                 }).ToList();

                    foreach (var ff_usr in i_usr)
                    {
                        columnData.Add(ff_usr.clave_obra + " | " + ff_usr.razon_social + " | " + ff_usr.cod_clte);
                    }
                }
            }
            return columnData;
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "LIEC";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        #region menu

        private void load_ddl()
        {
            ddl_colonia_clte.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddl_colonia_clte.BackColor = Color.FromArgb(211, 211, 211);
            ddl_colonia_clte.ForeColor = Color.FromArgb(16, 77, 141);
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

        protected void lkb_regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_control.aspx");
        }

        protected void lkb_prosp_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_prosp";
            int_prosp = 0;

            lkb_prosp.Attributes["style"] = "color:#104D8d";

            lkb_clte.Attributes["style"] = "color:#E34C0E";

            lkb_clte_obras.Attributes["style"] = "color:#E34C0E";

            lkb_concreto.Attributes["style"] = "color:#E34C0E";

            lkb_conc_ensaye.Attributes["style"] = "color:#E34C0E";

            lkb_regresar.Attributes["style"] = "color:#E34C0E";

            lkb_salir.Attributes["style"] = "color:#E34C0E";

            i_agregar_prospecto.Attributes["style"] = "color:white";
            i_editar_prospecto.Attributes["style"] = "color:white";

            limp_prosp_ctrl();

            div_nav_prospectos.Visible = true;
            div_nav_clte.Visible = false;
            div_nav_clte_cont.Visible = false;
            div_nav_clte_obras.Visible = false;

            up_prospectos.Update();
            up_clte.Update();
            up_clte_obras.Update();
        }

        private void limp_prosp_ctrl()
        {
        }

        protected void lkb_clte_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_clte";
            int_clte = 0;

            lkb_prosp.Attributes["style"] = "color:#E34C0E";

            lkb_clte.Attributes["style"] = "color:#104D8d";

            lkb_clte_obras.Attributes["style"] = "color:#E34C0E";

            lkb_concreto.Attributes["style"] = "color:#E34C0E";

            lkb_conc_ensaye.Attributes["style"] = "color:#E34C0E";

            lkb_conc_ensaye.Attributes["style"] = "color:#E34C0E";

            lkb_regresar.Attributes["style"] = "color:#E34C0E";

            lkb_salir.Attributes["style"] = "color:#E34C0E";

            lkb_clte_ctrl.Attributes["style"] = "color:#E34C0E";
            lkb_clte_cont.Attributes["style"] = "color:#E34C0E";

            i_clte_agregar.Attributes["style"] = "color:white";
            i_clte_editar.Attributes["style"] = "color:white";

            i_clte_contacto_agregar.Attributes["style"] = "color:white";
            i_clte_contacto_editar.Attributes["style"] = "color:white";

            limp_clte_ctrl();

            div_nav_prospectos.Visible = false;
            div_nav_clte.Visible = true;
            div_nav_clte_cont.Visible = false;
            div_nav_clte_obras.Visible = false;
            up_prospectos.Update();
            up_clte.Update();
            up_clte_obras.Update();
        }

        protected void lkb_clte_obras_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_clte";
            int_clte_obra = 0;

            lkb_prosp.Attributes["style"] = "color:#E34C0E";

            lkb_clte.Attributes["style"] = "color:#E34C0E";

            lkb_clte_obras.Attributes["style"] = "color:#104D8d";

            lkb_concreto.Attributes["style"] = "color:#E34C0E";

            lkb_conc_ensaye.Attributes["style"] = "color:#E34C0E";

            lkb_regresar.Attributes["style"] = "color:#E34C0E";

            lkb_salir.Attributes["style"] = "color:#E34C0E";

            i_agregar_clte_obras.Attributes["style"] = "color:white";
            i_editar_clte_obras.Attributes["style"] = "color:white";

            limp_clte_obras_ctrl();

            div_nav_prospectos.Visible = false;
            div_nav_clte.Visible = false;
            div_nav_clte_cont.Visible = false;
            div_nav_clte_obras.Visible = true;
            up_prospectos.Update();
            up_clte.Update();
            up_clte_contacto.Update();
            up_clte_obras.Update();
        }

        protected void lkb_concreto_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_clte_obras";

            int_rppc = 0;

            lkb_prosp.Attributes["style"] = "color:#E34C0E";

            lkb_clte.Attributes["style"] = "color:#E34C0E";

            lkb_clte_obras.Attributes["style"] = "color:#E34C0E";

            lkb_concreto.Attributes["style"] = "color:#104D8d";

            lkb_conc_ensaye.Attributes["style"] = "color:#E34C0E";

            lkb_regresar.Attributes["style"] = "color:#E34C0E";

            lkb_salir.Attributes["style"] = "color:#E34C0E";

            i_agregar_rppc.Attributes["style"] = "color:white";
            i_editar_rppc.Attributes["style"] = "color:white";

            limp_txt_rppc();

            div_nav_prospectos.Visible = false;
            div_nav_clte.Visible = false;
            div_nav_clte_cont.Visible = false;
            div_nav_clte_obras.Visible = false;
            div_nav_obras_rpc.Visible = true;

            up_prospectos.Update();
            up_clte.Update();
            up_clte_contacto.Update();
            up_clte_obras.Update();
            up_rppc.Update();
        }

        protected void lkb_conc_ensaye_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_clientes";
            int_clte = 1;

            lkb_prosp.Attributes["style"] = "color:#E34C0E";

            lkb_clte.Attributes["style"] = "color:#E34C0E";

            lkb_clte_obras.Attributes["style"] = "color:#E34C0E";

            lkb_concreto.Attributes["style"] = "color:#E34C0E";

            lkb_conc_ensaye.Attributes["style"] = "color:#104D8d";

            lkb_regresar.Attributes["style"] = "color:#E34C0E";

            lkb_salir.Attributes["style"] = "color:#E34C0E";

            i_clte_agregar.Attributes["style"] = "color:white";
            i_clte_editar.Attributes["style"] = "color:white";

            limp_clte_ctrl();

            div_nav_prospectos.Visible = false;
            div_nav_clte.Visible = true;
            up_clte.Update();
            up_prospectos.Update();
        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("acceso.aspx");
        }

        #endregion menu

        #region prospectos

        protected void lkb_prosp_prosp_Click(object sender, EventArgs e)
        {
            lkb_prosp_prosp.Attributes["style"] = "color:#104D8d";
            lkb_prosp_cont.Attributes["style"] = "color:#E34C0E";
            lkb_prosp_seg.Attributes["style"] = "color:#E34C0E";

            txt_buscar_prospecto.Text = null;
            gv_prospecto.Visible = false;

            pnl_prospecto.Visible = true;
        }

        protected void lkb_prosp_cont_Click(object sender, EventArgs e)
        {
        }

        protected void lkb_prosp_seg_Click(object sender, EventArgs e)
        {
        }

        #endregion prospectos

        #region clte

        protected void lkb_clte_ctrl_Click(object sender, EventArgs e)
        {
            lkb_clte_ctrl.Attributes["style"] = "color:#104D8d";
            lkb_clte_cont.Attributes["style"] = "color:#E34C0E";
            txt_buscar_clte.Text = null;
            gv_clte.Visible = false;

            pnl_clte.Visible = true;
            div_nav_clte_cont.Visible = false;
            up_clte.Update();
            up_clte_contacto.Update();
        }

        protected void lkb_clte_cont_Click(object sender, EventArgs e)
        {
            lkb_clte_ctrl.Attributes["style"] = "color:#E34C0E";
            lkb_clte_cont.Attributes["style"] = "color:#104D8d";
            txt_buscar_clte_contacto.Text = null;
            rfv_buscar_clte_contacto.Enabled = true;
            gv_clte.Visible = false;

            int_clte_cont = 0;

            i_clte_contacto_agregar.Attributes["style"] = "color:white";
            i_clte_contacto_editar.Attributes["style"] = "color:white";

            limp_clte_cont_ctrl();

            gv_cltef.Visible = false;
            gv_cltef_cont.Visible = false;
            div_clte_contactof.Visible = false;

            pnl_clte.Visible = false;
            div_nav_clte_cont.Visible = true;
            up_clte.Update();
            up_clte_contacto.Update();
        }

        protected void btn_buscar_clte_Click(object sender, EventArgs e)
        {
            div_clte_f.Visible = false;

            string str_clte = txt_buscar_clte.Text.ToUpper().Trim();

            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  select new
                                  {
                                      t_clte.clte_ID,
                                      t_clte.cod_clte,
                                      t_clte.razon_social,
                                      t_clte.registro
                                  }).OrderBy(x => x.cod_clte).ToList();

                    gv_clte.DataSource = i_clte;
                    gv_clte.DataBind();
                    gv_clte.Visible = true;
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_clte.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_clte
                                       where c.cod_clte == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.clte_ID;

                        var i_cltef = (from t_clte in edm_nclte.inf_clte
                                       where t_clte.clte_ID == guid_usrid
                                       select new
                                       {
                                           t_clte.clte_ID,
                                           t_clte.cod_clte,
                                           t_clte.razon_social,
                                           t_clte.registro
                                       }).OrderBy(x => x.cod_clte).ToList();

                        gv_clte.DataSource = i_cltef;
                        gv_clte.DataBind();
                        gv_clte.Visible = true;

                        if (i_cltef.Count == 0)
                        {
                            gv_clte.DataSource = i_cltef;
                            gv_clte.DataBind();
                            gv_clte.Visible = true;
                            gv_clte.Visible = true;

                            Mensaje("Empresa no encontrado.");
                        }
                        else
                        {
                            gv_clte.DataSource = i_cltef;
                            gv_clte.DataBind();
                            gv_clte.Visible = true;
                            gv_clte.Visible = true;
                        }
                    }
                }
                catch
                {
                    limp_clte_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }

            limp_clte_ctrl();
        }

        protected void btn_clte_agregar_Click(object sender, EventArgs e)
        {
            int_clte = 1;

            i_clte_agregar.Attributes["style"] = "color:#E34C0E";
            i_clte_editar.Attributes["style"] = "color:white";

            rfv_trfc_clte_fisc.Enabled = true;
            rfv_rfc_clte_fisc.Enabled = true;
            rfv_rs.Enabled = true;
            rfv_callenum_clte.Enabled = true;
            rfv_cp_clte.Enabled = true;

            div_busc_clte.Visible = false;

            gv_clte.Visible = false;

            limp_clte_ctrl();
            div_clte_f.Visible = true;
        }

        protected void btn_clte_editar_Click(object sender, EventArgs e)
        {
            int_clte = 2;
            txt_buscar_clte.Text = null;
            i_clte_agregar.Attributes["style"] = "color:white";
            i_clte_editar.Attributes["style"] = "color:#E34C0E";

            rfv_trfc_clte_fisc.Enabled = false;
            rfv_rfc_clte_fisc.Enabled = false;
            rfv_rs.Enabled = false;
            rfv_callenum_clte.Enabled = false;
            rfv_cp_clte.Enabled = false;
            rfv_colonia_clte.Enabled = false;

            div_busc_clte.Visible = true;

            rfv_buscar_clte.Enabled = true;
            div_clte_f.Visible = false;
            limp_clte_ctrl();
        }

        protected void chkb_desactivar_clte_CheckedChanged(object sender, EventArgs e)
        {
            int_clte = 0;
            i_clte_agregar.Attributes["style"] = "color:white";
            i_clte_editar.Attributes["style"] = "color:white";

            rfv_buscar_clte.Enabled = false;

            rfv_trfc_clte_fisc.Enabled = false;
            rfv_rfc_clte_fisc.Enabled = false;
            rfv_rs.Enabled = false;
            rfv_callenum_clte.Enabled = false;
            rfv_cp_clte.Enabled = false;
            rfv_colonia_clte.Enabled = false;
            rfv_clte_coment.Enabled = false;
            limp_clte_ctrl();
            gv_clte.Visible = false;
        }

        protected void gv_clte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  where t_clte.clte_ID == str_clteID
                                  select new
                                  {
                                      t_clte.est_clte_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_clte_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_clte_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_clte
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "desc_est_clte";
                    DropDownList1.DataValueField = "est_clte_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_clte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in edm_clte.inf_clte
                                  where t_clte.clte_ID == guclte_ID
                                  select new
                                  {
                                      t_clte.tipo_rfc_ID,
                                      t_clte.rfc,
                                      t_clte.razon_social,
                                      t_clte.telefono,
                                      t_clte.email,
                                      t_clte.callenum,
                                      t_clte.d_codigo,
                                      t_clte.id_asenta_cpcons,
                                      t_clte.comentarios
                                  }).FirstOrDefault();

                    ddl_trfc_clte_fisc.SelectedValue = i_clte.tipo_rfc_ID.ToString();
                    txt_rfc_clte_fisc.Text = i_clte.rfc;
                    txt_rs.Text = i_clte.razon_social;
                    txt_telefono_clte.Text = i_clte.telefono;
                    txt_email_clte.Text = i_clte.email;
                    txt_callenum_clte.Text = i_clte.callenum;
                    txt_cp_clte.Text = i_clte.d_codigo;
                    txt_clte_coment.Text = i_clte.comentarios;

                    string str_dcodigo = i_clte.d_codigo;
                    try
                    {
                        string int_col = i_clte.id_asenta_cpcons.ToString();

                        using (bd_labEntities db_sepomex = new bd_labEntities())
                        {
                            var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                               where c.id_asenta_cpcons == int_col
                                               where c.d_codigo == str_dcodigo
                                               select c).ToList();

                            ddl_colonia_clte.DataSource = tbl_sepomex;
                            ddl_colonia_clte.DataTextField = "d_asenta";
                            ddl_colonia_clte.DataValueField = "id_asenta_cpcons";
                            ddl_colonia_clte.DataBind();

                            txt_municipio_clte.Text = tbl_sepomex[0].d_mnpio;
                            txt_estado_clte.Text = tbl_sepomex[0].d_estado;
                        }
                    }
                    catch
                    {
                    }
                    rfv_rs.Enabled = true;
                    rfv_callenum_clte.Enabled = true;
                    rfv_cp_clte.Enabled = true;

                    var i_cltef = (from t_clte in edm_clte.inf_clte
                                   where t_clte.clte_ID == guclte_ID
                                   select new
                                   {
                                       t_clte.clte_ID,
                                       t_clte.cod_clte,
                                       t_clte.razon_social,
                                       t_clte.registro
                                   }).OrderBy(x => x.cod_clte).ToList();

                    gv_clte.DataSource = i_cltef;
                    gv_clte.DataBind();
                    gv_clte.Visible = true;

                    div_clte_f.Visible = true;
                }
            }
            catch
            { }
        }

        protected void gv_clte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_clte.PageIndex = e.NewPageIndex;

            string str_clte = txt_buscar_clte.Text.ToUpper().Trim();

            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_cltef = (from t_clte in data_clte.inf_clte

                                   select new
                                   {
                                       t_clte.clte_ID,
                                       t_clte.cod_clte,
                                       t_clte.razon_social,
                                       t_clte.registro
                                   }).OrderBy(x => x.cod_clte).ToList();

                    gv_clte.DataSource = i_cltef;
                    gv_clte.DataBind();
                    gv_clte.Visible = true;
                }
            }
            else
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte

                                  where str_clte.Contains(t_clte.razon_social)
                                  select new
                                  {
                                      t_clte.clte_ID,
                                      t_clte.cod_clte,
                                      t_clte.razon_social,
                                      t_clte.registro
                                  }).ToList();

                    gv_clte.DataSource = i_clte;
                    gv_clte.DataBind();
                    gv_clte.Visible = true;
                }
            }
        }

        protected void ddl_clte_estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ddl;

            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList duty = (DropDownList)gvr.FindControl("ddl_clte_estatus");
            str_ddl = int.Parse(duty.SelectedItem.Value);

            if (str_ddl == 2 || str_ddl == 3)
            {
                txt_clte_coment.Enabled = true;
                rfv_clte_coment.Enabled = true;
            }
            else if (str_ddl == 1)
            {
                txt_clte_coment.Text = null;
                txt_clte_coment.Enabled = false;
                rfv_clte_coment.Enabled = false;
            }
            else
            {
                txt_clte_coment.Enabled = false;
                rfv_clte_coment.Enabled = false;
            }
        }

        protected void btn_cp_clte_Click(object sender, EventArgs e)
        {
            string str_cp = txt_cp_clte.Text;

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                   where c.d_codigo == str_cp
                                   select c).ToList();

                ddl_colonia_clte.DataSource = tbl_sepomex;
                ddl_colonia_clte.DataTextField = "d_asenta";
                ddl_colonia_clte.DataValueField = "id_asenta_cpcons";
                ddl_colonia_clte.DataBind();

                if (tbl_sepomex.Count == 1)
                {
                    txt_municipio_clte.Text = tbl_sepomex[0].d_mnpio;
                    txt_estado_clte.Text = tbl_sepomex[0].d_estado;
                    rfv_colonia_clte.Enabled = true;
                }
                if (tbl_sepomex.Count > 1)
                {
                    ddl_colonia_clte.Items.Insert(0, new ListItem("Seleccionar", "0"));

                    txt_municipio_clte.Text = tbl_sepomex[0].d_mnpio;
                    txt_estado_clte.Text = tbl_sepomex[0].d_estado;
                    rfv_colonia_clte.Enabled = true;
                }
                else if (tbl_sepomex.Count == 0)
                {
                    ddl_colonia_clte.Items.Clear();
                    ddl_colonia_clte.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    txt_municipio_clte.Text = null;
                    txt_estado_clte.Text = null;
                    rfv_colonia_clte.Enabled = false;
                }
            }
            up_clte.Update();

            ddl_colonia_clte.Focus();
        }

        protected void btn_guardar_clte_Click(object sender, EventArgs e)
        {
            if (int_clte == 0)
            {
                Mensaje("Favor de Seleccionar una acción");
            }
            else if (int_clte == 1)
            {
                guarda_clte();
            }
            else if (int_clte == 2)
            {
                edita_cliente();
            }
        }

        private void limp_clte_ctrl()
        {
            ddl_trfc_clte_fisc.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_tipo_rfc
                                   select c).ToList();

                ddl_trfc_clte_fisc.DataSource = tbl_sepomex;
                ddl_trfc_clte_fisc.DataTextField = "tipo_rfc_desc";
                ddl_trfc_clte_fisc.DataValueField = "tipo_rfc_ID";
                ddl_trfc_clte_fisc.DataBind();
            }
            ddl_trfc_clte_fisc.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddl_colonia_clte.Items.Clear();
            ddl_colonia_clte.Items.Insert(0, new ListItem("Seleccionar", "0"));
            txt_rfc_clte_fisc.Text = null;
            txt_rs.Text = null;
            txt_telefono_clte.Text = null;
            txt_email_clte.Text = null;
            txt_callenum_clte.Text = null;
            txt_cp_clte.Text = null;
            txt_clte_coment.Text = null;
            txt_municipio_clte.Text = null;
            txt_estado_clte.Text = null;
        }

        private void guarda_clte()
        {
            string str_cod_clte, str_rfc, str_razon_social, str_telefono, str_email, str_callenum, str_cp, int_colony;
            int int_trfc;

            int_trfc = int.Parse(ddl_trfc_clte_fisc.SelectedValue);
            str_rfc = txt_rfc_clte_fisc.Text.Trim().ToUpper();
            str_razon_social = txt_rs.Text.ToUpper().Trim();
            str_telefono = txt_telefono_clte.Text;
            str_email = txt_email_clte.Text.Trim();
            str_callenum = txt_callenum_clte.Text.ToUpper().Trim();
            str_cp = txt_cp_clte.Text;
            int_colony = ddl_colonia_clte.SelectedValue.ToString();

            using (bd_labEntities edm_nclte = new bd_labEntities())
            {
                var i_nclte = (from c in edm_nclte.inf_clte
                               where c.razon_social.Contains(str_razon_social)
                               select c).ToList();

                if (i_nclte.Count == 0)
                {
                    using (bd_labEntities edm_fclte = new bd_labEntities())
                    {
                        var i_fclte = (from c in edm_fclte.inf_clte
                                       select c).ToList();

                        if (i_fclte.Count == 0)
                        {
                            str_cod_clte = "LIEC-CLTE" + string.Format("{0:000}", (object)(i_nclte.Count + 1));

                            using (var m_clte = new bd_labEntities())
                            {
                                var i_clte = new inf_clte

                                {
                                    clte_ID = Guid.NewGuid(),
                                    est_clte_ID = 1,
                                    tipo_rfc_ID = int_trfc,
                                    rfc = str_rfc,
                                    cod_clte = str_cod_clte,
                                    razon_social = str_razon_social,
                                    telefono = str_telefono,
                                    email = str_email,
                                    callenum = str_callenum,
                                    d_codigo = str_cp,
                                    id_asenta_cpcons = int_colony,
                                    registro = DateTime.Now,
                                    empresa_ID = guid_emp,
                                    usuario_ID = guid_idusr
                                };

                                m_clte.inf_clte.Add(i_clte);
                                m_clte.SaveChanges();
                            }
                            rfv_colonia_clte.Enabled = false;
                            limp_clte_ctrl();
                            Mensaje("Datos de cliente agregados con éxito.");
                        }
                        else
                        {
                            str_cod_clte = "LIEC-CLTE" + string.Format("{0:000}", (object)(i_fclte.Count + 1));

                            using (var m_clte = new bd_labEntities())
                            {
                                var i_clte = new inf_clte

                                {
                                    clte_ID = Guid.NewGuid(),
                                    est_clte_ID = 1,
                                    tipo_rfc_ID = int_trfc,
                                    rfc = str_rfc,
                                    cod_clte = str_cod_clte,
                                    razon_social = str_razon_social,
                                    telefono = str_telefono,
                                    email = str_email,
                                    callenum = str_callenum,
                                    d_codigo = str_cp,
                                    id_asenta_cpcons = int_colony,
                                    registro = DateTime.Now,
                                    empresa_ID = guid_emp,
                                    usuario_ID = guid_idusr
                                };

                                m_clte.inf_clte.Add(i_clte);
                                m_clte.SaveChanges();
                            }
                            rfv_colonia_clte.Enabled = false;
                            limp_clte_ctrl();
                            Mensaje("Datos de cliente agregados con éxito.");
                        }
                    }
                }
                else
                {
                    limp_clte_ctrl();
                    rfv_rs.Enabled = false;
                    rfv_callenum_clte.Enabled = false;
                    rfv_cp_clte.Enabled = false;
                    rfv_colonia_clte.Enabled = false;
                    Mensaje("Cliente existe en la base de datos, favor de revisar.");
                }
            }
        }

        private void edita_cliente()
        {
            try
            {
                int int_trfc = int.Parse(ddl_trfc_clte_fisc.SelectedValue);
                string str_rfc = txt_rfc_clte_fisc.Text.Trim().ToUpper();
                string str_razon_social = txt_rs.Text.ToUpper().Trim();
                string str_telefono = txt_telefono_clte.Text;
                string str_email = txt_email_clte.Text.Trim();
                string str_callenum = txt_callenum_clte.Text.ToUpper().Trim();
                string str_cp = txt_cp_clte.Text;
                string str_coment;
                string int_colony = ddl_colonia_clte.SelectedValue.ToString();

                int int_ddl = 0;

                foreach (GridViewRow row in gv_clte.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList dl = (DropDownList)row.FindControl("ddl_clte_estatus");

                        int_ddl = int.Parse(dl.SelectedValue);
                    }
                }

                str_coment = txt_clte_coment.Text;

                using (var m_clte = new bd_labEntities())
                {
                    var i_clte = (from c in m_clte.inf_clte
                                  where c.clte_ID == guclte_ID
                                  select c).FirstOrDefault();

                    i_clte.tipo_rfc_ID = int_trfc;
                    i_clte.rfc = str_rfc;
                    i_clte.est_clte_ID = int_ddl;
                    i_clte.razon_social = str_razon_social;
                    i_clte.telefono = str_telefono;
                    i_clte.email = str_email;
                    i_clte.callenum = str_callenum;
                    i_clte.d_codigo = str_cp;
                    i_clte.id_asenta_cpcons = int_colony;
                    i_clte.comentarios = str_coment;
                    i_clte.usuario_ID = guid_idusr;

                    m_clte.SaveChanges();
                }

                rfv_rs.Enabled = false;
                rfv_callenum_clte.Enabled = false;
                rfv_cp_clte.Enabled = false;
                rfv_colonia_clte.Enabled = false;
                rfv_clte_coment.Enabled = false;

                limp_clte_ctrl();
                div_clte_f.Visible = false;
                Mensaje("Datos de cliente actualizados con éxito.");
            }
            catch
            { }
        }

        #endregion clte

        #region clte_contacto

        protected void btn_buscar_clte_contacto_Click(object sender, EventArgs e)
        {
            div_clte_contactof.Visible = false;
            gv_cltef_cont.Visible = false;

            string str_clte = txt_buscar_clte_contacto.Text.ToUpper().Trim();

            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  select new
                                  {
                                      t_clte.clte_ID,
                                      t_clte.cod_clte,
                                      t_clte.razon_social,
                                      t_clte.registro
                                  }).OrderBy(x => x.cod_clte).ToList();

                    gv_cltef.DataSource = i_clte;
                    gv_cltef.DataBind();
                    gv_cltef.Visible = true;
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_clte_contacto.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_clte
                                       where c.cod_clte == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.clte_ID;

                        var i_cltef = (from t_clte in edm_nclte.inf_clte
                                       where t_clte.clte_ID == guid_usrid
                                       select new
                                       {
                                           t_clte.clte_ID,
                                           t_clte.cod_clte,
                                           t_clte.razon_social,
                                           t_clte.registro
                                       }).OrderBy(x => x.cod_clte).ToList();

                        gv_cltef.DataSource = i_cltef;
                        gv_cltef.DataBind();
                        gv_cltef.Visible = true;

                        if (i_cltef.Count == 0)
                        {
                            gv_cltef.DataSource = i_cltef;
                            gv_cltef.DataBind();
                            gv_cltef.Visible = true;
                            gv_cltef.Visible = true;

                            Mensaje("Empresa no encontrado.");
                        }
                        else
                        {
                            gv_cltef.DataSource = i_cltef;
                            gv_cltef.DataBind();
                            gv_cltef.Visible = true;
                            gv_cltef.Visible = true;
                        }
                    }
                }
                catch
                {
                    //limp_clte_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
        }

        protected void btn_clte_contacto_agregar_Click(object sender, EventArgs e)
        {
            int_clte_cont = 1;

            i_clte_contacto_agregar.Attributes["style"] = "color:#E34C0E";
            i_clte_contacto_editar.Attributes["style"] = "color:white";

            limp_clte_cont_ctrl();
            rfv_clte_contacto_dpto.Enabled = true;
            rfv_clte_contacto.Enabled = true;
            rfv_clte_contacto_tel1.Enabled = true;
            rfv_clte_contacto_email1.Enabled = true;
            gv_cltef_cont.Visible = false;
            div_clte_contactof.Visible = true;
        }

        private void limp_clte_cont_ctrl()
        {
            txt_clte_contacto_dpto.Text = null;
            txt_clte_contacto.Text = null;
            txt_clte_contacto_tel1.Text = null;
            txt_clte_contacto_tel2.Text = null;
            txt_clte_contacto_email1.Text = null;
            txt_clte_contacto_email2.Text = null;
        }

        protected void btn_clte_contacto_editar_Click(object sender, EventArgs e)
        {
            int_clte_cont = 2;

            i_clte_contacto_agregar.Attributes["style"] = "color:white";
            i_clte_contacto_editar.Attributes["style"] = "color:#E34C0E";

            limp_clte_cont_ctrl();
            div_clte_contactof.Visible = false;
        }

        protected void gv_cltef_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  where t_clte.clte_ID == str_clteID
                                  select new
                                  {
                                      t_clte.est_clte_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_clte_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_cltef_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_clte
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "desc_est_clte";
                    DropDownList1.DataValueField = "est_clte_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_cltef_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_cltef.PageIndex = e.NewPageIndex;

            string str_clte = txt_buscar_clte_contacto.Text.ToUpper().Trim();

            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_cltef = (from t_clte in data_clte.inf_clte

                                   select new
                                   {
                                       t_clte.clte_ID,
                                       t_clte.cod_clte,
                                       t_clte.razon_social,
                                       t_clte.registro
                                   }).OrderBy(x => x.cod_clte).ToList();

                    gv_cltef.DataSource = i_cltef;
                    gv_cltef.DataBind();
                    gv_cltef.Visible = true;
                }
            }
            else
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte

                                  where str_clte.Contains(t_clte.razon_social)
                                  select new
                                  {
                                      t_clte.clte_ID,
                                      t_clte.cod_clte,
                                      t_clte.razon_social,
                                      t_clte.registro
                                  }).ToList();

                    gv_cltef.DataSource = i_clte;
                    gv_cltef.DataBind();
                    gv_cltef.Visible = true;
                }
            }
        }

        protected void gv_cltef_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_clte = new bd_labEntities())
                {
                    var i_cltef = (from t_clte in edm_clte.inf_clte
                                   where t_clte.clte_ID == guclte_ID
                                   select new
                                   {
                                       t_clte.clte_ID,
                                       t_clte.cod_clte,
                                       t_clte.razon_social,
                                       t_clte.registro
                                   }).OrderBy(x => x.cod_clte).ToList();

                    gv_cltef.DataSource = i_cltef;
                    gv_cltef.DataBind();
                    gv_cltef.Visible = true;

                    if (int_clte_cont == 1)
                    {
                        div_clte_contactof.Visible = true;
                    }
                    else
                    {
                        div_clte_contactof.Visible = false;
                        var i_cltec = (from t_clte in edm_clte.inf_clte_contacto
                                       where t_clte.clte_ID == guclte_ID
                                       select new
                                       {
                                           t_clte.clte_contacto_ID,
                                           t_clte.dpto,
                                           t_clte.contacto_nom,
                                           t_clte.registro
                                       }).ToList();

                        gv_cltef_cont.DataSource = i_cltec;
                        gv_cltef_cont.DataBind();
                        gv_cltef_cont.Visible = true;
                    }
                }
            }
            catch
            { }
        }

        protected void btn_clte_contacto_guardar_Click(object sender, EventArgs e)
        {
            string str_dpto, str_contacto, str_tel, str_telalt, str_email, str_emailalt;

            str_dpto = txt_clte_contacto_dpto.Text.Trim().ToUpper();
            str_contacto = txt_clte_contacto.Text.Trim().ToUpper();
            str_tel = txt_clte_contacto_tel1.Text;
            str_telalt = txt_clte_contacto_tel2.Text;
            str_email = txt_clte_contacto_email1.Text.Trim().ToLower();
            str_emailalt = txt_clte_contacto_email2.Text.Trim().ToLower();

            if (int_clte_cont == 0)
            {
                Mensaje("Favor de seleccionar una acción.");
            }
            else if (int_clte_cont == 1)
            {
                using (bd_labEntities edm_nclte = new bd_labEntities())
                {
                    var i_nclte = (from c in edm_nclte.inf_clte_contacto
                                   where c.clte_ID == guclte_ID
                                   select c).ToList();

                    if (i_nclte.Count == 0)
                    {
                        var i_clte = new inf_clte_contacto

                        {
                            clte_contacto_ID = Guid.NewGuid(),
                            dpto = str_dpto,
                            contacto_nom = str_contacto,
                            tel1 = str_tel,
                            tel2 = str_telalt,
                            email1 = str_email,
                            email2 = str_emailalt,
                            registro = DateTime.Now,
                            clte_ID = guclte_ID,
                        };

                        edm_nclte.inf_clte_contacto.Add(i_clte);
                        edm_nclte.SaveChanges();

                        limp_clte_cont_ctrl();
                        rfv_clte_contacto_dpto.Enabled = true;
                        rfv_clte_contacto.Enabled = true;
                        rfv_clte_contacto_tel1.Enabled = true;
                        rfv_clte_contacto_email1.Enabled = true;
                        Mensaje("Datos de cliente-contacto agregados con éxito.");
                    }
                    else
                    {
                        var i_ncltef = (from c in edm_nclte.inf_clte_contacto
                                        where c.dpto == str_dpto
                                        where c.contacto_nom == str_contacto
                                        select c).ToList();

                        if (i_ncltef.Count == 0)
                        {
                            var i_cltef = new inf_clte_contacto

                            {
                                clte_contacto_ID = Guid.NewGuid(),
                                dpto = str_dpto,
                                contacto_nom = str_contacto,
                                tel1 = str_tel,
                                tel2 = str_telalt,
                                email1 = str_email,
                                email2 = str_emailalt,
                                registro = DateTime.Now,
                                clte_ID = guclte_ID,
                            };

                            edm_nclte.inf_clte_contacto.Add(i_cltef);
                            edm_nclte.SaveChanges();
                        }
                        else
                        {
                            rfv_clte_contacto_dpto.Enabled = true;
                            rfv_clte_contacto.Enabled = true;
                            rfv_clte_contacto_tel1.Enabled = true;
                            rfv_clte_contacto_email1.Enabled = true;
                            Mensaje("Datos de cliente-contacto ya existe en la base, favor de revisar.");
                        }
                    }
                }
            }
            else if (int_clte_cont == 2)
            {
                using (var m_clte = new bd_labEntities())
                {
                    var i_clte = (from c in m_clte.inf_clte_contacto
                                  where c.clte_contacto_ID == guclte_ID
                                  select c).FirstOrDefault();

                    i_clte.dpto = str_dpto;
                    i_clte.contacto_nom = str_contacto;
                    i_clte.tel1 = str_tel;
                    i_clte.tel2 = str_telalt;
                    i_clte.email1 = str_email;
                    i_clte.email2 = str_emailalt;

                    m_clte.SaveChanges();
                }

                Mensaje("Datos de cliente-contacto actualizados con éxito.");
            }
        }

        protected void chkb_desactivar_clte_contacto_CheckedChanged(object sender, EventArgs e)
        {
            rfv_buscar_clte_contacto.Enabled = false;
            rfv_clte_contacto_dpto.Enabled = false;
            rfv_clte_contacto.Enabled = false;
            rfv_clte_contacto_tel1.Enabled = false;
            rfv_clte_contacto_email1.Enabled = false;
        }

        protected void gv_cltef_cont_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_clte = new bd_labEntities())
                {
                    var i_cltec = (from t_clte in edm_clte.inf_clte_contacto
                                   where t_clte.clte_contacto_ID == guclte_ID
                                   select new
                                   {
                                       t_clte.clte_contacto_ID,
                                       t_clte.dpto,
                                       t_clte.contacto_nom,
                                       t_clte.tel1,
                                       t_clte.tel2,
                                       t_clte.email1,
                                       t_clte.email2,
                                       t_clte.registro
                                   }).ToList();

                    gv_cltef_cont.DataSource = i_cltec;
                    gv_cltef_cont.DataBind();
                    gv_cltef_cont.Visible = true;

                    if (i_cltec.Count == 1)
                    {
                        div_clte_contactof.Visible = true;

                        txt_clte_contacto_dpto.Text = i_cltec[0].dpto;
                        txt_clte_contacto.Text = i_cltec[0].contacto_nom;
                        txt_clte_contacto_tel1.Text = i_cltec[0].tel1;
                        txt_clte_contacto_tel2.Text = i_cltec[0].tel2;
                        txt_clte_contacto_email1.Text = i_cltec[0].email1;
                        txt_clte_contacto_email2.Text = i_cltec[0].email2;
                    }
                    else
                    {
                        div_clte_contactof.Visible = false;
                    }
                }
            }
            catch
            { }
        }

        #endregion clte_contacto

        #region clte_obras

        protected void btn_buscar_clte_obras_Click(object sender, EventArgs e)
        {
            string str_clte = txt_buscar_clte_obras.Text.ToUpper().Trim();
            div_clte_obrasf.Visible = false;
            gv_clte_obrasf.Visible = false;
            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  select new
                                  {
                                      t_clte.clte_ID,
                                      t_clte.cod_clte,
                                      t_clte.razon_social,
                                      t_clte.registro
                                  }).OrderBy(x => x.cod_clte).ToList();

                    gv_clte_obras.DataSource = i_clte;
                    gv_clte_obras.DataBind();
                    gv_clte_obras.Visible = true;
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_clte_obras.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_clte
                                       where c.cod_clte == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.clte_ID;

                        var i_cltef = (from t_clte in edm_nclte.inf_clte
                                       where t_clte.clte_ID == guid_usrid
                                       select new
                                       {
                                           t_clte.clte_ID,
                                           t_clte.cod_clte,
                                           t_clte.razon_social,
                                           t_clte.registro
                                       }).OrderBy(x => x.cod_clte).ToList();

                        gv_clte_obras.DataSource = i_cltef;
                        gv_clte_obras.DataBind();
                        gv_clte_obras.Visible = true;

                        if (i_cltef.Count == 0)
                        {
                            gv_clte_obras.DataSource = i_cltef;
                            gv_clte_obras.DataBind();
                            gv_clte_obras.Visible = true;
                            gv_clte_obras.Visible = true;

                            Mensaje("Empresa no encontrado.");
                        }
                        else
                        {
                            gv_clte_obras.DataSource = i_cltef;
                            gv_clte_obras.DataBind();
                            gv_clte_obras.Visible = true;
                            gv_clte_obras.Visible = true;
                        }
                    }
                }
                catch
                {
                    limp_clte_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
        }

        protected void btn_clte_obras_rpt_Click(object sender, EventArgs e)
        {
            div_clte_obrasf.Visible = false;
            div_clte_obras_rpt.Visible = true;

            using (bd_labEntities edm_clte = new bd_labEntities())
            {
                var i_clte = (from t_clte in edm_clte.inf_clte_obra_rpt
                              where t_clte.clte_obras_ID == guclte_ID
                              select new
                              {
                                  t_clte.clte_obra_rpt_ID,
                                  t_clte.nombre_archivo,
                                  t_clte.registro,
                              }).ToList();

                gv_obras_rpt.DataSource = i_clte;
                gv_obras_rpt.DataBind();
                gv_obras_rpt.Visible = true;
            }
        }

        protected void btn_agregar_clte_obras_Click(object sender, EventArgs e)
        {
            int_clte_obra = 1;

            i_agregar_clte_obras.Attributes["style"] = "color:#E34C0E";
            i_editar_clte_obras.Attributes["style"] = "color:white";

            rfv_clte_clave_obra.Enabled = true;
            rfv_clte_desc_obra.Enabled = true;
            rfv_clte_tservicio.Enabled = true;
            rfv_clte_coordinador.Enabled = true;
            rfv_clte_contobra.Enabled = true;
            gv_clte_obrasf.Visible = false;
            limp_clte_obras_ctrl();
        }

        protected void btn_editar_clte_obras_Click(object sender, EventArgs e)
        {
            int_clte_obra = 2;

            i_agregar_clte_obras.Attributes["style"] = "color:white";
            i_editar_clte_obras.Attributes["style"] = "color:#E34C0E";
            rfv_clte_clave_obra.Enabled = false;
            rfv_clte_desc_obra.Enabled = false;
            rfv_clte_tservicio.Enabled = false;
            rfv_clte_coordinador.Enabled = false;
            rfv_clte_contobra.Enabled = false;
        }

        protected void chkb_desactivar_clte_obras_CheckedChanged(object sender, EventArgs e)
        {
            rfv_buscar_clte_obras.Enabled = false;
            rfv_clte_clave_obra.Enabled = false;
            rfv_clte_desc_obra.Enabled = false;
            rfv_clte_tservicio.Enabled = false;
            rfv_clte_coordinador.Enabled = false;
            rfv_clte_contobra.Enabled = false;
        }

        protected void gv_obras_rpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clteff = (from t_clte in data_clte.inf_clte_obra_rpt
                                    where t_clte.clte_obra_rpt_ID == str_clteID
                                    select new
                                    {
                                        t_clte.est_clte_obra_rpt_ID,
                                    }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clteff.est_clte_obra_rpt_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_clteobrarpt_est") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_clte_obra_rpt
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "est_clte_obra_rpt_desc";
                    DropDownList1.DataValueField = "est_clte_obra_rpt_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_obras_rpt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //gvr.BackColor = Color.FromArgb(227, 76, 14);
            guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

            using (bd_labEntities data_clte = new bd_labEntities())
            {
                var i_clteff = (from t_clte in data_clte.inf_clte_obra_rpt
                                where t_clte.clte_obra_rpt_ID == guclte_ID
                                select new
                                {
                                    t_clte.ruta_archivo
                                }).FirstOrDefault();

                string r_f = i_clteff.ruta_archivo.ToString();

                string d_pdf = r_f;
                iframe_pdf.Visible = true;
                iframe_pdf.Attributes["src"] = d_pdf;

                lblModalTitle.Text = "LIEC";
                Label3.Text = "INF:" + d_pdf;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_pdf", "$('#myModal_pdf').modal();", true);
                up_pdf.Update();
            }
        }

        protected void gv_clte_obras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte
                                  where t_clte.clte_ID == str_clteID
                                  select new
                                  {
                                      t_clte.est_clte_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_clte_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_clteobra_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_clte
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "desc_est_clte";
                    DropDownList1.DataValueField = "est_clte_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_clte_obras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_clte = new bd_labEntities())
                {
                    var i_cltef = (from t_clte in edm_clte.inf_clte
                                   where t_clte.clte_ID == guclte_ID
                                   select new
                                   {
                                       t_clte.clte_ID,
                                       t_clte.cod_clte,
                                       t_clte.razon_social,
                                       t_clte.registro
                                   }).OrderBy(x => x.cod_clte).ToList();

                    gv_clte_obras.DataSource = i_cltef;
                    gv_clte_obras.DataBind();
                    gv_clte_obras.Visible = true;

                    var i_clte = (from t_clte in edm_clte.inf_clte_obras
                                  where t_clte.clte_ID == guclte_ID
                                  select new
                                  {
                                      t_clte.clte_obras_ID,
                                      t_clte.clave_obra,
                                      t_clte.desc_obra,
                                      t_clte.registro
                                  }).ToList();

                    gv_clte_obrasf.DataSource = i_clte;
                    gv_clte_obrasf.DataBind();
                    gv_clte_obrasf.Visible = true;

                    div_clte_obrasf.Visible = false;
                }
            }
            catch
            { }
        }

        protected void ddl_clteobra_estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ddl;

            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList duty = (DropDownList)gvr.FindControl("ddl_clteobra_estatus");
            str_ddl = duty.SelectedItem.Value;

            if (str_ddl == "2")
            {
                txt_coment_obras.Enabled = true;
                rfv_coment_obras.Enabled = true;
            }
            else
            {
                txt_coment_obras.Enabled = false;
                rfv_coment_obras.Enabled = false;
            }
        }

        protected void gv_clte_obras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gv_clte_obrasf_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte_obras
                                  where t_clte.clte_obras_ID == str_clteID
                                  select new
                                  {
                                      t_clte.est_obra_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_obra_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_clteobra_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_obra
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "est_obra_desc";
                    DropDownList1.DataValueField = "est_obra_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_clte_obrasf_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //gvr.BackColor = Color.FromArgb(227, 76, 14);
            guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

            using (bd_labEntities edm_clte = new bd_labEntities())
            {
                var i_clte = (from t_clte in edm_clte.inf_clte_obras
                              where t_clte.clte_obras_ID == guclte_ID
                              select new
                              {
                                  t_clte.clte_obras_ID,
                                  t_clte.clave_obra,
                                  t_clte.desc_obra,
                                  t_clte.registro
                              }).ToList();

                gv_clte_obrasf.DataSource = i_clte;
                gv_clte_obrasf.DataBind();
                gv_clte_obrasf.Visible = true;

                div_clte_obrasf.Visible = true;

                var i_cltef = (from t_clte in edm_clte.inf_clte_obras
                               where t_clte.clte_obras_ID == guclte_ID
                               select new
                               {
                                   t_clte.clave_obra,
                                   t_clte.desc_obra,
                                   t_clte.coordinador,
                                   t_clte.contacto_obra,
                                   t_clte.tipo_servicio_ID,
                                   t_clte.est_obra_ID
                               }).FirstOrDefault();

                txt_clte_clave_obra.Text = i_cltef.clave_obra;
                txt_clte_desc_obra.Text = i_cltef.desc_obra;
                txt_clte_coordinador.Text = i_cltef.coordinador;
                txt_clte_contobra.Text = i_cltef.contacto_obra;
                ddl_clte_tservicio.SelectedValue = i_cltef.tipo_servicio_ID.ToString();
            }
        }

        private void limp_clte_obras_ctrl()
        {
            ddl_clte_tservicio.Items.Clear();
            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_tipo_servicio

                                   select c).ToList();

                ddl_clte_tservicio.DataSource = tbl_sepomex;
                ddl_clte_tservicio.DataTextField = "tipo_servicio_desc";
                ddl_clte_tservicio.DataValueField = "tipo_servicio_ID";
                ddl_clte_tservicio.DataBind();
            }
            ddl_clte_tservicio.Items.Insert(0, new ListItem("Seleccionar", "0"));

            txt_clte_clave_obra.Text = null;
            txt_clte_desc_obra.Text = null;
            txt_clte_coordinador.Text = null;
            txt_clte_contobra.Text = null;
        }

        protected void btn_guardar_clte_obras_Click(object sender, EventArgs e)
        {
            if (int_clte_obra == 0)
            {
                Mensaje("Favor de Seleccionar una acción");
            }
            else if (int_clte_obra == 1)
            {
                guarda_clte_obra();
            }
            else if (int_clte_obra == 2)
            {
                edita_cliente_obra();
            }
        }

        private void edita_cliente_obra()
        {
            string str_clteobra, str_claveobra, str_descobra, str_coordinador, str_contobra, str_coment;
            int int_tservicio;

            Char char_s = '|';
            int startIndex = txt_buscar_clte_obras.Text.Trim().IndexOf(char_s);
            int endIndex = txt_buscar_clte_obras.Text.Trim().Length;
            int length = endIndex - startIndex;
            str_clteobra = txt_buscar_clte_obras.Text.Substring(startIndex, length).Replace("|", "").Trim();
            str_claveobra = txt_clte_clave_obra.Text.Trim().ToUpper();
            str_descobra = txt_clte_desc_obra.Text.Trim().ToUpper();
            int_tservicio = int.Parse(ddl_clte_tservicio.SelectedValue);
            str_coordinador = txt_clte_coordinador.Text.Trim().ToUpper();
            str_contobra = txt_clte_contobra.Text.Trim().ToUpper();
            str_coment = txt_coment_obras.Text.Trim().ToUpper();

            if (int_clte_obra == 0)
            {
                Mensaje("Favor de Seleccionar una acción");
            }
            else
            {
                try
                {
                    int int_ddl = 0;

                    foreach (GridViewRow row in gv_clte_obras.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            DropDownList dl = (DropDownList)row.FindControl("ddl_clteobra_estatus");

                            int_ddl = int.Parse(dl.SelectedValue);
                        }
                    }

                    str_coment = txt_clte_coment.Text;

                    using (var m_clte = new bd_labEntities())
                    {
                        var i_clte = (from c in m_clte.inf_clte_obras
                                      where c.clave_obra == str_claveobra
                                      select c).FirstOrDefault();

                        i_clte.est_obra_ID = int_ddl;
                        i_clte.desc_obra = str_descobra;
                        i_clte.coordinador = str_coordinador;
                        i_clte.contacto_obra = str_contobra;
                        i_clte.tipo_servicio_ID = int_tservicio;
                        i_clte.comentarios = str_coment;

                        m_clte.SaveChanges();
                    }

                    rfv_clte_clave_obra.Enabled = false;
                    rfv_clte_desc_obra.Enabled = false;
                    rfv_clte_tservicio.Enabled = false;
                    rfv_clte_coordinador.Enabled = false;
                    rfv_clte_contobra.Enabled = false;
                    limp_clte_obras_ctrl();
                    gv_clte_obras.Visible = false;
                    Mensaje("Datos de cliente-obra actualizados con éxito.");
                }
                catch
                {
                    Mensaje("Sin registro, favor de revisar.");
                    limp_clte_obras_ctrl();
                    gv_clte.Visible = false;
                }
            }
        }

        private void guarda_clte_obra()
        {
            string str_claveobra, str_descobra, str_coordinador, str_contobra, str_coment;
            int int_tservicio;

            str_claveobra = txt_clte_clave_obra.Text.Trim().ToUpper();
            str_descobra = txt_clte_desc_obra.Text.Trim().ToUpper();
            int_tservicio = int.Parse(ddl_clte_tservicio.SelectedValue);
            str_coordinador = txt_clte_coordinador.Text.Trim().ToUpper();
            str_contobra = txt_clte_contobra.Text.Trim().ToUpper();
            str_coment = txt_coment_obras.Text.Trim().ToUpper();

            using (bd_labEntities edm_nclte = new bd_labEntities())
            {
                var i_nclte = (from c in edm_nclte.inf_clte_obras
                               where c.clave_obra == str_claveobra
                               select c).ToList();

                if (i_nclte.Count == 0)
                {
                    using (var m_clte = new bd_labEntities())
                    {
                        var i_clte = new inf_clte_obras

                        {
                            clte_obras_ID = Guid.NewGuid(),
                            est_obra_ID = 1,
                            clave_obra = str_claveobra,
                            desc_obra = str_descobra,
                            coordinador = str_coordinador,
                            contacto_obra = str_contobra,
                            tipo_servicio_ID = int_tservicio,
                            registro = DateTime.Now,
                            clte_ID = guclte_ID,
                            usuario_ID = guid_idusr
                        };

                        m_clte.inf_clte_obras.Add(i_clte);
                        m_clte.SaveChanges();
                    }

                    limp_clte_obras_ctrl();

                    rfv_clte_clave_obra.Enabled = false;
                    rfv_clte_desc_obra.Enabled = false;
                    rfv_clte_tservicio.Enabled = false;
                    rfv_clte_coordinador.Enabled = false;
                    rfv_clte_contobra.Enabled = false;
                    limp_clte_obras_ctrl();
                    gv_clte_obras.Visible = false;
                    gv_clte_obrasf.Visible = false;
                    div_clte_obrasf.Visible = false;
                    Mensaje("Datos de cliente-obra agregados con éxito.");
                }
                else
                {
                    //limp_txt_clte();
                    rfv_rs.Enabled = false;
                    rfv_callenum_clte.Enabled = false;
                    rfv_cp_clte.Enabled = false;
                    rfv_colonia_clte.Enabled = false;
                    limp_clte_obras_ctrl();
                    gv_clte_obras.Visible = false;
                    gv_clte_obrasf.Visible = false;
                    div_clte_obrasf.Visible = false;
                    Mensaje("Obra existe en la base de datos, favor de revisar.");
                }
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            string str_filename, str_field;

            str_filename = e.FileName;

            using (bd_labEntities edm_nclte = new bd_labEntities())
            {
                var i_nclte = (from c in edm_nclte.inf_clte_obras
                               join i_up in edm_nclte.inf_clte on c.clte_ID equals i_up.clte_ID
                               where c.clte_obras_ID == guclte_ID
                               select new
                               {
                                   i_up.cod_clte,
                                   c.clave_obra
                               }).FirstOrDefault();

                string dir_clte = Server.MapPath("~/pdf/") + i_nclte.cod_clte;
                string dir_obra = Server.MapPath("~/pdf/") + i_nclte.cod_clte + "\\" + i_nclte.clave_obra;
                string dir_cltef = "\\pdf\\" + i_nclte.cod_clte;
                string dir_obraf = "\\pdf\\" + i_nclte.cod_clte + "\\" + i_nclte.clave_obra;
                string guarda_pdf = dir_obra + "\\" + e.FileName;
                string guarda_pdf_alt = dir_obraf + "\\" + e.FileName;

                var items_user = new inf_clte_obra_rpt
                {
                    clte_obra_rpt_ID = Guid.NewGuid(),
                    est_clte_obra_rpt_ID = 2,
                    nombre_archivo = str_filename,
                    ruta_archivo = guarda_pdf_alt,
                    registro = DateTime.Now,
                    usuario_ID = guid_idusr,
                    clte_obras_ID = guclte_ID
                };
                edm_nclte.inf_clte_obra_rpt.Add(items_user);
                edm_nclte.SaveChanges();
                DirectoryInfo d_clte = Directory.CreateDirectory(dir_clte);
                DirectoryInfo d_obra = Directory.CreateDirectory(dir_obra);
                AjaxFileUpload1.SaveAs(guarda_pdf);
            }
        }

        protected void AjaxFileUpload1_UploadCompleteAll(object sender, AjaxFileUploadCompleteAllEventArgs e)
        {
            up_clte_obras.Update();
        }

        protected void AjaxFileUpload1_UploadStart(object sender, AjaxFileUploadStartEventArgs e)
        {
        }

        #endregion clte_obras

        #region rppc

        protected void btn_agregar_rppc_Click(object sender, EventArgs e)
        {
            int_rppc = 1;
            div_rppc.Visible = true;
            div_rpc.Visible = false;
            i_agregar_rppc.Attributes["style"] = "color:#E34C0E";
            i_editar_rppc.Attributes["style"] = "color:white";

            rfv_buscar_rppc.Enabled = true;
            rfv_nmue_rppc.Enabled = true;
            rfv_fcol_rppc.Enabled = true;
            rfv_frec_rppc.Enabled = true;
            rfv_entrega_rppc.Enabled = true;
            rfv_recibe_rppc.Enabled = true;
            rfv_r_rppc.Enabled = true;
            rfv_tesp_rppc.Enabled = true;
            rfv_tconc_rppc.Enabled = true;
            rfv_sit_rppc.Enabled = true;
            gv_rppc.Visible = false;
            limp_txt_rppc();
        }

        protected void chkb_1_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_1_rppc.Checked)
            {
                rfv_f1_rppc.Enabled = true;
                rvf1_rppc.Enabled = true;
                dt_fcol = dt_fechacolado;
                txt_f1_rppc.Text = dt_fcol.AddDays(1).ToString("yyyy-MM-dd");
                up_rppc.Update();
            }
            else
            {
                rfv_f1_rppc.Enabled = false;
                rvf1_rppc.Enabled = false;
                chkb_1_rppc.Checked = false;
                txt_f1_rppc.Text = null;
                txt_cant1_rppc.Text = null;
            }
        }

        protected void chkb_3_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_3_rppc.Checked)
            {
                rfv_f3_rppc.Enabled = true;
                rvf3_rppc.Enabled = true;
                dt_fcol = dt_fechacolado;
                txt_f3_rppc.Text = dt_fcol.AddDays(3).ToString("yyyy-MM-dd");
            }
            else
            {
                rfv_f3_rppc.Enabled = false;
                rvf3_rppc.Enabled = false;
                chkb_3_rppc.Checked = false;
                txt_f3_rppc.Text = null;
                txt_cant3_rppc.Text = null;
            }
        }

        protected void chkb_7_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_7_rppc.Checked)
            {
                rfv_f7_rppc.Enabled = true;
                rvf7_rppc.Enabled = true;
                dt_fcol = dt_fechacolado;
                txt_f7_rppc.Text = dt_fcol.AddDays(7).ToString("yyyy-MM-dd");
            }
            else
            {
                rfv_f7_rppc.Enabled = false;
                rvf7_rppc.Enabled = false;
                chkb_7_rppc.Checked = false;
                txt_f7_rppc.Text = null;
                txt_cant7_rppc.Text = null;
            }
        }

        protected void chkb_14_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_14_rppc.Checked)
            {
                rfv_f14_rppc.Enabled = true;
                rvf14_rppc.Enabled = true;
                dt_fcol = dt_fechacolado;
                txt_f14_rppc.Text = dt_fcol.AddDays(14).ToString("yyyy-MM-dd");
            }
            else
            {
                rfv_f14_rppc.Enabled = false;
                rvf14_rppc.Enabled = false;
                chkb_14_rppc.Checked = false;
                txt_f14_rppc.Text = null;
                txt_cant14_rppc.Text = null;
            }
        }

        protected void gv_obra_clte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

            if (e.CommandName == "btn_recepcion")
            {
                if (int_rppc == 0)
                {
                    div_docf.Visible = false;
                    Mensaje("Favor de seleccionar una acción");
                }
                else if (int_rppc == 1)
                {
                    div_docf.Visible = true;
                    btn_guardar_rppc.Visible = true;
                }
                else if (int_rppc == 2)
                {
                    div_rpc.Visible = true;
                    btn_guardar_rppc.Visible = true;
                    div_docf.Visible = true;
                }
            }

            //try
            //{
            //

            //    using (bd_labEntities edm_clte = new bd_labEntities())
            //    {
            //        var i_clte = (from t_clte in edm_clte.inf_clte
            //                      where t_clte.clte_ID == guclte_ID
            //                      select new
            //                      {
            //                          t_clte.tipo_rfc_ID,
            //                          t_clte.rfc,
            //                          t_clte.razon_social,
            //                          t_clte.telefono,
            //                          t_clte.email,
            //                          t_clte.callenum,
            //                          t_clte.d_codigo,
            //                          t_clte.id_asenta_cpcons,
            //                          t_clte.comentarios
            //                      }).FirstOrDefault();

            //        ddl_trfc_clte_fisc.SelectedValue = i_clte.tipo_rfc_ID.ToString();
            //        txt_rfc_clte_fisc.Text = i_clte.rfc;
            //        txt_rs.Text = i_clte.razon_social;
            //        txt_telefono_clte.Text = i_clte.telefono;
            //        txt_email_clte.Text = i_clte.email;
            //        txt_callenum_clte.Text = i_clte.callenum;
            //        txt_cp_clte.Text = i_clte.d_codigo;
            //        txt_clte_coment.Text = i_clte.comentarios;

            //        try
            //        {
            //            int int_col = int.Parse(i_clte.id_asenta_cpcons.ToString());

            //            using (bd_labEntities db_sepomex = new bd_labEntities())
            //            {
            //                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
            //                                   where c.id_asenta_cpcons == int_col
            //                                   where c.d_codigo == i_clte.d_codigo
            //                                   select c).ToList();

            //                ddl_colonia_clte.DataSource = tbl_sepomex;
            //                ddl_colonia_clte.DataTextField = "d_asenta";
            //                ddl_colonia_clte.DataValueField = "id_asenta_cpcons";
            //                ddl_colonia_clte.DataBind();

            //                txt_municipio_clte.Text = tbl_sepomex[0].d_mnpio;
            //                txt_estado_clte.Text = tbl_sepomex[0].d_estado;
            //            }
            //        }
            //        catch
            //        {
            //        }
            //        rfv_rs.Enabled = true;
            //        rfv_callenum_clte.Enabled = true;
            //        rfv_cp_clte.Enabled = true;

            //        var i_cltef = (from t_clte in edm_clte.inf_clte
            //                       where t_clte.clte_ID == guclte_ID
            //                       select new
            //                       {
            //                           t_clte.clte_ID,
            //                           t_clte.cod_clte,
            //                           t_clte.razon_social,
            //                           t_clte.registro
            //                       }).OrderBy(x => x.cod_clte).ToList();

            //        gv_clte.DataSource = i_cltef;
            //        gv_clte.DataBind();
            //        gv_clte.Visible = true;

            //        div_clte_f.Visible = true;
            //    }
            //}
            //catch
            //{ }
        }

        protected void chkb_28_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_28_rppc.Checked)
            {
                rfv_f28_rppc.Enabled = true;
                rvf28_rppc.Enabled = true;
                dt_fcol = dt_fechacolado;
                txt_f28_rppc.Text = dt_fcol.AddDays(28).ToString("yyyy-MM-dd");
            }
            else
            {
                rfv_f28_rppc.Enabled = false;
                rvf28_rppc.Enabled = false;
                chkb_28_rppc.Checked = false;
                txt_f28_rppc.Text = null;
                txt_cant28_rppc.Text = null;
            }
        }

        protected void chkb_otro_rppc_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt_fcol;

            if (chkb_otro_rppc.Checked)
            {
                if (string.IsNullOrEmpty(txt_cantotro_rppc.Text))
                {
                    Mensaje("Favor de escribir cantidas de dias");
                    chkb_otro_rppc.Checked = false;
                    rfv_cantesp_rppc.Enabled = true;
                    rfv_cantotro_rppc.Enabled = true;
                    rvfotro_rppc.Enabled = true;
                    txt_cantotro_rppc.Focus();
                }
                else
                {
                    rfv_cantesp_rppc.Enabled = true;
                    rfv_cantotro_rppc.Enabled = true;
                    rvfotro_rppc.Enabled = true;
                    dt_fcol = dt_fechacolado;
                    int int_fotro_rppc = int.Parse(txt_cantotro_rppc.Text);
                    txt_fotro_rppc.Text = dt_fcol.AddDays(int_fotro_rppc).ToString("yyyy-MM-dd");
                }
            }
            else
            {
                rfv_cantesp_rppc.Enabled = false;
                rfv_cantotro_rppc.Enabled = false;
                rvfotro_rppc.Enabled = false;
                chkb_otro_rppc.Checked = false;
                txt_cantotro_rppc.Text = null;
                txt_cantesp_rppc.Text = null;
                txt_fotro_rppc.Text = null;
            }
        }

        protected void gv_rppc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str_clteobraID = e.Row.Cells[1].Text;
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_rpc
                                  where t_clte.concreto_est_muestra == str_clteobraID
                                  select new
                                  {
                                      t_clte.concreto_est_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.concreto_est_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_rppc_est") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_concreto_est
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "concreto_est_desc";
                    DropDownList1.DataValueField = "concreto_est_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void chk_rppc_CheckedChanged(object sender, EventArgs e)
        {
            string str_num_muest = null;
            Guid int_clteobra;
            int int_act = 0;

            foreach (GridViewRow row in gv_rppc.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_rppc") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int_act = int_act + 1;
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }

            if (int_act == 0)
            {
                limp_txt_rppc();
            }
            else
            {
                foreach (GridViewRow row in gv_rppc.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk_rppc") as CheckBox);
                        if (chkRow.Checked)
                        {
                            int_act = int_act + 1;
                            limp_txt_rppc();
                            row.BackColor = Color.FromArgb(227, 76, 14);
                            str_num_muest = row.Cells[1].Text;
                        }
                        else
                        {
                            row.BackColor = Color.White;
                        }
                    }
                }
                try
                {
                    using (bd_labEntities edm_clte = new bd_labEntities())
                    {
                        var i_clte = (from c in edm_clte.inf_rpc
                                      where c.concreto_est_muestra == str_num_muest
                                      select c).FirstOrDefault();

                        int_clteobra = i_clte.concreto_rpc_ID;
                    }

                    //using (bd_labEntities edm_clte = new bd_labEntities())
                    //{
                    //    var i_clte = (from t_clte in edm_clte.v_pfe
                    //                  where t_clte.id_mrp_concreto == int_clteobra

                    //                  select new
                    //                  {
                    //                      t_clte.no_muesra,
                    //                      t_clte.fecha_colado,
                    //                      t_clte.fecha_recibe,
                    //                      t_clte.recibe,
                    //                      t_clte.entrega,
                    //                      t_clte.presion,
                    //                      t_clte.id_tipo_especimen,
                    //                      t_clte.id_tipo_concreto,
                    //                      t_clte.id_sit_concreto,
                    //                      t_clte.procedecia,
                    //                      t_clte.elemento,
                    //                      t_clte.dosificacion,
                    //                      t_clte.resistencia,
                    //                      t_clte.clase,
                    //                      t_clte.reva,
                    //                      t_clte.tma,
                    //                      t_clte.olla,
                    //                      t_clte.remision,
                    //                      t_clte.sali_planta,
                    //                      t_clte.llega_obra,
                    //                      t_clte.desca_ini,
                    //                      t_clte.desca_term,
                    //                      t_clte.vol,
                    //                      t_clte.revb,
                    //                      t_clte.localiza,
                    //                      t_clte.dia_ensaye,
                    //                      t_clte.n_m,
                    //                      t_clte.fecha_ensaye
                    //                  }).ToList();
                    //    DateTime f_colad = Convert.ToDateTime(i_clte[0].fecha_colado);
                    //    DateTime f_recib = Convert.ToDateTime(i_clte[0].fecha_recibe);
                    //    TimeSpan? ts_splanta, ts_llobra, ts_ini, s_term;

                    //    ddl_tesp_rppc.SelectedValue = i_clte[0].id_tipo_especimen.ToString();
                    //    ddl_tconc_rppc.SelectedValue = i_clte[0].id_tipo_concreto.ToString();
                    //    ddl_sit_rppc.SelectedValue = i_clte[0].id_sit_concreto.ToString();

                    //    int int_sit = int.Parse(i_clte[0].id_sit_concreto.ToString());
                    //    if (int_sit == 3)
                    //    {
                    //        div_doc.Visible = true;
                    //        txt_proce_rppc.Text = i_clte[0].procedecia;
                    //        txt_elem_rppc.Text = i_clte[0].elemento;
                    //        txt_dosi_rppc.Text = i_clte[0].dosificacion;
                    //        txt_resis_rppc.Text = i_clte[0].resistencia;
                    //        txt_olla_rrpc.Text = i_clte[0].olla;
                    //        txt_remi_rppc.Text = i_clte[0].remision;
                    //        txt_loca_rppc.Text = i_clte[0].localiza;
                    //        txt_clase_rppc.Text = Convert.ToInt32(i_clte[0].clase).ToString();
                    //        txt_rev_rrpc.Text = Math.Round(Convert.ToDecimal(i_clte[0].reva), 2).ToString();
                    //        txt_tma_rrpc.Text = Math.Round(Convert.ToDecimal(i_clte[0].tma), 2).ToString();
                    //        txt_vol_rppc.Text = Math.Round(Convert.ToDecimal(i_clte[0].vol), 2).ToString();
                    //        ts_splanta = i_clte[0].sali_planta;
                    //        ts_llobra = i_clte[0].llega_obra;
                    //        ts_ini = i_clte[0].desca_ini;
                    //        s_term = i_clte[0].desca_term;
                    //        txt_revb_rppc.Text = Math.Round(Convert.ToDecimal(i_clte[0].revb), 2).ToString();
                    //        txt_splata_rrpc.Text = ts_splanta.ToString();
                    //        txt_llobra_rrpc.Text = ts_llobra.ToString();
                    //        txt_inic_rrpc.Text = ts_ini.ToString();
                    //        txt_term_rrpc.Text = s_term.ToString();
                    //    }
                    //    else
                    //    {
                    //        div_doc.Visible = false;
                    //    }

                    //    nmue_rppc.Text = i_clte[0].no_muesra;
                    //    fcol_rppc.Text = f_colad.ToString("yyyy-MM-dd");
                    //    frec_rppc.Text = f_recib.ToString("yyyy-MM-dd");
                    //    entrega_rppc.Text = i_clte[0].entrega;
                    //    recibe_rppc.Text = i_clte[0].recibe;
                    //    r_rppc.Text = i_clte[0].presion.ToString();
                    //    int int_nm = Convert.ToInt32(i_clte[0].n_m);
                    //    foreach (var nn in i_clte)
                    //    {
                    //        if (nn.dia_ensaye == 1)
                    //        {
                    //            chkb_1_rppc.Checked = true;
                    //            txt_cant1_rppc.Text = nn.n_m.ToString();
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_f1_rppc.Text = f_colad.AddDays(1).ToString("yyyy-MM-dd");
                    //        }
                    //        else if (nn.dia_ensaye == 3)
                    //        {
                    //            chkb_3_rppc.Checked = true;
                    //            txt_cant3_rppc.Text = nn.n_m.ToString();
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_f3_rppc.Text = f_colad.AddDays(3).ToString("yyyy-MM-dd");
                    //        }
                    //        else if (nn.dia_ensaye == 7)
                    //        {
                    //            chkb_7_rppc.Checked = true;
                    //            txt_cant7_rppc.Text = nn.n_m.ToString();
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_f7_rppc.Text = f_colad.AddDays(7).ToString("yyyy-MM-dd");
                    //        }
                    //        else if (nn.dia_ensaye == 14)
                    //        {
                    //            chkb_14_rppc.Checked = true;
                    //            txt_cant14_rppc.Text = nn.n_m.ToString();
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_f14_rppc.Text = f_colad.AddDays(14).ToString("yyyy-MM-dd");
                    //        }
                    //        else if (nn.dia_ensaye == 28)
                    //        {
                    //            chkb_28_rppc.Checked = true;
                    //            txt_cant28_rppc.Text = nn.n_m.ToString();
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_f28_rppc.Text = f_colad.AddDays(28).ToString("yyyy-MM-dd");
                    //        }
                    //        else if (nn.dia_ensaye == 0)
                    //        {
                    //            chkb_otro_rppc.Checked = true;
                    //            txt_cantotro_rppc.Text = nn.n_m.ToString();
                    //            txt_cantesp_rppc.Text = nn.n_m.ToString();
                    //            int int_fotro_rppc = int.Parse(txt_cantotro_rppc.Text);
                    //            f_colad = DateTime.Parse(fcol_rppc.Text);
                    //            txt_fotro_rppc.Text = f_colad.AddDays(int_fotro_rppc).ToString("yyyy-MM-dd");
                    //        }
                    //    }
                    //}
                }
                catch
                {
                    Mensaje("Sin ensayos, favor de agregar");
                }
            }
        }

        protected void ddl_rppc_est_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btn_buscar_rpc_Click(object sender, EventArgs e)
        {
            gv_rppc.Visible = false;
            limp_txt_rppc();
            try
            {
                string f_rpc = txt_buscar_rpc.Text.Trim();

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_rpc
                                  where t_clte.concreto_est_muestra == f_rpc
                                  select new
                                  {
                                      t_clte.concreto_est_muestra,
                                      t_clte.registro
                                  }).ToList();

                    gv_rppc.DataSource = i_clte;
                    gv_rppc.DataBind();
                    gv_rppc.Visible = true;
                }
            }
            catch
            {
                gv_clte_obras.Visible = false;
            }
        }

        protected void btn_editar_rppc_Click(object sender, EventArgs e)
        {
            int_rppc = 2;
            div_rppc.Visible = true;
            div_rpc.Visible = true;
            i_agregar_rppc.Attributes["style"] = "color:white";
            i_editar_rppc.Attributes["style"] = "color:#E34C0E";
            limp_txt_rppc();
            rfv_buscar_rppc.Enabled = true;
            rfv_nmue_rppc.Enabled = true;
            rfv_fcol_rppc.Enabled = true;
            rfv_frec_rppc.Enabled = true;
            rfv_entrega_rppc.Enabled = true;
            rfv_recibe_rppc.Enabled = true;
            rfv_r_rppc.Enabled = true;
            rfv_tesp_rppc.Enabled = true;
            rfv_tconc_rppc.Enabled = true;
            rfv_sit_rppc.Enabled = true;
            gv_rppc.Visible = false;
        }

        protected void chkb_desactivar_rppc_CheckedChanged(object sender, EventArgs e)
        {
            rfv_buscar_rppc.Enabled = false;
            rfv_nmue_rppc.Enabled = false;
            rfv_fcol_rppc.Enabled = false;
            rfv_frec_rppc.Enabled = false;
            rfv_entrega_rppc.Enabled = false;
            rfv_recibe_rppc.Enabled = false;
            rfv_r_rppc.Enabled = false;
            rfv_tesp_rppc.Enabled = false;
            rfv_tconc_rppc.Enabled = false;
            rfv_sit_rppc.Enabled = false;
            rfv_f1_rppc.Enabled = false;
            rfv_f3_rppc.Enabled = false;
            rfv_f7_rppc.Enabled = false;
            rfv_f14_rppc.Enabled = false;
            rfv_f28_rppc.Enabled = false;
            rfv_cantesp_rppc.Enabled = false;
            rfv_cantotro_rppc.Enabled = false;
            rvfotro_rppc.Enabled = false;

            rfv_proce_rppc.Enabled = false;
            rfv_elem_rppc.Enabled = false;
            rfv_dosi_rppc.Enabled = false;
            rfv_resis_rppc.Enabled = false;
            rfv_clase_rppc.Enabled = false;
            rfv_rev_rrpc.Enabled = false;
            rfv_tma_rrpc.Enabled = false;
            rfv_olla_rrpc.Enabled = false;
            rfv_remi_rppc.Enabled = false;
            rfv_splata_rrpc.Enabled = false;
            rfv_llobra_rrpc.Enabled = false;
            rfvl_inic_rrpc.Enabled = false;
            rfv_term_rrpc.Enabled = false;
            rfv_vol_rppc.Enabled = false;
            rfv_revb_rppc.Enabled = false;
            rfv_loca_rppc.Enabled = false;

            chkb_1_rppc.Checked = false;
            chkb_3_rppc.Checked = false;
            chkb_7_rppc.Checked = false;
            chkb_14_rppc.Checked = false;
            chkb_28_rppc.Checked = false;
            chkb_otro_rppc.Checked = false;
            txt_cant1_rppc.Text = null;
            txt_cant3_rppc.Text = null;
            txt_cant7_rppc.Text = null;
            txt_cant14_rppc.Text = null;
            txt_cant28_rppc.Text = null;
            txt_cantotro_rppc.Text = null;
            txt_f1_rppc.Text = null;
            txt_f3_rppc.Text = null;
            txt_f7_rppc.Text = null;
            txt_f14_rppc.Text = null;
            txt_f28_rppc.Text = null;
            txt_fotro_rppc.Text = null;
        }

        private void limp_txt_rppc()
        {
            ddl_tesp_rppc.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_especimen_tipo
                                   select c).ToList();

                ddl_tesp_rppc.DataSource = tbl_sepomex;
                ddl_tesp_rppc.DataTextField = "especimen_tipo_desc";
                ddl_tesp_rppc.DataValueField = "especimen_tipo_ID";
                ddl_tesp_rppc.DataBind();
            }
            ddl_tesp_rppc.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

            ddl_tconc_rppc.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_concreto_tipo
                                   select c).ToList();

                ddl_tconc_rppc.DataSource = tbl_sepomex;
                ddl_tconc_rppc.DataTextField = "concreto_tipo_desc";
                ddl_tconc_rppc.DataValueField = "concreto_tipo_ID";
                ddl_tconc_rppc.DataBind();
            }
            ddl_tconc_rppc.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

            ddl_sit_rppc.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_concreto_situacion
                                   select c).ToList();

                ddl_sit_rppc.DataSource = tbl_sepomex;
                ddl_sit_rppc.DataTextField = "concreto_situacion_desc";
                ddl_sit_rppc.DataValueField = "concreto_situacion_ID";
                ddl_sit_rppc.DataBind();
            }
            ddl_sit_rppc.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

            nmue_rppc.Text = null;
            fcol_rppc.Text = null;
            frec_rppc.Text = null;
            entrega_rppc.Text = null;
            recibe_rppc.Text = null;
            r_rppc.Text = null;

            chkb_1_rppc.Checked = false;
            chkb_3_rppc.Checked = false;
            chkb_7_rppc.Checked = false;
            chkb_14_rppc.Checked = false;
            chkb_28_rppc.Checked = false;
            chkb_otro_rppc.Checked = false;
            txt_cant1_rppc.Text = null;
            txt_cant3_rppc.Text = null;
            txt_cant7_rppc.Text = null;
            txt_cant14_rppc.Text = null;
            txt_cant28_rppc.Text = null;
            txt_cantotro_rppc.Text = null;
            txt_f1_rppc.Text = null;
            txt_f3_rppc.Text = null;
            txt_f7_rppc.Text = null;
            txt_f14_rppc.Text = null;
            txt_f28_rppc.Text = null;
            txt_fotro_rppc.Text = null;
            txt_cantesp_rppc.Text = null;

            txt_proce_rppc.Text = null;
            txt_elem_rppc.Text = null;
            txt_dosi_rppc.Text = null;
            txt_resis_rppc.Text = null;
            txt_olla_rrpc.Text = null;
            txt_remi_rppc.Text = null;
            txt_loca_rppc.Text = null;
            txt_clase_rppc.Text = null;
            txt_rev_rrpc.Text = null;
            txt_tma_rrpc.Text = null;
            txt_vol_rppc.Text = null;
            txt_revb_rppc.Text = null;
            txt_splata_rrpc.Text = null;
            txt_llobra_rrpc.Text = null;
            txt_inic_rrpc.Text = null;
            txt_term_rrpc.Text = null;
        }

        protected void gv_rppc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            guclte_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());
            string str_dt_fcolado = gvr.Cells[2].Text;
            dt_fechacolado = DateTime.Parse(str_dt_fcolado);

            if (e.CommandName == "btn_recepcion")
            {
                if (int_rppc == 0)
                {
                    div_docf.Visible = false;
                    Mensaje("Favor de seleccionar una acción");
                }
                else if (int_rppc == 1)
                {
                    div_docf.Visible = false;
                    div_pfe.Visible = true;
                    btn_guardar_rppc.Visible = true;
                }
                else if (int_rppc == 2)
                {
                    div_docf.Visible = false;
                    div_pfe.Visible = true;
                    btn_guardar_rppc.Visible = true;
                }
            }
        }

        protected void btn_guardar_rppc_Click(object sender, EventArgs e)
        {
            if (int_rppc == 0)
            {
                Mensaje("Favor de seleccionar una acción");
            }
            else
            {
                //try
                //{
                Guid guis_usr_capt = Guid.Parse("0298DF9A-4DBF-4EE5-84F7-1E7E519BE4F9");
                Guid gui_nrppc, int_co;
                string str_nomues_rppc, entr_rppc, recib_rppc, proce_rppc, elem_rppc, dosi_rppc, resi_rppc, olla_rppc, remi_rppc, loca_rppc;
                DateTime fcolado_rrpc, fente_rrpc;
                bool bool_1d, bool_3d, bool_7d, bool_14d, bool_28d, bool_otrod;
                decimal dml_reva_rppc, dml_vol_rppc, dl_revb_rppc;
                TimeSpan dt_splan_rppc, dt_llobra_rppc, dt_desca_ini_rppc, dt_desca_term_rppc;
                int int_tesp_rppc, int_tcont_rrp, int_sit_rppc, presi_rppc, int_1d, int_3d, int_7d, int_14d, int_28d, int_otrod, int_otroe = 0, int_clase, int_tma_rppc;

                gui_nrppc = Guid.NewGuid();
                str_nomues_rppc = nmue_rppc.Text.Trim().ToUpper();
                bool vfc = string.IsNullOrEmpty(fcol_rppc.Text) ? true : false;
                if (vfc == true)
                {
                    fcolado_rrpc = dt_fechacolado;
                    if (chkb_1_rppc.Checked)
                    {
                        bool_1d = true;
                        int_1d = int.Parse(txt_cant1_rppc.Text);
                    }
                    else
                    {
                        bool_1d = false;
                        int_1d = 0;
                    }
                    if (chkb_3_rppc.Checked)
                    {
                        bool_3d = true;
                        int_3d = int.Parse(txt_cant3_rppc.Text);
                    }
                    else
                    {
                        bool_3d = false;
                        int_3d = 0;
                    }
                    if (chkb_7_rppc.Checked)
                    {
                        bool_7d = true;
                        int_7d = int.Parse(txt_cant7_rppc.Text);
                    }
                    else
                    {
                        bool_7d = false;
                        int_7d = 0;
                    }
                    if (chkb_14_rppc.Checked)
                    {
                        bool_14d = true;
                        int_14d = int.Parse(txt_cant14_rppc.Text);
                    }
                    else
                    {
                        bool_14d = false;
                        int_14d = 0;
                    }
                    if (chkb_28_rppc.Checked)
                    {
                        bool_28d = true;
                        int_28d = int.Parse(txt_cant28_rppc.Text);
                    }
                    else
                    {
                        bool_28d = false;
                        int_28d = 0;
                    }
                    if (chkb_otro_rppc.Checked)
                    {
                        bool_otrod = true;
                        int_otrod = int.Parse(txt_cantotro_rppc.Text);
                        int_otroe = int.Parse(txt_cantesp_rppc.Text);
                    }
                    else
                    {
                        bool_otrod = false;
                        int_otrod = 0;
                    }
                    string n_rub;
                    int int_pfe = 0;

                    Guid str_ensaye_esp_ID;
                    int str_ensaye_esp_est_ID, str_clave_ensa_a_uno, str_clave_ensa_a_tres, str_clave_ensa_a_siete, str_clave_ensa_a_catorce, str_clave_ensa_a_veinteocho, str_clave_ensa_a_n;
                    bool str_ensaye_esp_num_a_uno = false, str_ensaye_esp_num_b_uno = false, str_ensaye_esp_num_a_tres, str_ensaye_esp_num_b_tres, str_ensaye_esp_num_a_siete, str_ensaye_esp_num_b_siete, str_ensaye_esp_num_a_catorce, str_ensaye_esp_num_b_catorce, str_ensaye_esp_num_a_veiteocho, str_ensaye_esp_num_b_veiteocho, str_ensaye_esp_num_a_n, str_ensaye_esp_num_b_n;
                    string str_ensaye_esp_cod_a_uno, str_directo_a_uno, str_intensidad_a_uno, str_tipofalla_a_uno, str_ensaye_esp_cod_a_tres, str_directo_a_tres, str_intensidad_a_tres, str_tipofalla_a_tres, str_ensaye_esp_cod_a_siete, str_directo_a_siete, str_intensidad_a_siete, str_tipofalla_a_siete, str_ensaye_esp_cod_a_catorce, str_directo_a_catorce, str_intensidad_a_catorce, str_tipofalla_a_catorce, str_ensaye_esp_cod_a_veiteocho, str_directo_a_veiteocho, str_intensidad_a_veiteocho, str_tipofalla_a_veiteocho, str_ensaye_esp_cod_a_n, str_directo_a_n, str_intensidad_a_n, str_tipofalla_a_n;
                    DateTime str_ensaye_esp_registro_a_uno = DateTime.Now, str_ensaye_esp_registro_a_tres = DateTime.Now, str_ensaye_esp_registro_a_siete, str_ensaye_esp_registro_a_catorce, str_ensaye_esp_registro_a_veiteocho, str_ensaye_esp_registro_a_n, str_ensaye_esp_registro_b_uno = DateTime.Now, str_ensaye_esp_registro_b_tres, str_ensaye_esp_registro_b_siete, str_ensaye_esp_registro_b_catorce, str_ensaye_esp_registro_b_veiteocho, str_ensaye_esp_registro_b_n; 
                    decimal str_masa_a_uno, str_altura_aa_uno, str_altura_ab_uno, str_lados_aa_uno, str_lados_ab_uno, str_presion_a_uno, str_masa_a_tres, str_altura_aa_tres, str_altura_ab_tres, str_lados_aa_tres, str_lados_ab_tres, str_presion_a_tres, str_masa_a_siete, str_altura_aa_siete, str_altura_ab_siete, str_lados_aa_siete, str_lados_ab_siete, str_presion_a_siete, str_masa_a_catorce, str_altura_aa_catorce, str_altura_ab_catorce, str_lados_aa_catorce, str_lados_ab_catorce, str_presion_a_catorce, str_masa_a_veinteocho, str_altura_aa_veinteocho, str_altura_ab_veinteocho, str_lados_aa_veinteocho, str_lados_ab_veinteocho, str_presion_a_veinteocho, str_masa_a_n, str_altura_aa_n, str_altura_ab_n, str_lados_aa_n, str_lados_ab_n, str_presion_a_n;




                    int_pfe = int_1d + int_3d + int_7d + int_14d + int_28d + int_otrod;

                    if (int_1d == 0)
                    {
                    }
                    else if (int_1d == 1)
                    {
                        str_ensaye_esp_num_a_uno = true;
                        str_ensaye_esp_registro_a_uno = dt_fechacolado.AddDays(1);
                    }
                    else if (int_1d == 2)
                    {
                        str_ensaye_esp_num_a_uno = true;
                        str_ensaye_esp_registro_a_uno = dt_fechacolado.AddDays(1);
                        str_ensaye_esp_num_b_uno = true;
                        str_ensaye_esp_registro_b_uno = dt_fechacolado.AddDays(1);
                    }

                    else if (int_7d == 0)
                    {
                    }
                    else if (int_7d == 1)
                    {
                        str_ensaye_esp_num_a_siete = true;
                        str_ensaye_esp_registro_a_siete = dt_fechacolado.AddDays(1);
                    }
                    else if (int_7d == 2)
                    {
                        str_ensaye_esp_num_a_siete = true;
                        str_ensaye_esp_registro_a_siete = dt_fechacolado.AddDays(1);
                        str_ensaye_esp_num_b_siete = true;
                        str_ensaye_esp_registro_b_siete = dt_fechacolado.AddDays(1);
                    }


                    using (var m_clte = new bd_labEntities())
                    {
                        var i_clte = new inf_ensaye_esp

                        {
                            ensaye_esp_ID = Guid.NewGuid(),
                            ensaye_esp_num_a_uno = str_ensaye_esp_num_a_uno,
                            ensaye_esp_registro_a_uno = str_ensaye_esp_registro_a_uno,
                            ensaye_esp_est_ID = 3,
                            clave_ensa_a_uno = 1,
                            masa_a_uno = 1,
                            altura_aa_uno = 1,
                            altura_ab_uno = 1,
                            lados_aa_uno = 1,
                            lados_ab_uno = 1,
                            directo_a_uno = "a",
                            intensidad_a_uno = "a",
                            presion_a_uno = 1,
                            tipofalla_a_uno = "a",
                            ensaye_esp_num_b_uno = str_ensaye_esp_num_b_uno,
                            ensaye_esp_registro_b_uno = str_ensaye_esp_registro_b_uno,
                            clave_ensa_b_uno = 1,
                            masa_b_uno = 1,
                            altura_ba_uno = 1,
                            altura_bb_uno = 1,
                            lados_ba_uno = 1,
                            lados_bb_uno = 1,
                            directo_b_uno = "a",
                            intensidad_b_uno = "a",
                            presion_b_uno = 1,
                            tipofalla_b_uno = "a",
                            clave_ensa_a_tres = 1,
                            masa_a_tres = 1,
                            altura_aa_tres = 1,
                            altura_ab_tres = 1,
                            lados_aa_tres = 1,
                            lados_ab_tres = 1,
                            directo_a_tres = "a",
                            intensidad_a_tres = "a",
                            presion_a_tres = 1,
                            tipofalla_a_tres = "a",
                            clave_ensa_b_tres = 1,
                            masa_b_tres = 1,
                            altura_ba_tres = 1,
                            altura_bb_tres = 1,
                            lados_ba_tres = 1,
                            lados_bb_tres = 1,
                            directo_b_tres = "a",
                            intensidad_b_tres = "a",
                            presion_b_tres = 1,
                            tipofalla_b_tres = "a",
                            ensaye_esp_num_a_siete = str_ensaye_esp_num_a_uno,
                            ensaye_esp_registro_a_siete = str_ensaye_esp_registro_a_uno,
                            clave_ensa_a_siete = 1,
                            masa_a_siete = 1,
                            altura_aa_siete = 1,
                            altura_ab_siete = 1,
                            lados_aa_siete = 1,
                            lados_ab_siete = 1,
                            directo_a_siete = "a",
                            intensidad_a_siete = "a",
                            presion_a_siete = 1,
                            tipofalla_a_siete = "a",
                            ensaye_esp_num_b_siete = str_ensaye_esp_num_b_uno,
                            ensaye_esp_registro_b_siete = str_ensaye_esp_registro_b_uno,
                            clave_ensa_b_siete = 1,
                            masa_b_siete = 1,
                            altura_ba_siete = 1,
                            altura_bb_siete = 1,
                            lados_ba_siete = 1,
                            lados_bb_siete = 1,
                            directo_b_siete = "a",
                            intensidad_b_siete = "a",
                            presion_b_siete = 1,
                            tipofalla_b_siete = "a",
                            clave_ensa_a_catorce = 1,
                            masa_a_catorce = 1,
                            altura_aa_catorce = 1,
                            altura_ab_catorce = 1,
                            lados_aa_catorce = 1,
                            lados_ab_catorce = 1,
                            directo_a_catorce = "a",
                            intensidad_a_catorce = "a",
                            presion_a_catorce = 1,
                            tipofalla_a_catorce = "a",
                            clave_ensa_b_catorce = 1,
                            masa_b_catorce = 1,
                            altura_ba_catorce = 1,
                            altura_bb_catorce = 1,
                            lados_ba_catorce = 1,
                            lados_bb_catorce = 1,
                            directo_b_catorce = "a",
                            intensidad_b_catorce = "a",
                            presion_b_catorce = 1,
                            tipofalla_b_catorce = "a",
                            clave_ensa_a_veiteocho = 1,
                            masa_a_veiteocho = 1,
                            altura_aa_veiteocho = 1,
                            altura_ab_veiteocho = 1,
                            lados_aa_veiteocho = 1,
                            lados_ab_veiteocho = 1,
                            directo_a_veiteocho = "a",
                            intensidad_a_veiteocho = "a",
                            presion_a_veiteocho = 1,
                            tipofalla_a_veiteocho = "a",
                            clave_ensa_b_veiteocho = 1,
                            masa_b_veiteocho = 1,
                            altura_ba_veiteocho = 1,
                            altura_bb_veiteocho = 1,
                            lados_ba_veiteocho = 1,
                            lados_bb_veiteocho = 1,
                            directo_b_veiteocho = "a",
                            intensidad_b_veiteocho = "a",
                            presion_b_veiteocho = 1,
                            tipofalla_b_veiteocho = "a",
                            clave_ensa_a_n = 1,
                            masa_a_n = 1,
                            altura_aa_n = 1,
                            altura_ab_n = 1,
                            lados_aa_n = 1,
                            lados_ab_n = 1,
                            directo_a_n = "a",
                            intensidad_a_n = "a",
                            presion_a_n = 1,
                            tipofalla_a_n = "a",
                            clave_ensa_b_n = 1,
                            masa_b_n = 1,
                            altura_ba_n = 1,
                            altura_bb_n = 1,
                            lados_ba_n = 1,
                            lados_bb_n = 1,
                            directo_b_n = "a",
                            intensidad_b_n = "a",
                            presion_b_n = 1,
                            tipofalla_b_n = "a",
                            registro = DateTime.Now,
                            concreto_rpc_ID = guclte_ID,
                        };

                        m_clte.inf_ensaye_esp.Add(i_clte);
                        m_clte.SaveChanges();
                    }
                }
                else
                {
                    fcolado_rrpc = DateTime.Parse(fcol_rppc.Text);

                    fente_rrpc = DateTime.Parse(frec_rppc.Text);
                    entr_rppc = entrega_rppc.Text.Trim().ToUpper();
                    recib_rppc = recibe_rppc.Text.Trim().ToUpper();
                    presi_rppc = int.Parse(r_rppc.Text);

                    int_tesp_rppc = int.Parse(ddl_tesp_rppc.SelectedValue);
                    int_tcont_rrp = int.Parse(ddl_tconc_rppc.SelectedValue);
                    int_sit_rppc = int.Parse(ddl_sit_rppc.SelectedValue);

                    int int_sit = int.Parse(ddl_sit_rppc.SelectedValue);
                    proce_rppc = null;
                    elem_rppc = null;
                    dosi_rppc = null;
                    resi_rppc = null;
                    olla_rppc = null;
                    remi_rppc = null;
                    loca_rppc = null;
                    int_clase = 0;
                    dml_reva_rppc = 0;
                    int_tma_rppc = 0;
                    dml_vol_rppc = 0;
                    dl_revb_rppc = 0;
                    dt_splan_rppc = TimeSpan.Zero;
                    dt_llobra_rppc = TimeSpan.Zero;
                    dt_desca_ini_rppc = TimeSpan.Zero;
                    dt_desca_term_rppc = TimeSpan.Zero;

                    if (int_sit == 2)
                    {
                        proce_rppc = txt_proce_rppc.Text.Trim().ToUpper();
                        elem_rppc = txt_elem_rppc.Text.Trim().ToUpper();
                        dosi_rppc = txt_dosi_rppc.Text.Trim().ToUpper();
                        resi_rppc = txt_resis_rppc.Text.Trim().ToUpper();
                        olla_rppc = txt_olla_rrpc.Text.Trim().ToUpper();
                        remi_rppc = txt_remi_rppc.Text.Trim().ToUpper();
                        loca_rppc = txt_loca_rppc.Text.Trim().ToUpper();
                        int_clase = int.Parse(txt_clase_rppc.Text.Trim().ToUpper());
                        dml_reva_rppc = decimal.Parse(txt_rev_rrpc.Text.Trim().ToUpper());
                        int_tma_rppc = int.Parse(txt_tma_rrpc.Text.Trim().ToUpper());
                        dml_vol_rppc = decimal.Parse(txt_vol_rppc.Text.Trim().ToUpper());
                        dl_revb_rppc = decimal.Parse(txt_revb_rppc.Text.Trim().ToUpper());
                        dt_splan_rppc = TimeSpan.Parse(txt_splata_rrpc.Text);
                        dt_llobra_rppc = TimeSpan.Parse(txt_llobra_rrpc.Text);
                        dt_desca_ini_rppc = TimeSpan.Parse(txt_inic_rrpc.Text);
                        dt_desca_term_rppc = TimeSpan.Parse(txt_term_rrpc.Text);
                    }

                    if (int_rppc == 1)
                    {
                        using (var m_clte = new bd_labEntities())
                        {
                            var i_clte = new inf_rpc

                            {
                                concreto_rpc_ID = gui_nrppc,
                                concreto_est_ID = 1,
                                concreto_est_muestra = str_nomues_rppc,
                                fecha_colado = fcolado_rrpc,
                                fecha_recibe = fente_rrpc,
                                entrega = entr_rppc,
                                recibe = recib_rppc,
                                presion = presi_rppc,
                                especimen_tipo_ID = int_tesp_rppc,
                                concreto_tipo_ID = int_tcont_rrp,
                                concreto_situacion_ID = int_sit_rppc,
                                procedecia = proce_rppc,
                                elemento = elem_rppc,
                                dosificacion = dosi_rppc,
                                resistencia = resi_rppc,
                                clase = int_clase,
                                reva = dml_reva_rppc,
                                tma = int_tma_rppc,
                                olla = olla_rppc,
                                remision = remi_rppc,
                                salida_planta = dt_splan_rppc,
                                llegada_obra = dt_llobra_rppc,
                                desca_ini = dt_desca_ini_rppc,
                                desca_term = dt_desca_term_rppc,
                                vol = dml_vol_rppc,
                                revb = dl_revb_rppc,
                                localiza = loca_rppc,
                                usuario_ID = guid_idusr,
                                registro = DateTime.Now,
                                clte_obras_ID = guclte_ID
                            };

                            m_clte.inf_rpc.Add(i_clte);
                            m_clte.SaveChanges();
                        }

                        limp_txt_rppc();
                        nmue_rppc.Text = null;
                        gv_rppc.Visible = false;

                        using (bd_labEntities data_clte = new bd_labEntities())
                        {
                            var i_clte = (from t_clte in data_clte.inf_rpc
                                          where t_clte.concreto_rpc_ID == gui_nrppc
                                          select new
                                          {
                                              t_clte.concreto_rpc_ID,
                                              t_clte.concreto_est_muestra,
                                              t_clte.fecha_colado,
                                              t_clte.registro
                                          }).ToList();

                            gv_rppc.DataSource = i_clte;
                            gv_rppc.DataBind();
                            gv_rppc.Visible = true;
                        }

                        div_docf.Visible = false;
                        Mensaje("Datos de cliente-obra-muestra agregados con éxito.");
                    }
                    else if (int_rppc == 2)
                    {
                        //using (var m_clte = new bd_labEntities())
                        //{
                        //    var i_clte = (from c in m_clte.inf_rpc
                        //                  where c.concreto_est_muestra == str_nm
                        //                  select c).FirstOrDefault();

                        //    guid_frppc = i_clte.concreto_rpc_ID;

                        //    i_clte.concreto_est_ID = 1;
                        //    i_clte.concreto_est_muestra = str_nomues_rppc;
                        //    i_clte.fecha_colado = fcolado_rrpc;
                        //    i_clte.fecha_recibe = fente_rrpc;
                        //    i_clte.entrega = entr_rppc;
                        //    i_clte.recibe = recib_rppc;
                        //    i_clte.presion = presi_rppc;
                        //    i_clte.especimen_tipo_ID = int_tesp_rppc;
                        //    i_clte.concreto_tipo_ID = int_tcont_rrp;
                        //    i_clte.concreto_situacion_ID = int_sit_rppc;
                        //    i_clte.procedecia = proce_rppc;
                        //    i_clte.elemento = elem_rppc;
                        //    i_clte.dosificacion = dosi_rppc;
                        //    i_clte.resistencia = resi_rppc;
                        //    i_clte.clase = int_clase;
                        //    i_clte.reva = dml_reva_rppc;
                        //    i_clte.tma = int_tma_rppc;
                        //    i_clte.olla = olla_rppc;
                        //    i_clte.remision = remi_rppc;
                        //    i_clte.salida_planta = dt_splan_rppc;
                        //    i_clte.llegada_obra = dt_llobra_rppc;
                        //    i_clte.desca_ini = dt_desca_ini_rppc;
                        //    i_clte.desca_term = dt_desca_term_rppc;
                        //    i_clte.vol = dml_vol_rppc;
                        //    i_clte.revb = dl_revb_rppc;
                        //    i_clte.localiza = loca_rppc;

                        //    m_clte.SaveChanges();
                        //}
                    }
                }
            }
        }

        protected void btn_buscar_rppc_Click(object sender, EventArgs e)
        {
            Guid guid_cltef;
            string str_clteobra;

            try
            {
                string n_rub;
                Char char_s = '|';
                string d_rub = txt_buscar_rppc.Text.Trim();
                String[] de_rub = d_rub.Trim().Split(char_s);
                n_rub = de_rub[0].Trim();

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_co = (from t_clte in data_clte.inf_clte_obras
                                where t_clte.clave_obra == n_rub
                                select t_clte).FirstOrDefault();

                    guid_cltef = i_co.clte_obras_ID;

                    var i_clte = (from t_co in data_clte.inf_clte_obras
                                  join i_c in data_clte.inf_clte on t_co.clte_ID equals i_c.clte_ID
                                  where t_co.clte_obras_ID == guid_cltef
                                  select new
                                  {
                                      t_co.clte_obras_ID,
                                      t_co.clave_obra,
                                      i_c.razon_social,
                                      i_c.cod_clte,
                                      i_c.registro
                                  }).ToList();

                    gv_obra_clte.DataSource = i_clte;
                    gv_obra_clte.DataBind();
                    gv_obra_clte.Visible = true;
                }
            }
            catch
            {
                gv_clte_obras.Visible = false;
            }
        }

        protected void ddl_sit_rppc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_sit = int.Parse(ddl_sit_rppc.SelectedValue);

            if (int_sit == 2)
            {
                div_doc.Visible = true;
                rfv_proce_rppc.Enabled = true;
                rfv_elem_rppc.Enabled = true;
                rfv_dosi_rppc.Enabled = true;
                rfv_resis_rppc.Enabled = true;
                rfv_clase_rppc.Enabled = true;
                rfv_rev_rrpc.Enabled = true;
                rfv_tma_rrpc.Enabled = true;
                rfv_olla_rrpc.Enabled = true;
                rfv_remi_rppc.Enabled = true;
                rfv_splata_rrpc.Enabled = true;
                rfv_llobra_rrpc.Enabled = true;
                rfvl_inic_rrpc.Enabled = true;
                rfv_term_rrpc.Enabled = true;
                rfv_vol_rppc.Enabled = true;
                rfv_revb_rppc.Enabled = true;
                rfv_loca_rppc.Enabled = true;

                txt_proce_rppc.Focus();
            }
            else
            {
                div_doc.Visible = false;
                rfv_proce_rppc.Enabled = false;
                rfv_elem_rppc.Enabled = false;
                rfv_dosi_rppc.Enabled = false;
                rfv_resis_rppc.Enabled = false;
                rfv_clase_rppc.Enabled = false;
                rfv_rev_rrpc.Enabled = false;
                rfv_tma_rrpc.Enabled = false;
                rfv_olla_rrpc.Enabled = false;
                rfv_remi_rppc.Enabled = false;
                rfv_splata_rrpc.Enabled = false;
                rfv_llobra_rrpc.Enabled = false;
                rfvl_inic_rrpc.Enabled = false;
                rfv_term_rrpc.Enabled = false;
                rfv_vol_rppc.Enabled = false;
                rfv_revb_rppc.Enabled = false;
                rfv_loca_rppc.Enabled = false;
            }
        }

        protected void gv_rppc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Guid guid_cltef;
            gv_rppc.PageIndex = e.NewPageIndex;

            try
            {
                string n_rub;
                Char char_s = '|';
                string d_rub = txt_buscar_rppc.Text.Trim();
                String[] de_rub = d_rub.Trim().Split(char_s);
                n_rub = de_rub[0].Trim();

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_co = (from t_clte in data_clte.inf_clte_obras
                                where t_clte.clave_obra == n_rub
                                select t_clte).FirstOrDefault();

                    guid_cltef = i_co.clte_obras_ID;

                    var i_clte = (from t_clte in data_clte.inf_rpc
                                  where t_clte.clte_obras_ID == guid_cltef
                                  select new
                                  {
                                      t_clte.concreto_est_muestra,
                                      t_clte.registro
                                  }).OrderBy(x => x.concreto_est_muestra).ToList();

                    gv_rppc.DataSource = i_clte;
                    gv_rppc.DataBind();
                    gv_rppc.Visible = true;
                }
            }
            catch
            {
                gv_clte_obras.Visible = false;
            }
        }

        #endregion rppc
    }
}