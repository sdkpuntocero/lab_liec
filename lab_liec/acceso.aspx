﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="lab_liec.acceso" %>

<!DOCTYPE html>
<html lang="es-MX">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="shortcut icon" href="img/ico_liec.png" type="image/png" />
    <title>\ Acceso</title>


    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/fontawesome-free-5.7.0-web/css/all.css" rel="stylesheet" />
  

    <link href="styles/style_liec.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        body {
            color: #999;
            background: #f5f5f5;
            font-family: 'Varela Round', sans-serif;
        }

        .form-control {
            box-shadow: none;
            border-color: #ddd;
        }

            .form-control:focus {
                border-color: #E34C0E;
            }

        .login-form {
            width: 350px;
            margin: 0 auto;
            padding: 30px 0;
        }

            .login-form form {
                color: #999;
                border-radius: 1px;
                margin-bottom: 15px;
                background: #fff;
                border: 1px solid #f3f3f3;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
                padding: 30px;
            }

            .login-form h4 {
                text-align: center;
                font-size: 22px;
                margin-bottom: 20px;
            }

            .login-form .avatar {
                color: #fff;
                margin: 0 auto 30px;
                text-align: center;
                width: 100px;
                height: 100px;
            }

                .login-form .avatar i {
                    font-size: 62px;
                }

            .login-form .form-group {
                margin-bottom: 20px;
            }

            .login-form .form-control, .login-form .btn {
                min-height: 40px;
                border-radius: 2px;
                transition: all 0.5s;
            }

            .login-form .close {
                position: absolute;
                top: 15px;
                right: 15px;
            }

            .login-form .btn {
                background: #104D8d;
                border: none;
                line-height: normal;
            }

                .login-form .btn:hover, .login-form .btn:focus {
                    background: #E34C0E;
                }

            .login-form .checkbox-inline {
                float: left;
            }

            .login-form input[type="checkbox"] {
                margin-top: 2px;
            }

            .login-form .forgot-link {
                float: right;
            }

            .login-form .small {
                font-size: 10px;
            }

            .login-form a {
                color: #E34C0E;
            }
    </style>
</head>
<body>
    <div class="login-form">

        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="avatar">
                <%--<i class="material-icons">&#xE7FF;</i>--%>
                <img class="img-responsive  img-thumbnail" src="img/ico_liec.png" width="128" />
            </div>
            <h4 class="modal-title">Ingrese a su cuenta</h4>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txt_usuario" runat="server" TabIndex="1" placeholder="Usuario"></asp:TextBox>
                <div class="text-right">
                    <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usuario" ForeColor="#E34C0E"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txt_clave" runat="server" TabIndex="2" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                <div class="text-right">
                    <asp:RequiredFieldValidator ID="rfv_clave" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_clave" ForeColor="#E34C0E"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group  clearfix">

                <a href="#" class="forgot-link">¿Se te olvidó tu contraseña?</a>
            </div>
            <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="btn_acceso" runat="server" Text="Iniciar sesión" TabIndex="3" OnClick="btn_acceso_Click" />
            <div class="text-center small">
                <br />
                ¿No tienes una cuenta? 
                <br />
                Contactar al Dpto. de Recursos Humanos
            </div>
            <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-content">
                                <div class="modal-header encabezado001">
                                    <button type="button" class="close login100-form-title" data-dismiss="modal" aria-hidden="true">x</button>
                                    
                                        <asp:Label ID="lblModalTitle" CssClass="login100-form-title" runat="server" Text=""></asp:Label>
                                   
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblModalBody" CssClass="login100-form-title" runat="server" Text=""></asp:Label>
                                </div>
                               
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>