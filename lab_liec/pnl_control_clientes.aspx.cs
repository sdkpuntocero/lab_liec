using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab_liec
{
    public partial class pnl_control_clientes : System.Web.UI.Page
    {
        public static Guid guid_emp, guclte_ID, guid_idusr;

        static private int acc_rubro, acc_gasto, acc_caja, int_pnlID, int_idperf;
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
                Response.Redirect("acceso_cliente.aspx");
            }
        }

        private void inf_usr_oper()
        {
            guid_idusr = (Guid)(Session["ss_idusr"]);

            using (bd_labEntities m_usuario = new bd_labEntities())
            {
                var i_usuario = (from i_u in m_usuario.inf_clte


                                 where i_u.clte_ID == guid_idusr
                                 select new
                                 {
                                     i_u.razon_social,


                                 }).FirstOrDefault();

                lbl_usr_oper.Text = "Contacto de cliente";
                lbl_tusr.Text = "Cliente";

                lbl_emp_oper.Text = i_usuario.razon_social;

            }
        }

        #region clte_obras

        protected void btn_buscar_clte_obras_Click(object sender, EventArgs e)
        {
            string str_clte = txt_buscar_clte_obras.Text.ToUpper().Trim();

            if (str_clte == "TODO")
            {
                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte_obras
                                  where t_clte.clte_ID == guid_idusr
                                  select new
                                  {
                                      t_clte.clte_obras_ID,
                                      t_clte.clave_obra,
                                      t_clte.desc_obra,
                                      t_clte.registro
                                  }).OrderBy(x => x.clave_obra).ToList();

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

                        var i_cltef = (from t_clte in edm_nclte.inf_clte_obras
                                       where t_clte.clte_ID == guid_usrid
                                       select new
                                       {
                                           t_clte.clte_obras_ID,
                                           t_clte.clave_obra,
                                           t_clte.desc_obra,
                                           t_clte.registro
                                       }).OrderBy(x => x.clave_obra).ToList();

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

                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
            //Guid guclte_IDf;
            //string str_clteobra;

            //limp_clte_obras_ctrl();
            //gv_clte_obras.Visible = false;
            //Char char_s = '|';
            //try
            //{
            //    int startIndex = txt_buscar_clte_obras.Text.Trim().IndexOf(char_s);
            //    int endIndex = txt_buscar_clte_obras.Text.Trim().Length;
            //    int length = endIndex - startIndex;
            //    str_clteobra = txt_buscar_clte_obras.Text.Substring(startIndex, length).Replace("|", "").Trim();

            //    using (bd_labEntities data_clte = new bd_labEntities())
            //    {
            //        var i_clte = (from t_clte in data_clte.inf_clte
            //                      where t_clte.cod_clte == str_clteobra
            //                      select t_clte).FirstOrDefault();

            //        guclte_IDf = i_clte.clte_ID;
            //    }

            //    using (bd_labEntities data_clte = new bd_labEntities())
            //    {
            //        var i_clte = (from t_clte in data_clte.inf_clte_obras
            //                      where t_clte.clte_ID == guclte_IDf
            //                      select new
            //                      {
            //                          t_clte.clave_obra,
            //                          t_clte.desc_obra,
            //                          t_clte.registro
            //                      }).ToList();

            //        gv_clte_obras.DataSource = i_clte;
            //        gv_clte_obras.DataBind();
            //        gv_clte_obras.Visible = true;
            //    }
            //}
            //catch
            //{
            //    gv_clte_obras.Visible = false;
            //}
        }



        private void limp_txt_clte_obras()
        {

        }


        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "LIEC";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void lkb_clte_obras_Click(object sender, EventArgs e)
        {
            pnl_clte_obras.Visible = true;
            up_clte_obras.Update();
        }

        protected void gv_clte_obras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                Guid num_m_id = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());




                using (bd_labEntities data_clte = new bd_labEntities())
                {

                    var i_cltef = (from t_clte in data_clte.inf_clte_obras
                                   where t_clte.clte_obras_ID == num_m_id
                                   select new
                                   {
                                       t_clte.clte_obras_ID,
                                       t_clte.clave_obra,
                                       t_clte.desc_obra,
                                       t_clte.registro
                                   }).OrderBy(x => x.clave_obra).ToList();

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

                    var i_clte = (from t_clte in data_clte.inf_clte_obra_rpt
                                  where t_clte.clte_obras_ID == num_m_id
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
            catch
            { }

        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso_clientes.aspx");
        }

        protected void gv_clte_obras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid str_clteobraID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_clte_obras
                                  where t_clte.clte_obras_ID == str_clteobraID
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
                    DropDownList1.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void chk_clte_obras_CheckedChanged(object sender, EventArgs e)
        {
            string str_clte_obra;
            Guid int_clteobra;

            foreach (GridViewRow row in gv_clte_obras.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_clte_obras") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(227, 76, 14);
                        str_clte_obra = row.Cells[1].Text;

                        using (bd_labEntities edm_clte = new bd_labEntities())
                        {
                            var i_clte = (from c in edm_clte.inf_clte_obras
                                          where c.clave_obra == str_clte_obra
                                          select c).FirstOrDefault();

                            int_clteobra = i_clte.clte_obras_ID;
                        }

                        using (bd_labEntities edm_clte = new bd_labEntities())
                        {
                            var i_clte = (from t_clte in edm_clte.inf_clte_obras
                                          where t_clte.clte_obras_ID == int_clteobra
                                          select new
                                          {
                                              t_clte.clave_obra,
                                              t_clte.desc_obra,
                                              t_clte.coordinador,
                                              t_clte.contacto_obra,
                                              t_clte.tipo_servicio_ID,
                                              t_clte.est_obra_ID
                                          }).FirstOrDefault();

                        }
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }

        protected void ddl_clteobra_estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ddl;

            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList duty = (DropDownList)gvr.FindControl("ddl_clteobra_estatus");
            str_ddl = duty.SelectedItem.Value;

            if (str_ddl == "2")
            {

            }
            else
            {

            }
        }

        protected void chkb_desactivar_clte_obras_CheckedChanged(object sender, EventArgs e)
        {
            rfv_buscar_clte_obras.Enabled = false;

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

        #endregion clte_obras
    }
}