using System;
using System.Linq;
using System.Web.UI;

namespace lab_liec
{
    public partial class acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_acceso_Click(object sender, EventArgs e)
        {
            string user, pass, pass_qa;
            int cod_area;
            Guid guid_idusr;
            
            user = txt_usuario.Text;
            pass = encrypta.Encrypt(txt_clave.Text);

            try

            {
                using (var m_usr = new bd_labEntities())
                {
                    var i_usr = (from i_u in m_usr.inf_usuario
                                 join i_uh in m_usr.inf_usr_rh on i_u.usuario_ID equals i_uh.usuario_ID
                                 where i_u.usr == user
                                 select new
                                 {
                                     i_u.usuario_ID,
                                     i_u.clave,
                                     i_uh.area_ID

                                 }).ToList();

                    cod_area = i_usr[0].area_ID;
                    guid_idusr = i_usr[0].usuario_ID;
                    pass_qa = i_usr[0].clave;

                    if (i_usr.Count == 0)
                    {
                        Mensaje("Usuario no existe, favor de reintentar");
                    }
                    else
                    {
                        if (pass == pass_qa)
                        {

                            switch (cod_area)
                            {
                                case 6:

                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_capt.aspx");
                                    break;

                                case 9:
                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_control.aspx");
                                    break;

                                case 17:
                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_control.aspx");
                                    break;

                                case 7:
                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_cont.aspx");
                                    break;

                                case 10:

                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_capt.aspx");
                                    break;
                                case 13:

                                    Session["ss_idusr"] = guid_idusr;

                                    Response.Redirect("pnl_recursos_humanos.aspx");
                                    break;
                                default:

                                    break;
                            }
                        }
                        else
                        {
                            Mensaje("Contraseña incorrecta, favor de reintentar");
                        }
                    }

                }

            }
            catch
            {
                Mensaje("Datos incorrectos, favor de reintentar");
            }
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "LIEC";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}