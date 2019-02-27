using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab_liec
{
    public partial class pnl_recursos_humanos : System.Web.UI.Page
    {
        private static int int_usr, int_menu, int_idperf, int_usr_med;
        private static string str_pnlID;
        public static Guid guid_emp = Guid.Parse("D8A03556-6791-45F3-BABE-ECF267B865F1");
        public static Guid guid_idusr, usr_ID;

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

        #region funciones

        [ScriptMethod()]
        [WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            List<String> columnData = new List<String>();
            string str_usr = prefixText.ToUpper();

            if (str_pnlID == "pnl_usr")
            {
                string f_desccajaf = prefixText.ToUpper();

                using (bd_labEntities m_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in m_usr.inf_usuario
                                 join i_up in m_usr.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                 where i_up.nombres.Contains(str_usr)
                                 select new
                                 {
                                     nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                     i_u.cod_usr,
                                 }).ToList();

                    foreach (var ff_usr in i_usr)
                    {
                        columnData.Add(ff_usr.nom_comp + " | " + ff_usr.cod_usr);
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

        private void muestra_pnl(int int_menu)
        {
            switch (int_menu)
            {
                case 1:

                    lkb_usr_admin.Attributes["style"] = "color:#104D8d";

                    lkb_usr_med.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_banc.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_cap.Attributes["style"] = "color:#E34C0E";

                    lkb_salir.Attributes["style"] = "color:#E34C0E";

                    i_usr_agregar.Attributes["style"] = "color:white";
                    i_usr_editar.Attributes["style"] = "color:white";

                    div_busc_usr.Visible = false;
                    chkb_usr_desact.Checked = false;

                    pnl_usrs.Visible = true;
                    div_usr_f.Visible = false;
                    gv_usrs.Visible = false;
                    up_usrs.Update();
                    pnl_usr_med.Visible = false;
                    up_usr_med.Update();

                    break;

                case 2:

                    lkb_usr_admin.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_med.Attributes["style"] = "color:#104D8d";

                    lkb_usr_banc.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_cap.Attributes["style"] = "color:#E34C0E";

                    lkb_salir.Attributes["style"] = "color:#E34C0E";

                    i_usr_med_agregar.Attributes["style"] = "color:white";
                    i_usr_med_editar.Attributes["style"] = "color:white";

                    div_busc_usr_med.Visible = false;
                    chkb_usr_med_desact.Checked = false;

                    pnl_usrs.Visible = false;
                    div_usr_medf.Visible = false;
                    gv_usr_med.Visible = false;
                    up_usrs.Update();
                    pnl_usr_med.Visible = true;
                    up_usr_med.Update();

                    break;

                case 3:

                    lkb_usr_admin.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_med.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_banc.Attributes["style"] = "color:#104D8d";

                    lkb_usr_cap.Attributes["style"] = "color:#E34C0E";

                    lkb_salir.Attributes["style"] = "color:#E34C0E";

                    break;

                case 4:

                    lkb_usr_admin.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_med.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_banc.Attributes["style"] = "color:#E34C0E";

                    lkb_usr_cap.Attributes["style"] = "color:#104D8d";

                    lkb_salir.Attributes["style"] = "color:#E34C0E";

                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^0-9A-Za-z]", "", RegexOptions.None);
        }

        public static string RemoveAccentsWithRegEx(string inputString)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            return inputString;
        }

        #endregion funciones

        #region menu_rh

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

                switch (int_idperf)
                {
                    case 30:

                        lkb_regresar.Visible = false;
                        break;

                    case 39:

                        lkb_regresar.Visible = true;
                        break;
                    default:

                        break;
                }
            }
        }

        protected void lkb_usr_admin_Click(object sender, EventArgs e)
        {
            int_menu = 1;
            int_usr = 0;
            usr_ID = Guid.Empty;

            muestra_pnl(int_menu);
        }

        protected void lkb_usr_med_Click(object sender, EventArgs e)
        {
            int_menu = 2;
            int_usr = 0;
            usr_ID = Guid.Empty;

            muestra_pnl(int_menu);
        }

        protected void lkb_usr_banc_Click(object sender, EventArgs e)
        {
            int_menu = 3;
            int_usr = 0;
            usr_ID = Guid.Empty;

            muestra_pnl(int_menu);
        }

        protected void lkb_usr_cap_Click(object sender, EventArgs e)
        {
            int_menu = 4;
            int_usr = 0;
            usr_ID = Guid.Empty;

            muestra_pnl(int_menu);
        }

        protected void lkb_regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pnl_control.aspx");
        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }

        #endregion menu_rh

        #region control_usuarios

        private void carga_cmb_usr()
        {
            ddl_usr_area.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_area
                                   select c).ToList();

                ddl_usr_area.DataSource = tbl_sepomex;
                ddl_usr_area.DataTextField = "area_desc";
                ddl_usr_area.DataValueField = "area_ID";
                ddl_usr_area.DataBind();
            }
            ddl_usr_area.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddl_usr_perfil.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_perfil
                                   select c).ToList();

                ddl_usr_perfil.DataSource = tbl_sepomex;
                ddl_usr_perfil.DataTextField = "perfil_desc";
                ddl_usr_perfil.DataValueField = "perfil_ID";
                ddl_usr_perfil.DataBind();
            }
            ddl_usr_perfil.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddl_usr_genero.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_genero
                                   select c).ToList();

                ddl_usr_genero.DataSource = tbl_sepomex;
                ddl_usr_genero.DataTextField = "genero_desc";
                ddl_usr_genero.DataValueField = "genero_ID";
                ddl_usr_genero.DataBind();
            }
            ddl_usr_genero.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddl_usr_estciv.Items.Clear();
            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_estcivil
                                   select c).ToList();

                ddl_usr_estciv.DataSource = tbl_sepomex;
                ddl_usr_estciv.DataTextField = "estcivil_desc";
                ddl_usr_estciv.DataValueField = "estcivil_ID";
                ddl_usr_estciv.DataBind();
            }
            ddl_usr_estciv.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddl_usr_col.Items.Clear();
            ddl_usr_col.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddl_usr_responsable.Items.Clear();
            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.inf_usr_personales
                                   select new
                                   {
                                       nom_usr = c.nombres + " " + c.apaterno + " " + c.amaterno,
                                       c.usuario_ID
                                   }).ToList();

                ddl_usr_responsable.DataSource = tbl_sepomex;
                ddl_usr_responsable.DataTextField = "nom_usr";
                ddl_usr_responsable.DataValueField = "usuario_ID";
                ddl_usr_responsable.DataBind();
            }
            ddl_usr_responsable.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void btn_usr_guardar_Click(object sender, EventArgs e)
        {
            if (int_usr == 0)
            {
                Mensaje("Favor de seleccionar una acción.");
            }
            else if (int_usr == 1)
            {
                guardar_usuario();
            }
            else if (int_usr == 2)
            {
                edita_usuario();
            }
            else
            { }
        }

        private void edita_usuario()
        {
            int v_areas, v_perfil, v_genero, v_estadocivil, v_colonia, v_hijos, int_ddl = 0;
            DateTime v_cumpleaños, v_ingreso;
            string v_responsable, v_nombre, v_apellidopaterno, v_apellidomaterno, v_nss, v_curp, v_licencia, v_rfc, v_telefono, v_telefonoalterno, v_correoelectronico, v_correoelectronicoalterno, v_calleynumero, v_codigopostal, v_comentarios, v_usuario, v_contraseña, v_correocorporativo;

            if (usr_ID == Guid.Empty)
            {
                Mensaje("Favor de seleccionar un usuario");
            }
            else
            {
                v_areas = int.Parse(ddl_usr_area.SelectedValue);
                v_perfil = int.Parse(ddl_usr_perfil.SelectedValue);
                v_responsable = ddl_usr_responsable.Text.ToString();
                v_genero = int.Parse(ddl_usr_genero.SelectedValue);
                v_estadocivil = int.Parse(ddl_usr_estciv.SelectedValue);
                v_colonia = int.Parse(ddl_usr_col.SelectedValue);
                v_nombre = txt_usr_nombres.Text.Trim().ToUpper();
                v_apellidopaterno = txt_usr_apaterno.Text.Trim().ToUpper();
                v_apellidomaterno = txt_usr_amaterno.Text.Trim().ToUpper();

                v_cumpleaños = DateTime.Parse(txt_usr_fnac.Text);
                v_ingreso = DateTime.Parse(txt_usr_fing.Text);
                v_hijos = int.Parse(txt_usr_hijos.Text);
                v_nss = txt_usr_nss.Text.Trim().ToUpper();
                v_curp = txt_usr_curp.Text.Trim().ToUpper();
                v_licencia = txt_usr_licencia.Text.Trim().ToUpper();
                v_rfc = txt_usr_rfc.Text.Trim().ToUpper();
                v_telefono = txt_usr_tel.Text;
                v_telefonoalterno = txt_usr_telalt.Text;
                v_correoelectronico = txt_usr_email.Text;
                v_correoelectronicoalterno = txt_usr_emailalt.Text;
                v_calleynumero = txt_usr_callenum.Text.Trim().ToUpper();
                v_codigopostal = txt_usr_cp.Text;
                v_comentarios = txt_usr_coment.Text.Trim().ToUpper();
                v_usuario = txt_usr_cod.Text;
                v_contraseña = txt_usr_clave.Text;
                v_correocorporativo = txt_usr_emailcorp.Text;

                foreach (GridViewRow row in gv_usrs.Rows)
                {
                    // int key = (int)GridView1.DataKeys[row.RowIndex].Value;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList dl = (DropDownList)row.FindControl("ddl_usr_estatus");

                        int_ddl = int.Parse(dl.SelectedValue);
                    }
                }

                using (var m_usrs = new bd_labEntities())
                {
                    var i_usrs_cont = (from c in m_usrs.inf_usr_contacto
                                       where c.usuario_ID == usr_ID
                                       select c).FirstOrDefault();

                    i_usrs_cont.tel = v_telefono;
                    i_usrs_cont.tel_alt = v_telefonoalterno;
                    i_usrs_cont.correo = v_correoelectronico;
                    i_usrs_cont.correo_alt = v_correoelectronicoalterno;
                    i_usrs_cont.callenum = v_calleynumero;
                    i_usrs_cont.d_codigo = v_codigopostal;
                    i_usrs_cont.id_asenta_cpcons = v_colonia;

                    m_usrs.SaveChanges();

                    var i_usrs_rh = (from c in m_usrs.inf_usr_rh
                                     where c.usuario_ID == usr_ID
                                     select c).FirstOrDefault();

                    i_usrs_rh.fecha_ingreso = v_ingreso;
                    i_usrs_rh.area_ID = v_areas;
                    i_usrs_rh.perfil_ID = v_perfil;
                    i_usrs_rh.comentarios = v_comentarios;
                    i_usrs_rh.jefe_inmediato = v_responsable;

                    m_usrs.SaveChanges();

                    var i_usrs_personales = (from c in m_usrs.inf_usr_personales
                                             where c.usuario_ID == usr_ID
                                             select c).FirstOrDefault();

                    i_usrs_personales.nombres = v_nombre;
                    i_usrs_personales.apaterno = v_apellidopaterno;
                    i_usrs_personales.amaterno = v_apellidomaterno;
                    i_usrs_personales.genero_ID = v_genero;
                    i_usrs_personales.estcivil_ID = v_estadocivil;
                    i_usrs_personales.hijos = v_hijos;
                    i_usrs_personales.cumple = v_cumpleaños;
                    i_usrs_personales.licencia = v_licencia;
                    i_usrs_personales.rfc = v_rfc;
                    i_usrs_personales.curp = v_curp;
                    i_usrs_personales.nss = v_nss;

                    m_usrs.SaveChanges();

                    var i_usrs = (from c in m_usrs.inf_usuario
                                  where c.usuario_ID == usr_ID
                                  select c).FirstOrDefault();

                    i_usrs.est_usr_ID = int_ddl;
                    i_usrs.usr = v_usuario;
                    //i_usrs.clave = v_contraseña;
                    i_usrs.correo_corp = v_correocorporativo;
                    m_usrs.SaveChanges();
                }
                Mensaje("Usuario actualizado con exito");
            }
        }

        private void guardar_usuario()
        {
            int v_areas, v_perfil, v_genero, v_estadocivil, v_colonia, v_hijos;
            DateTime v_cumpleaños, v_ingreso;
            string v_responsable, v_nombre, v_apellidopaterno, v_apellidomaterno, v_nombre_l, v_apellidopaterno_l, v_apellidomaterno_l, v_usuariof = null, v_nss, v_curp, v_licencia, v_rfc, v_telefono, v_telefonoalterno, v_correoelectronico, v_correoelectronicoalterno, v_calleynumero, v_codigopostal, v_comentarios, v_usuario, v_contraseña, v_correocorporativo;

            v_areas = int.Parse(ddl_usr_area.SelectedValue);
            v_perfil = int.Parse(ddl_usr_perfil.SelectedValue);
            v_responsable = ddl_usr_responsable.Text.ToString();
            v_genero = int.Parse(ddl_usr_genero.SelectedValue);
            v_estadocivil = int.Parse(ddl_usr_estciv.SelectedValue);
            v_colonia = int.Parse(ddl_usr_col.SelectedValue);
            v_nombre = txt_usr_nombres.Text.Trim().ToUpper();
            v_apellidopaterno = txt_usr_apaterno.Text.Trim().ToUpper();
            v_apellidomaterno = txt_usr_amaterno.Text.Trim().ToUpper();

            v_cumpleaños = DateTime.Parse(txt_usr_fnac.Text);
            v_ingreso = DateTime.Parse(txt_usr_fing.Text);
            v_hijos = int.Parse(txt_usr_hijos.Text);
            v_nss = txt_usr_nss.Text.Trim().ToUpper();
            v_curp = txt_usr_curp.Text.Trim().ToUpper();
            v_licencia = txt_usr_licencia.Text.Trim().ToUpper();
            v_rfc = txt_usr_rfc.Text.Trim().ToUpper();
            v_telefono = txt_usr_tel.Text;
            v_telefonoalterno = txt_usr_telalt.Text;
            v_correoelectronico = txt_usr_email.Text;
            v_correoelectronicoalterno = txt_usr_emailalt.Text;
            v_calleynumero = txt_usr_callenum.Text.Trim().ToUpper();
            v_codigopostal = txt_usr_cp.Text;
            v_comentarios = txt_usr_coment.Text.Trim().ToUpper();
            v_usuario = txt_usr_cod.Text;
            v_contraseña = txt_usr_clave.Text;
            v_correocorporativo = txt_usr_emailcorp.Text;

            try
            {
                v_nombre_l = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_usr_nombres.Text.Trim().ToLower()));
                string[] separados;

                separados = v_nombre.Split(" ".ToCharArray());

                v_apellidopaterno_l = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_usr_apaterno.Text.Trim().ToLower()));
                v_apellidomaterno_l = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_usr_amaterno.Text.Trim().ToLower()));

                v_usuariof = left_right_mid.left(v_nombre_l, 1) + v_apellidopaterno_l;
            }
            catch
            {
                Mensaje("Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.");
            }

            string cod_usr;
            using (bd_labEntities edm_fusr = new bd_labEntities())
            {
                var i_fusr = (from c in edm_fusr.inf_usr_personales
                              where c.nombres == v_nombre
                              where c.apaterno == v_apellidopaterno
                              where c.amaterno == v_apellidomaterno
                              select c).ToList();

                if (i_fusr.Count == 0)
                {
                    var i_usr = (from c in edm_fusr.inf_usuario
                                 select c).ToList();

                    if (i_usr.Count == 0)
                    {
                        cod_usr = "LIEC-USR" + string.Format("{0:000}", (object)(i_usr.Count + 1));
                        Guid guid_usrID = Guid.NewGuid();

                        var a_usr = new inf_usuario
                        {
                            usuario_ID = guid_usrID,
                            est_usr_ID = 1,
                            cod_usr = cod_usr,
                            usr = v_usuariof,
                            clave = encrypta.Encrypt("poc123"),
                            correo_corp = v_usuariof + "@liec.com.mx",
                            empresa_ID = guid_emp,
                            registro = DateTime.Now
                        };
                        var a_usr_pers = new inf_usr_personales
                        {
                            usr_personales_ID = Guid.NewGuid(),
                            nombres = v_nombre,
                            apaterno = v_apellidopaterno,
                            amaterno = v_apellidomaterno,
                            genero_ID = v_genero,
                            estcivil_ID = v_estadocivil,
                            hijos = v_hijos,
                            cumple = v_cumpleaños,
                            licencia = v_licencia,
                            rfc = v_rfc,
                            curp = v_curp,
                            nss = v_nss,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };
                        var a_usr_rh = new inf_usr_rh

                        {
                            usr_rh_ID = Guid.NewGuid(),
                            fecha_ingreso = v_ingreso,
                            area_ID = v_areas,
                            perfil_ID = v_perfil,
                            jefe_inmediato = v_responsable,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };
                        var a_usr_cont = new inf_usr_contacto

                        {
                            usr_contacto_ID = Guid.NewGuid(),
                            tel = v_telefono,
                            tel_alt = v_telefonoalterno,
                            correo = v_correoelectronico,
                            correo_alt = v_correoelectronicoalterno,
                            callenum = v_calleynumero,
                            d_codigo = v_codigopostal,
                            id_asenta_cpcons = v_colonia,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };

                        edm_fusr.inf_usuario.Add(a_usr);
                        edm_fusr.inf_usr_personales.Add(a_usr_pers);
                        edm_fusr.inf_usr_rh.Add(a_usr_rh);
                        edm_fusr.inf_usr_contacto.Add(a_usr_cont);

                        edm_fusr.SaveChanges();

                        limp_usr_ctrl();
                        Mensaje("Datos de usuario agregados con éxito.");
                    }
                    else
                    {
                        cod_usr = "LIEC-USR" + string.Format("{0:000}", (object)(i_usr.Count + 1));
                        Guid guid_usrID = Guid.NewGuid();

                        var a_usr = new inf_usuario
                        {
                            usuario_ID = guid_usrID,
                            est_usr_ID = 1,
                            cod_usr = cod_usr,
                            usr = v_usuariof,
                            clave = encrypta.Encrypt("poc123"),
                            correo_corp = v_usuariof + "@liec.com.mx",
                            empresa_ID = guid_emp,
                            registro = DateTime.Now
                        };
                        var a_usr_pers = new inf_usr_personales
                        {
                            usr_personales_ID = Guid.NewGuid(),
                            nombres = v_nombre,
                            apaterno = v_apellidopaterno,
                            amaterno = v_apellidomaterno,
                            genero_ID = v_genero,
                            estcivil_ID = v_estadocivil,
                            hijos = v_hijos,
                            cumple = v_cumpleaños,
                            licencia = v_licencia,
                            rfc = v_rfc,
                            curp = v_curp,
                            nss = v_nss,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };
                        var a_usr_rh = new inf_usr_rh

                        {
                            usr_rh_ID = Guid.NewGuid(),
                            fecha_ingreso = v_ingreso,
                            area_ID = v_areas,
                            perfil_ID = v_perfil,
                            jefe_inmediato = v_responsable,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };
                        var a_usr_cont = new inf_usr_contacto

                        {
                            usr_contacto_ID = Guid.NewGuid(),
                            tel = v_telefono,
                            tel_alt = v_telefonoalterno,
                            correo = v_correoelectronico,
                            correo_alt = v_correoelectronicoalterno,
                            callenum = v_calleynumero,
                            d_codigo = v_codigopostal,
                            id_asenta_cpcons = v_colonia,
                            usuario_ID = guid_usrID,
                            registro = DateTime.Now
                        };

                        edm_fusr.inf_usuario.Add(a_usr);
                        edm_fusr.inf_usr_personales.Add(a_usr_pers);
                        edm_fusr.inf_usr_rh.Add(a_usr_rh);
                        edm_fusr.inf_usr_contacto.Add(a_usr_cont);

                        edm_fusr.SaveChanges();

                        limp_usr_ctrl();
                        Mensaje("Datos de usuario agregados con éxito.");
                    }
                }
                else
                {
                    limp_usr_ctrl();
                    rfv_usr_coment.Enabled = false;
                    Mensaje("Usuario existe en la base de datos, favor de revisar.");
                }
            }
        }

        protected void btn_usr_cp_Click(object sender, EventArgs e)
        {
            string str_codcp = txt_usr_cp.Text.Trim();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                   where c.d_codigo == str_codcp
                                   select c).ToList();

                ddl_usr_col.DataSource = tbl_sepomex;
                ddl_usr_col.DataTextField = "d_asenta";
                ddl_usr_col.DataValueField = "id_asenta_cpcons";
                ddl_usr_col.DataBind();

                if (tbl_sepomex.Count == 1)
                {
                    txt_usr_municipio.Text = tbl_sepomex[0].d_mnpio;
                    txt_usr_estado.Text = tbl_sepomex[0].d_estado;
                    rfv_col_usr.Enabled = true;
                }
                if (tbl_sepomex.Count > 1)
                {
                    ddl_usr_col.Items.Insert(0, new ListItem("Seleccionar", "0"));

                    txt_usr_municipio.Text = tbl_sepomex[0].d_mnpio;
                    txt_usr_estado.Text = tbl_sepomex[0].d_estado;
                    rfv_col_usr.Enabled = true;
                }
                else if (tbl_sepomex.Count == 0)
                {
                    ddl_usr_col.Items.Clear();
                    ddl_usr_col.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    txt_usr_municipio.Text = null;
                    txt_usr_estado.Text = null;
                }
            }
            up_usrs.Update();
            ddl_usr_col.Focus();
        }

        protected void chkb_usr_desact_CheckedChanged(object sender, EventArgs e)
        {
            rfv_usr_area.Enabled = false;
            rfv_usr_perfil.Enabled = false;
            rfv_usr_genero.Enabled = false;
            rfv_usr_nombres.Enabled = false;
            rfv_usr_apaterno.Enabled = false;
            rfv_usr_amaterno.Enabled = false;
            rfv_usr_fnac.Enabled = false;
            rfv_usr_estciv.Enabled = false;
            rfv_col_usr.Enabled = false;
            rfv_buscar_usr.Enabled = false;
            rfv_usr_coment.Enabled = false;
        }

        protected void btn_buscar_usr_Click(object sender, EventArgs e)
        {
            limp_usr_ctrl();
            div_usr_f.Visible = false;
            string str_filtro = txt_buscar_usr.Text.ToUpper().Trim();

            if (str_filtro == "TODO")
            {
                using (bd_labEntities data_user = new bd_labEntities())
                {
                    var i_usr = (from i_u in data_user.inf_usuario
                                 join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID

                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.cod_usr,
                                     nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                     i_u.registro
                                 }).OrderBy(x => x.cod_usr).ToList();

                    if (i_usr.Count == 0)
                    {
                        gv_usrs.DataSource = i_usr;
                        gv_usrs.DataBind();
                        gv_usrs.Visible = true;
                        gv_usrs.Visible = true;

                        Mensaje("Usuario no encontrado.");
                    }
                    else
                    {
                        gv_usrs.DataSource = i_usr;
                        gv_usrs.DataBind();
                        gv_usrs.Visible = true;
                        gv_usrs.Visible = true;
                    }
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_usr.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_usuario
                                       where c.cod_usr == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.usuario_ID;
                    }

                    using (bd_labEntities data_user = new bd_labEntities())
                    {
                        var i_usr = (from i_u in data_user.inf_usuario
                                     join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                     where i_u.usuario_ID == guid_usrid
                                     select new
                                     {
                                         i_u.usuario_ID,
                                         i_u.cod_usr,
                                         nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                         i_u.registro
                                     }).OrderBy(x => x.cod_usr).ToList();

                        if (i_usr.Count == 0)
                        {
                            gv_usrs.DataSource = i_usr;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;

                            Mensaje("Usuario no encontrado.");
                        }
                        else
                        {
                            gv_usrs.DataSource = i_usr;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;
                        }
                    }
                }
                catch
                {
                    limp_usr_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
        }

        protected void btn_usr_agregar_Click(object sender, EventArgs e)
        {
            int_usr = 1;

            i_usr_agregar.Attributes["style"] = "color:#E34C0E";
            i_usr_editar.Attributes["style"] = "color:white";
            carga_cmb_usr();
            limp_usr_ctrl();
            pnl_usrs.Visible = true;
            div_busc_usr.Visible = false;
            rfv_usr_area.Enabled = true;
            rfv_usr_perfil.Enabled = true;
            rfv_usr_genero.Enabled = true;
            rfv_usr_nombres.Enabled = true;
            rfv_usr_apaterno.Enabled = true;
            rfv_usr_amaterno.Enabled = true;
            rfv_usr_fnac.Enabled = true;
            rfv_usr_estciv.Enabled = true;
            rfv_col_usr.Enabled = false;
            rfv_buscar_usr.Enabled = false;
            gv_usrs.Visible = false;
            div_usr_f.Visible = true;
            up_usrs.Update();
        }

        protected void gv_usrs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_usrs.PageIndex = e.NewPageIndex;
            limp_usr_ctrl();
            string str_filtro = txt_buscar_usr.Text.ToUpper().Trim();

            if (str_filtro == "TODO")
            {
                using (bd_labEntities data_user = new bd_labEntities())
                {
                    var i_usr = (from i_u in data_user.inf_usuario
                                 join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID

                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.cod_usr,
                                     nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                     i_u.registro
                                 }).OrderBy(x => x.cod_usr).ToList();

                    if (i_usr.Count == 0)
                    {
                        gv_usrs.DataSource = i_usr;
                        gv_usrs.DataBind();
                        gv_usrs.Visible = true;
                        gv_usrs.Visible = true;

                        Mensaje("Usuario no encontrado.");
                    }
                    else
                    {
                        gv_usrs.DataSource = i_usr;
                        gv_usrs.DataBind();
                        gv_usrs.Visible = true;
                        gv_usrs.Visible = true;
                    }
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_usr.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_usuario
                                       where c.cod_usr == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.usuario_ID;
                    }

                    using (bd_labEntities data_user = new bd_labEntities())
                    {
                        var i_usr = (from i_u in data_user.inf_usuario
                                     join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                     where i_u.usuario_ID == guid_usrid
                                     select new
                                     {
                                         i_u.usuario_ID,
                                         i_u.cod_usr,
                                         nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                         i_u.registro
                                     }).OrderBy(x => x.cod_usr).ToList();

                        if (i_usr.Count == 0)
                        {
                            gv_usrs.DataSource = i_usr;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;

                            Mensaje("Usuario no encontrado.");
                        }
                        else
                        {
                            gv_usrs.DataSource = i_usr;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;
                        }
                    }
                }
                catch
                {
                    limp_usr_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
        }

        protected void gv_usrs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid usr_ID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_usuario
                                  where t_clte.usuario_ID == usr_ID
                                  select new
                                  {
                                      t_clte.est_usr_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_usr_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_usr_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_usr
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "est_usr_desc";
                    DropDownList1.DataValueField = "est_usr_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_usrs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                usr_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in edm_usr.inf_usuario
                                 join i_uh in edm_usr.inf_usr_rh on i_u.usuario_ID equals i_uh.usuario_ID
                                 join i_up in edm_usr.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                 join i_uc in edm_usr.inf_usr_contacto on i_u.usuario_ID equals i_uc.usuario_ID
                                 where i_u.usuario_ID == usr_ID
                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.est_usr_ID,
                                     i_u.cod_usr,
                                     i_u.usr,
                                     i_u.clave,
                                     i_u.correo_corp,
                                     i_uh.area_ID,
                                     i_uh.perfil_ID,
                                     i_uh.jefe_inmediato,
                                     i_uh.comentarios,
                                     i_uh.fecha_ingreso,
                                     i_up.nombres,
                                     i_up.apaterno,
                                     i_up.amaterno,
                                     i_up.genero_ID,
                                     i_up.estcivil_ID,
                                     i_up.cumple,
                                     i_up.hijos,
                                     i_up.nss,
                                     i_up.curp,
                                     i_up.licencia,
                                     i_up.rfc,
                                     i_uc.tel,
                                     i_uc.tel_alt,
                                     i_uc.correo,
                                     i_uc.correo_alt,
                                     i_uc.callenum,
                                     i_uc.d_codigo,
                                     i_uc.id_asenta_cpcons
                                 }).FirstOrDefault();

                    ddl_usr_area.SelectedValue = i_usr.area_ID.ToString();
                    ddl_usr_perfil.SelectedValue = i_usr.perfil_ID.ToString();
                    ddl_usr_genero.SelectedValue = i_usr.genero_ID.ToString();
                    ddl_usr_estciv.SelectedValue = i_usr.estcivil_ID.ToString();
                    ddl_usr_responsable.SelectedValue = i_usr.jefe_inmediato;

                    DateTime f_nac = Convert.ToDateTime(i_usr.cumple);
                    DateTime f_ing = Convert.ToDateTime(i_usr.fecha_ingreso);

                    txt_usr_nombres.Text = i_usr.nombres;
                    txt_usr_apaterno.Text = i_usr.apaterno;
                    txt_usr_amaterno.Text = i_usr.amaterno;
                    txt_usr_fnac.Text = f_nac.ToString("yyyy-MM-dd");
                    txt_usr_fing.Text = f_ing.ToString("yyyy-MM-dd");
                    txt_usr_hijos.Text = i_usr.hijos.ToString();
                    txt_usr_nss.Text = i_usr.nss;
                    txt_usr_curp.Text = i_usr.curp;
                    txt_usr_licencia.Text = i_usr.licencia;
                    txt_usr_rfc.Text = i_usr.rfc;
                    txt_usr_tel.Text = i_usr.tel;
                    txt_usr_telalt.Text = i_usr.tel_alt;
                    txt_usr_email.Text = i_usr.correo;
                    txt_usr_emailalt.Text = i_usr.correo_alt;
                    txt_usr_callenum.Text = i_usr.callenum;
                    txt_usr_cp.Text = i_usr.d_codigo;
                    txt_usr_coment.Text = i_usr.comentarios;

                    string str_codcp = txt_usr_cp.Text.Trim();

                    try
                    {
                        using (bd_labEntities db_sepomex = new bd_labEntities())
                        {
                            var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                               where c.d_codigo == str_codcp
                                               select c).ToList();

                            ddl_usr_col.DataSource = tbl_sepomex;
                            ddl_usr_col.DataTextField = "d_asenta";
                            ddl_usr_col.DataValueField = "id_asenta_cpcons";
                            ddl_usr_col.DataBind();

                            ddl_usr_col.SelectedValue = i_usr.id_asenta_cpcons.ToString();

                            txt_usr_municipio.Text = tbl_sepomex[0].d_mnpio;
                            txt_usr_estado.Text = tbl_sepomex[0].d_estado;
                        }
                    }
                    catch
                    {
                        carga_cmb_usr();
                    }

                    txt_usr_coment.Text = null;
                    txt_usr_cod.Text = i_usr.usr;

                    txt_usr_emailcorp.Text = i_usr.correo_corp;

                    using (bd_labEntities data_user = new bd_labEntities())
                    {
                        var i_usr_f = (from i_u in data_user.inf_usuario
                                       join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                       where i_u.usuario_ID == usr_ID
                                       select new
                                       {
                                           i_u.usuario_ID,
                                           i_u.cod_usr,
                                           nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                           i_u.registro
                                       }).OrderBy(x => x.cod_usr).ToList();

                        if (i_usr_f.Count == 0)
                        {
                            gv_usrs.DataSource = i_usr_f;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;

                            Mensaje("Usuario no encontrado.");
                        }
                        else
                        {
                            gv_usrs.DataSource = i_usr_f;
                            gv_usrs.DataBind();
                            gv_usrs.Visible = true;
                            gv_usrs.Visible = true;
                        }
                    }

                    div_usr_f.Visible = true;
                }
            }
            catch
            { }
        }

        protected void ddl_usr_estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ddl;

            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList duty = (DropDownList)gvr.FindControl("ddl_usr_estatus");
            str_ddl = duty.SelectedItem.Value;

            if (str_ddl == "2" || str_ddl == "3")
            {
                txt_usr_coment.Enabled = true;
                rfv_usr_coment.Enabled = true;
            }
            else
            {
                txt_usr_coment.Enabled = false;
                rfv_usr_coment.Enabled = false;
            }
        }

        protected void btn_usr_editar_Click(object sender, EventArgs e)
        {
            int_usr = 2;
            str_pnlID = "pnl_usr";

            i_usr_agregar.Attributes["style"] = "color:white";
            i_usr_editar.Attributes["style"] = "color:#E34C0E";

            div_busc_usr.Visible = true;

            rfv_usr_area.Enabled = false;
            rfv_usr_perfil.Enabled = false;
            rfv_usr_genero.Enabled = false;
            rfv_usr_nombres.Enabled = false;
            rfv_usr_apaterno.Enabled = false;
            rfv_usr_amaterno.Enabled = false;
            rfv_usr_fnac.Enabled = false;
            rfv_usr_estciv.Enabled = false;
            rfv_col_usr.Enabled = false;
            rfv_buscar_usr.Enabled = true;
            div_usr_f.Visible = false;

            txt_buscar_usr.Text = null;
        }

        private void limp_usr_ctrl()
        {
            carga_cmb_usr();

            txt_usr_nombres.Text = null;
            txt_usr_apaterno.Text = null;
            txt_usr_amaterno.Text = null;
            txt_usr_tel.Text = null;
            txt_usr_email.Text = null;
            txt_usr_fnac.Text = null;
            txt_usr_fing.Text = null;
            txt_usr_hijos.Text = "0";
            txt_usr_nss.Text = null;
            txt_usr_curp.Text = null;
            txt_usr_licencia.Text = null;
            txt_usr_rfc.Text = null;
            txt_usr_tel.Text = null;
            txt_usr_telalt.Text = null;
            txt_usr_email.Text = null;
            txt_usr_emailalt.Text = null;
            txt_usr_callenum.Text = null;
            txt_usr_cp.Text = null;
            txt_usr_municipio.Text = null;
            txt_usr_estado.Text = null;
            txt_usr_coment.Text = null;
            txt_usr_cod.Text = null;
            txt_usr_clave.Text = null;
            txt_usr_emailcorp.Text = null;

            rfv_col_usr.Enabled = false;
        }

        #endregion control_usuarios

        #region datos médicos

        protected void btn_buscar_usr_med_Click(object sender, EventArgs e)
        {
            limp_usr_med_ctrl();
            div_usr_medf.Visible = false;
            string str_filtro = txt_buscar_usr_med.Text.ToUpper().Trim();

            if (str_filtro == "TODO")
            {
                using (bd_labEntities data_user = new bd_labEntities())
                {
                    var i_usr = (from i_u in data_user.inf_usuario
                                 join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID

                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.cod_usr,
                                     nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                     i_u.registro
                                 }).OrderBy(x => x.cod_usr).ToList();

                    if (i_usr.Count == 0)
                    {
                        gv_usr_med.DataSource = i_usr;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                        gv_usr_med.Visible = true;

                        Mensaje("Usuario no encontrado.");
                    }
                    else
                    {
                        gv_usr_med.DataSource = i_usr;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                        gv_usr_med.Visible = true;
                    }
                }
            }
            else
            {
                try
                {
                    string n_rub;
                    Guid guid_usrid;
                    Char char_s = '|';
                    string d_rub = txt_buscar_usr_med.Text.Trim();
                    String[] de_rub = d_rub.Trim().Split(char_s);

                    n_rub = de_rub[1].Trim();

                    using (bd_labEntities edm_nclte = new bd_labEntities())
                    {
                        var i_nclte = (from c in edm_nclte.inf_usuario
                                       where c.cod_usr == n_rub
                                       select c).FirstOrDefault();

                        guid_usrid = i_nclte.usuario_ID;
                    }

                    using (bd_labEntities data_user = new bd_labEntities())
                    {
                        var i_usr = (from i_u in data_user.inf_usuario
                                     join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                     where i_u.usuario_ID == guid_usrid
                                     select new
                                     {
                                         i_u.usuario_ID,
                                         i_u.cod_usr,
                                         nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                         i_u.registro
                                     }).OrderBy(x => x.cod_usr).ToList();

                        if (i_usr.Count == 0)
                        {
                            gv_usr_med.DataSource = i_usr;
                            gv_usr_med.DataBind();
                            gv_usr_med.Visible = true;
                            gv_usr_med.Visible = true;

                            Mensaje("Usuario no encontrado.");
                        }
                        else
                        {
                            gv_usr_med.DataSource = i_usr;
                            gv_usr_med.DataBind();
                            gv_usr_med.Visible = true;
                            gv_usr_med.Visible = true;
                        }
                    }
                }
                catch
                {
                    limp_usr_med_ctrl();
                    //div_prospecto.Visible = false;
                    Mensaje("Usuario no encontrado.");
                }
            }
        }

        protected void btn_usr_med_agregar_Click(object sender, EventArgs e)
        {
            int_usr_med = 1;
            str_pnlID = "pnl_usr";

            i_usr_med_agregar.Attributes["style"] = "color:#E34C0E";
            i_usr_med_editar.Attributes["style"] = "color:white";

            limp_usr_med_ctrl();

            div_busc_usr_med.Visible = true;

            gv_usr_med.Visible = false;
            div_usr_medf.Visible = false;

            up_usr_med.Update();
        }

        private void limp_usr_med_ctrl()
        {
            txt_usr_med_estatura.Text = null;
            txt_usr_med_peso.Text = null;
            txt_usr_med_tiposangre.Text = null;
            ddl_usr_med_falergia.Items.Clear();

            using (bd_labEntities db_sepomex = new bd_labEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.fact_alergia
                                   select c).ToList();

                ddl_usr_med_falergia.DataSource = tbl_sepomex;
                ddl_usr_med_falergia.DataTextField = "alegia_desc";
                ddl_usr_med_falergia.DataValueField = "alergia_ID";
                ddl_usr_med_falergia.DataBind();
            }
            ddl_usr_med_falergia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            txt_usr_med_alergia.Text = null;
            txt_usr_med_tratamiento.Text = null;
        }

        protected void btn_usr_med_editar_Click(object sender, EventArgs e)
        {
            int_usr_med = 2;
            str_pnlID = "pnl_usr";

            i_usr_med_agregar.Attributes["style"] = "color:white";
            i_usr_med_editar.Attributes["style"] = "color:#E34C0E";

            limp_usr_med_ctrl();

            div_busc_usr_med.Visible = true;

            gv_usr_med.Visible = false;

            up_usr_med.Update();
        }

        protected void ddl_usr_med_falergia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_usr_med_falergia.SelectedValue == "1")
            {
                txt_usr_med_alergia.Enabled = true;
                rfv_usr_med_alergia.Enabled = true;
                txt_usr_med_tratamiento.Enabled = true;
                rfv_usr_med_tratamiento.Enabled = true;
            }
            else
            {
                txt_usr_med_alergia.Enabled = false;
                rfv_usr_med_alergia.Enabled = false;
                txt_usr_med_tratamiento.Enabled = false;
                rfv_usr_med_tratamiento.Enabled = false;
            }
        }

        protected void btn_usr_med_guardar_Click(object sender, EventArgs e)
        {
            if (int_usr_med == 0)
            {
                Mensaje("Favor de seleccionar una acción.");
            }
            else if (int_usr_med == 1)
            {
                guardar_usr_med();
            }
            else if (int_usr_med == 2)
            {
                edita_usr_med();
            }
            else
            { }
        }

        private void edita_usr_med()
        {
        }

        private void guardar_usr_med()
        {
            string v_estatura, v_peso, v_tiposangre, v_alergia, v_tratamiento;
            int v_falergia;

            v_estatura = txt_usr_med_estatura.Text;
            v_peso = txt_usr_med_peso.Text;
            v_tiposangre = txt_usr_med_tiposangre.Text.ToUpper().Trim();
            v_falergia = int.Parse(ddl_usr_med_falergia.SelectedValue);
            v_alergia = txt_usr_med_alergia.Text;
            v_tratamiento = txt_usr_med_tratamiento.Text;

            using (bd_labEntities edm_fusr = new bd_labEntities())
            {
                var i_fusr = (from c in edm_fusr.inf_usr_medicos
                              where c.alergia == v_alergia
                              where c.usuario_ID == usr_ID
                              select c).ToList();

                if (i_fusr.Count == 0)
                {
                    var a_usr = new inf_usr_medicos
                    {
                        usr_medicos_ID = Guid.NewGuid(),
                        estatura = v_estatura,
                        peso = v_peso,
                        tipo_sangre = v_tiposangre,
                        alergia_ID = v_falergia,
                        alergia = v_alergia,
                        tratamiento = v_tratamiento,
                        usuario_ID = guid_idusr
                    };

                    edm_fusr.inf_usr_medicos.Add(a_usr);

                    edm_fusr.SaveChanges();

                    limp_usr_med_ctrl();

                    Mensaje("Datos médicos agregados con éxito.");
                }
                else
                {
                    limp_usr_med_ctrl();

                    Mensaje("Información duplicada, favor de revisar.");
                }
            }
        }

        protected void chkb_usr_med_desact_CheckedChanged(object sender, EventArgs e)
        {
            rfv_usr_med_estatura.Enabled = false;
            rfv_usr_med_peso.Enabled = false;
            rfv_usr_med_tiposangre.Enabled = false;
            rfv_usr_med_falergia.Enabled = false;
            rfv_usr_med_alergia.Enabled = false;

            rfv_usr_med_tratamiento.Enabled = false;
        }

        protected void gv_user_med_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid usr_ID = Guid.Parse(e.Row.Cells[0].Text);
                int int_estatusID;

                using (bd_labEntities data_clte = new bd_labEntities())
                {
                    var i_clte = (from t_clte in data_clte.inf_usuario
                                  where t_clte.usuario_ID == usr_ID
                                  select new
                                  {
                                      t_clte.est_usr_ID,
                                  }).FirstOrDefault();

                    int_estatusID = int.Parse(i_clte.est_usr_ID.ToString());
                }

                DropDownList DropDownList1 = (e.Row.FindControl("ddl_usr_med_estatus") as DropDownList);

                using (bd_labEntities db_sepomex = new bd_labEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.fact_est_usr
                                       select c).ToList();

                    DropDownList1.DataSource = tbl_sepomex;

                    DropDownList1.DataTextField = "est_usr_desc";
                    DropDownList1.DataValueField = "est_usr_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    DropDownList1.SelectedValue = int_estatusID.ToString();
                }
            }
        }

        protected void gv_user_med_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gvr.BackColor = Color.FromArgb(227, 76, 14);
                usr_ID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

                using (bd_labEntities edm_usr = new bd_labEntities())
                {
                    var i_usr = (from i_um in edm_usr.inf_usr_medicos

                                 where i_um.usuario_ID == usr_ID
                                 select new
                                 {
                                     i_um.estatura,
                                     i_um.peso,
                                     i_um.tipo_sangre,
                                     i_um.alergia_ID,
                                     i_um.alergia,
                                     i_um.tratamiento,
                                 }).FirstOrDefault();

                    txt_usr_med_estatura.Text = i_usr.estatura;
                    txt_usr_med_peso.Text = i_usr.peso;
                    txt_usr_med_tiposangre.Text = i_usr.tipo_sangre;
                    ddl_usr_med_falergia.SelectedValue = i_usr.alergia_ID.ToString();
                    txt_usr_med_alergia.Text = i_usr.alergia;
                    txt_usr_med_tratamiento.Text = i_usr.tratamiento;

                    div_usr_medf.Visible = true;
                }
                using (bd_labEntities data_user = new bd_labEntities())
                {
                    var i_usr_f = (from i_u in data_user.inf_usuario
                                   join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                   where i_u.usuario_ID == usr_ID
                                   select new
                                   {
                                       i_u.usuario_ID,
                                       i_u.cod_usr,
                                       nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                       i_u.registro
                                   }).OrderBy(x => x.cod_usr).ToList();

                    if (i_usr_f.Count == 0)
                    {
                        gv_usr_med.DataSource = i_usr_f;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                        gv_usr_med.Visible = true;

                        Mensaje("Usuario no encontrado.");
                    }
                    else
                    {
                        gv_usr_med.DataSource = i_usr_f;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                    }
                }
            }
            catch
            {
                using (bd_labEntities data_user = new bd_labEntities())
                {
                    var i_usr_f = (from i_u in data_user.inf_usuario
                                   join i_up in data_user.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                   where i_u.usuario_ID == usr_ID
                                   select new
                                   {
                                       i_u.usuario_ID,
                                       i_u.cod_usr,
                                       nom_comp = i_up.nombres + " " + i_up.apaterno + " " + i_up.amaterno,
                                       i_u.registro
                                   }).OrderBy(x => x.cod_usr).ToList();

                    if (i_usr_f.Count == 0)
                    {
                        gv_usr_med.DataSource = i_usr_f;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                        gv_usr_med.Visible = true;

                        Mensaje("Usuario no encontrado.");
                    }
                    else
                    {
                        gv_usr_med.DataSource = i_usr_f;
                        gv_usr_med.DataBind();
                        gv_usr_med.Visible = true;
                    }
                }
                rfv_usr_med_estatura.Enabled = true;
                rfv_usr_med_peso.Enabled = true;
                rfv_usr_med_tiposangre.Enabled = true;
                rfv_usr_med_falergia.Enabled = true;
                div_usr_medf.Visible = true;
            }
        }

        protected void gv_user_med_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        #endregion datos médicos
    }
}