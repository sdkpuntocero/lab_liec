<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pnl_captura.aspx.cs" Inherits="lab_liec.pnl_captura" Culture="es-MX" %>

<!DOCTYPE html>

<html lang="es-MX">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="Content/fontawesome-free-5.7.0-web/css/all.css" rel="stylesheet" />
    <link href="styles/style_liec.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>

    <link rel="shortcut icon" href="img/ico_liec.png" type="image/png" />
    <title>/ Captura </title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">

            <div class="row">
                <asp:UpdatePanel ID="up_bienvenida" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <br />
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ico_liec.png" Width="64" Height="64" CssClass="img-thumbnail" />
                            </div>
                            <div class="col-lg-6">
                                <div>
                                    <p class="text-right">
                                        <label class="control-label fuente_css02">BIENVENID@:</label>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_usr_oper" runat="server">
                                            <asp:Label CssClass="buttonClass" ID="lbl_usr_oper" runat="server" Text=""></asp:Label>&nbsp;<i class="fas fa-user-cog" id="i_usr_oper" runat="server"></i>
                                        </asp:LinkButton>
                                        <br />
                                        <label class="control-label fuente_css02">PERFIL:</label>
                                        <asp:Label CssClass="fuente_css02" ID="lbl_tusr" runat="server" Text=""></asp:Label>&nbsp;<i class="fas fa-user-shield fuente_css02" id="i1" runat="server"></i>
                                        <br />
                                        <label class="control-label fuente_css02">EMPRESA:</label>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_emp_oper" runat="server">
                                            <asp:Label CssClass="buttonClass" ID="lbl_emp_oper" runat="server" Text=""></asp:Label>&nbsp;<i class="fas fa-building" id="i_emp_oper" runat="server"></i>
                                        </asp:LinkButton>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                <div class="row">
                    <asp:UpdatePanel ID="up_captura_menu" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-2">
                                <br />
                                <div class="sidebar-nav">
                                    <div class="navbar-default" role="navigation">
                                        <div class="navbar-header">
                                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-navbar-collapse"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                                            <span class="visible-xs navbar-brand">Menú</span>
                                        </div>
                                        <div class="navbar-collapse collapse sidebar-navbar-collapse">
                                            <br />
                                            <div class="sidebar" style="display: block;">
                                                <ul class="nav">
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_prosp" runat="server" OnClick="lkb_prosp_Click">

                                                            <asp:Label CssClass="buttonClass" ID="lbl_prosp" runat="server" Text="Prospectos"> </asp:Label>
                                                            <i class="fas fa-user-tie" id="i_prosp" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_clte" runat="server" OnClick="lkb_clte_Click">

                                                            <asp:Label CssClass="buttonClass" ID="lbl_clte" runat="server" Text="Clientes"> </asp:Label>
                                                            <i class="fas fa-user-tie" id="i_clte" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_clte_obras" runat="server" OnClick="lkb_clte_obras_Click">

                                                            <asp:Label CssClass="buttonClass" ID="lbl_clte_obras" runat="server" Text="Obras"> </asp:Label>
                                                            <i class="fas fa-mosque" id="i_clte_obras" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_concreto" runat="server" OnClick="lkb_concreto_Click">

                                                            <asp:Label CssClass="buttonClass" ID="lbl_concreto" runat="server" Text="Concreto"></asp:Label>
                                                            <i class="fab fa-simplybuilt" id="i_concreto" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_conc_ensaye" runat="server" OnClick="lkb_conc_ensaye_Click">

                                                            <asp:Label CssClass="buttonClass" ID="lbl_conc_ensaye" runat="server" Text="Ensaye"></asp:Label>
                                                            <i class="fas fa-vials" id="i_conc_ensaye" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <br />
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_regresar" runat="server" OnClick="lkb_regresar_Click">
                                                            <asp:Label CssClass="buttonClass" ID="lbl_regresar" runat="server" Text="Regresar"></asp:Label>
                                                            <i class="fas fa-undo-alt" id="i_regresar" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton CssClass="fuente_css02" ID="lkb_salir" runat="server" OnClick="lkb_salir_Click">
                                                            <asp:Label CssClass="buttonClass" ID="lbl_salir" runat="server" Text="SALIR"></asp:Label>
                                                            <i class="fas fa-power-off" id="i_salir" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_prospectos" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <br />
                            <div class="col-lg-10">
                                <div class="col-lg-12" runat="server" id="div_nav_prospectos" visible="false">
                                    <div class="row">
                                        <ul class="nav nav-tabs">
                                            <li>
                                                <asp:LinkButton CssClass="fuente_css02" ID="lkb_prosp_prosp" runat="server" OnClick="lkb_prosp_prosp_Click">
                                                    <asp:Label ID="lbl_prosp_prosp" runat="server" Text="Agregar y Editar"></asp:Label>&nbsp;<i class="fas fa-user-tag" id="i_prosp_prosp" runat="server"></i>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton CssClass="fuente_css02" ID="lkb_prosp_cont" runat="server" OnClick="lkb_prosp_cont_Click">
                                                    <asp:Label ID="lbl_prosp_cont" runat="server" Text="Contactos"></asp:Label>&nbsp;<i class="fas fa-user-tie" id="i_prosp_cont" runat="server"></i>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton CssClass="fuente_css02" ID="lkb_prosp_seg" runat="server" OnClick="lkb_prosp_seg_Click">
                                                    <asp:Label ID="lbl_prosp_seg" runat="server" Text="Seguimiento"></asp:Label>&nbsp;<i class="fas fa-user-tie" id="i_prosp_seg" runat="server"></i>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="row">
                                        <div class="panel panel-default" id="pnl_prospecto" runat="server" visible="false">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-8 col-sm-8">
                                                        <div class="input-group" id="div_busc_prospecto" runat="server" visible="false">
                                                            <span class="input-group-addon">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_prospecto" runat="server" Text="*Buscar Prospecto:"></asp:Label>
                                                            </span>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_prospecto" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_buscar_prospecto" runat="server" Text="Ir" TabIndex="2" />
                                                            </span>
                                                        </div>
                                                        <div class="text-right">
                                                            <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_prospecto" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_prospecto" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                            <asp:RequiredFieldValidator ID="rfv_buscar_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_prospecto" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4">
                                                        <p class="text-right">
                                                            PROSPECTOS
                                                        <span>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_agregar_prospecto" runat="server" ToolTip="AGREGAR PROSPECTO" TabIndex="3">
                                                                <i class="fas fa-plus" id="i_agregar_prospecto" runat="server"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_editar_prospecto" runat="server" ToolTip="EDITAR PROSPECTO" TabIndex="4">
                                                                <i class="far fa-edit" id="i_editar_prospecto" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                            <br />
                                                            <asp:CheckBox ID="chkb_desactivar_prospecto" runat="server" AutoPostBack="true" Text="Limpiar" TabIndex="5" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12" runat="server" id="div_prospecto" visible="false">
                                                        <asp:GridView CssClass="table" ID="gv_prospecto" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="6" PageSize="5">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="id_prospecto" HeaderText="ID" SortExpression="id_prospecto" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="cod_prospecto" HeaderText="ID" SortExpression="cod_prospecto" Visible="true" />
                                                                <asp:BoundField DataField="empresa" HeaderText="Empresa" SortExpression="empresa" />
                                                                <asp:BoundField DataField="nom_usr" HeaderText="Usuario" SortExpression="nom_usr" />
                                                                <asp:BoundField DataField="fecha_registro" HeaderText="Fecha" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />

                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_tipocont_prospecto" runat="server" Text="*Tipo de Contacto"></asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-box" ID="ddl_tipocont_prospecto" runat="server" TabIndex="15" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_tipocont_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_tipocont_prospecto" InitialValue="0" ForeColor="DarkRed" Enabled="false" TabIndex="14"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_giro_prospecto" runat="server" Text="Giro Empresa"></asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-box" ID="ddl_giro_prospecto" runat="server" TabIndex="15" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_giro_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_giro_prospecto" InitialValue="0" ForeColor="DarkRed" Enabled="false" TabIndex="14"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_serv_prospecto" runat="server" Text="Servicio LIEC"></asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-box" ID="ddl_serv_prospecto" runat="server" TabIndex="15" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_serv_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_serv_prospecto" InitialValue="0" ForeColor="DarkRed" Enabled="false" TabIndex="14"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_emp_prospecto" runat="server" Text="*Empresa"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_emp_prospecto" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_emp_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_emp_prospecto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_callenum_prospecto" runat="server" Text="Calle ý número"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_callenum_prospecto" runat="server" placeholder="letras/números" ToolTip="letras/números" BackColor="LightGray" ForeColor="#104D8D" TabIndex="12"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_callenum_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_callenum_prospecto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_cp_prospecto" runat="server" Text="Código Postal"></asp:Label>
                                                            <div class="input-group">
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_cp_prospecto" runat="server" placeholder="5 (0-9)" MaxLength="5" ToolTip="Un código postal valido consiste en 5 numeros con valores del 0-9" TabIndex="13"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="mee_cp_prospecto" runat="server" TargetControlID="txt_cp_prospecto" Mask="99999" />
                                                                <span class="input-group-btn">
                                                                    <asp:Button CssClass="btn btn-warning" ID="btn_cp_prospecto" runat="server" Text="Ir" TabIndex="14" />
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_cp_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cp_prospecto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_colonia_prospecto" runat="server" Text="Colonia"></asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-box" ID="ddl_colonia_prospecto" runat="server" TabIndex="15" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_colonia_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_colonia_prospecto" InitialValue="0" ForeColor="DarkRed" Enabled="false" TabIndex="14"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_municipio_prospecto" runat="server" Text="Municipio"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_municipio_prospecto" runat="server" placeholder="letras/números" Enabled="false" BackColor="LightGray" TabIndex="16"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_estado_prospecto" runat="server" Text="Estado"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_estado_prospecto" runat="server" placeholder="letras/números" Enabled="false" BackColor="LightGray" TabIndex="17"></asp:TextBox>
                                                        </div>
                                                        <div class="text-right">
                                                            <asp:Button CssClass="btn btn-warning" ID="btn_gprosp_alt" runat="server" Text="GUARDAR" TabIndex="18" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_dpto_prosp" runat="server" Text="Departamento contacto"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_dpto_prosp" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_dpto_prosp" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_dpto_prosp" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_cont_prospecto" runat="server" Text="Contacto"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_cont_prospecto" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_cont_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cont_prospecto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_tel1_prospecto" runat="server" Text="Teléfono"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_tel1_prospecto" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9" TabIndex="10"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RegularExpressionValidator ID="rev_tel1_prospecto" runat="server"
                                                                    ErrorMessage="Formato Invalido" ControlToValidate="txt_tel1_prospecto"
                                                                    ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_tel2_prospecto" runat="server" Text="Teléfono"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_tel2_prospecto" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9" TabIndex="10"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RegularExpressionValidator ID="rev_tel2_prospecto" runat="server"
                                                                    ErrorMessage="Formato Invalido" ControlToValidate="txt_tel2_prospecto"
                                                                    ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_email1_prospecto" runat="server" Text="e-mail"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_email1_prospecto" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="11"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_email2_prospecto" runat="server" Text="e-mail"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_email2_prospecto" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="11"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="Label2" runat="server" Text="Web"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="TextBox1" runat="server" placeholder="letras/números" BackColor="LightGray" ForeColor="#104D8D" TabIndex="17"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_acc_prospecto" runat="server" Text="Acción"></asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-box" ID="ddl_acc_prospecto" runat="server" TabIndex="16" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_acc_prospecto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_acc_prospecto" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group text-left">
                                                            <asp:Label CssClass="control-label fuente_css02" ID="lbl_prospecto_coment" runat="server" Text="Comentarios"></asp:Label>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_prospecto_coment" runat="server" placeholder="letras/números" TextMode="MultiLine" BackColor="LightGray" ForeColor="#104D8D" TabIndex="17"></asp:TextBox>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_prospecto_coment" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_prospecto_coment" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="text-right">
                                                            <br />
                                                            <asp:Button CssClass="btn btn-warning" ID="btn_guardar_prospecto" runat="server" Text="GUARDAR" TabIndex="18" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_clte" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12" runat="server" id="div_nav_clte" visible="false">
                                    <div class="row">
                                        <ul class="nav nav-tabs">
                                            <li>
                                                <asp:LinkButton CssClass="fuente_css02" ID="lkb_clte_ctrl" runat="server" OnClick="lkb_clte_ctrl_Click">
                                                    <asp:Label ID="lbl_clte_ctrl" runat="server" Text="Agregar y Editar"></asp:Label>&nbsp;<i class="fas fa-user-tag" id="i_clte_ctrl" runat="server"></i>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton CssClass="fuente_css02" ID="lkb_clte_cont" runat="server" OnClick="lkb_clte_cont_Click">
                                                    <asp:Label ID="lbl_clte_cont" runat="server" Text="Contactos"></asp:Label>&nbsp;<i class="fas fa-user-tie" id="i_clte_cont" runat="server"></i>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="row">
                                        <div class="panel panel-default" id="pnl_clte" runat="server" visible="false">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-9 col-sm-9">
                                                        <div class="input-group" id="div_busc_clte" runat="server" visible="false">
                                                            <span class="input-group-addon">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_clte" runat="server" Text="*Buscar Cliente:"></asp:Label>
                                                            </span>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_clte" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_buscar_clte" runat="server" Text="Ir" OnClick="btn_buscar_clte_Click" TabIndex="2" />
                                                            </span>
                                                        </div>
                                                        <div class="text-right">
                                                            <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_clte" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_clte" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                            <asp:RequiredFieldValidator ID="rfv_buscar_clte" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_clte" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <p class="text-right">
                                                            Cliente
                                                        <span>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_clte_agregar" runat="server" ToolTip="AGREGAR CLIENTE" OnClick="btn_clte_agregar_Click" TabIndex="3">
                                                                <i class="fas fa-plus" id="i_clte_agregar" runat="server"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_clte_editar" runat="server" ToolTip="EDITAR CLIENTE" OnClick="btn_clte_editar_Click" TabIndex="4">
                                                                <i class="far fa-edit" id="i_clte_editar" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                            <br />
                                                            <asp:CheckBox ID="chkb_desactivar_clte" runat="server" AutoPostBack="true" Text=" Limpiar" OnCheckedChanged="chkb_desactivar_clte_CheckedChanged" TabIndex="5" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_clte" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="6" PageSize="5" OnPageIndexChanging="gv_clte_PageIndexChanging" OnRowDataBound="gv_clte_RowDataBound" OnRowCommand="gv_clte_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_ID" HeaderText="ID" SortExpression="clte_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="cod_clte" HeaderText="ID" SortExpression="cod_clte" Visible="true" />
                                                                <asp:BoundField DataField="razon_social" HeaderText="RAZÓN SOCIAL" SortExpression="razon_social" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_clte_estatus" runat="server" OnSelectedIndexChanged="ddl_clte_estatus_SelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_infusr" runat="server" Text="ver" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_clte_f" visible="false">
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_trfc_clte_fisc" runat="server" Text="*Tipo RFC"></asp:Label>
                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_trfc_clte_fisc" runat="server" TabIndex="7" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_trfc_clte_fisc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_trfc_clte_fisc" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_rfc_clte_fisc" runat="server" Text="*RFC"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box text-uppercase" ID="txt_rfc_clte_fisc" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="8"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                        ErrorMessage="Formato Invalido" ControlToValidate="txt_rfc_clte_fisc"
                                                                        ValidationExpression="[A-ZÑ&|a-zñ&]{3,4}\d{6}[A-V1-9|a-v1-9][A-Z1-9|a-z1-9][0-9A|0-9a]" ForeColor="DarkRed">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfv_rfc_clte_fisc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_rfc_clte_fisc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_rs" runat="server" Text="*Razón Social"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_rs" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_rs" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_rs" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_telefono_clte" runat="server" Text="Teléfono"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_telefono_clte" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9, una x y enseguida 5 0, demas un / y enseguida 5 0" TabIndex="10"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RegularExpressionValidator ID="revPhone" runat="server"
                                                                        ErrorMessage="Formato Invalido" ControlToValidate="txt_telefono_clte"
                                                                        ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                                    </asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_email_clte" runat="server" Text="e-mail"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_email_clte" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="11"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_callenum_clte" runat="server" Text="*Calle ý número"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_callenum_clte" runat="server" placeholder="letras/números" ToolTip="letras/números" TextMode="MultiLine" BackColor="LightGray" ForeColor="#104D8D" TabIndex="12"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_callenum_clte" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_callenum_clte" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_cp_clte" runat="server" Text="*Código Postal"></asp:Label>
                                                                <div class="input-group">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cp_clte" runat="server" placeholder="5 números (0-9)" MaxLength="5" ToolTip="Un código postal valido consiste en 5 numeros con valores del 0-9" TabIndex="13"></asp:TextBox>
                                                                    <ajaxToolkit:MaskedEditExtender ID="mee_cp_clte" runat="server" TargetControlID="txt_cp_clte" Mask="99999" />
                                                                    <span class="input-group-btn">
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_cp_clte" runat="server" Text="Ir" OnClick="btn_cp_clte_Click" TabIndex="14" />
                                                                    </span>
                                                                </div>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_cp_clte" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cp_clte" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_colonia_clte" runat="server" Text="*Colonia"></asp:Label>
                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_colonia_clte" runat="server" TabIndex="15" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_colonia_clte" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_colonia_clte" InitialValue="0" ForeColor="DarkRed" Enabled="false" TabIndex="14"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_municipio_clte" runat="server" Text="Municipio"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_municipio_clte" runat="server" placeholder="letras/números" Enabled="false" BackColor="LightGray" TabIndex="16"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_estado_clte" runat="server" Text="Estado"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_estado_clte" runat="server" placeholder="letras/números" Enabled="false" BackColor="LightGray" TabIndex="17"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_coment" runat="server" Text="Comentarios"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_coment" runat="server" placeholder="letras/números" TextMode="MultiLine" Enabled="false" BackColor="LightGray" ForeColor="#104D8D" TabIndex="18"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_coment" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_coment" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="text-right">
                                                                <br />
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_guardar_clte" runat="server" Text="GUARDAR" OnClick="btn_guardar_clte_Click" TabIndex="19" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_clte_contacto" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12 ">
                                    <div class="row">
                                        <div class="panel panel-default" id="div_nav_clte_cont" runat="server" visible="false">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-9 col-sm-9">
                                                        <div class="input-group" id="div_busc_clte_contacto" runat="server" visible="true">
                                                            <span class="input-group-addon">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_clte_contacto" runat="server" Text="*Buscar Cliente:"></asp:Label>
                                                            </span>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_clte_contacto" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_buscar_clte_contacto" runat="server" Text="Ir" TabIndex="2" OnClick="btn_buscar_clte_contacto_Click" />
                                                            </span>
                                                        </div>
                                                        <div class="text-right">
                                                            <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_clte_contacto" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_clte_contacto" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                            <asp:RequiredFieldValidator ID="rfv_buscar_clte_contacto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_clte_contacto" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <p class="text-right">
                                                            Contacto
                      <span>
                          <asp:LinkButton CssClass="btn btn-warning" ID="btn_clte_contacto_agregar" runat="server" ToolTip="AGREGAR CONTACTO" TabIndex="3" OnClick="btn_clte_contacto_agregar_Click">
                              <i class="fas fa-plus" id="i_clte_contacto_agregar" runat="server"></i>
                          </asp:LinkButton>
                          <asp:LinkButton CssClass="btn btn-warning" ID="btn_clte_contacto_editar" runat="server" ToolTip="EDITAR CONTACTO" TabIndex="4" OnClick="btn_clte_contacto_editar_Click">
                              <i class="far fa-edit" id="i_clte_contacto_editar" runat="server"></i>
                          </asp:LinkButton>
                      </span>
                                                            <br />
                                                            <asp:CheckBox ID="chkb_desactivar_clte_contacto" runat="server" AutoPostBack="true" Text=" Limpiar" TabIndex="5" OnCheckedChanged="chkb_desactivar_clte_contacto_CheckedChanged" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_cltef" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="6" PageSize="5" OnRowDataBound="gv_cltef_RowDataBound" OnPageIndexChanging="gv_cltef_PageIndexChanging" OnRowCommand="gv_cltef_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_ID" HeaderText="ID" SortExpression="clte_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="cod_clte" HeaderText="ID" SortExpression="cod_clte" Visible="true" />
                                                                <asp:BoundField DataField="razon_social" HeaderText="RAZÓN SOCIAL" SortExpression="razon_social" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_cltef_estatus" runat="server" AutoPostBack="true" Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_infusr" runat="server" Text="Contacto" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_cltef_cont" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="6" PageSize="5" OnRowCommand="gv_cltef_cont_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_contacto_ID" HeaderText="ID" SortExpression="clte_contacto_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="dpto" HeaderText="Departamento" SortExpression="dpto" />
                                                                <asp:BoundField DataField="contacto_nom" HeaderText="Contacto" SortExpression="contacto_nom" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_infcont" runat="server" Text="Ver" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_clte_contactof" visible="false">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto_dpto" runat="server" Text="*Departamento"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto_dpto" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_contacto_dpto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_contacto_dpto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto" runat="server" Text="*Contacto"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_contacto" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_contacto" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto_tel1" runat="server" Text="*Teléfono"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto_tel1" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9" TabIndex="10"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RegularExpressionValidator ID="rev_clte_contacto_tel1" runat="server"
                                                                        ErrorMessage="Formato Invalido" ControlToValidate="txt_clte_contacto_tel1"
                                                                        ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                                    </asp:RegularExpressionValidator>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_clte_contacto_tel1" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_contacto_tel1" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto_tel2" runat="server" Text="Teléfono Alterno"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto_tel2" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9" TabIndex="10"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RegularExpressionValidator ID="rev_clte_contacto_tel2" runat="server"
                                                                        ErrorMessage="Formato Invalido" ControlToValidate="txt_clte_contacto_tel2"
                                                                        ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                                    </asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto_email1" runat="server" Text="*e-mail"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto_email1" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="11"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_contacto_email1" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_contacto_email1" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contacto_email2" runat="server" Text="e-mail Alterno"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contacto_email2" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="11"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                            <div class="form-group text-left">
                                                                <div class="text-right">
                                                                    <br />
                                                                    <asp:Button CssClass="btn btn-warning" ID="btn_clte_contacto_guardar" runat="server" Text="GUARDAR" TabIndex="18" OnClick="btn_clte_contacto_guardar_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_clte_obras" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12 ">
                                    <div class="row">
                                        <div class="panel panel-default" id="div_nav_clte_obras" runat="server" visible="false">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-8 col-sm-8">
                                                        <div class="input-group">
                                                            <span class="input-group-addon">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_clte_obras" runat="server" Text="*Buscar Cliente:"></asp:Label>
                                                            </span>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_clte_obras" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_buscar_clte_obras" runat="server" Text="Ir" TabIndex="2" OnClick="btn_buscar_clte_obras_Click" />
                                                            </span>
                                                            <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_clte_obras" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_clte_obras" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                        </div>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_buscar_clte_obras" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_clte_obras" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4">
                                                        <p class="text-right">
                                                            OBRAS
                                                        <span>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_agregar_clte_obras" runat="server" ToolTip="AGREGAR OBRA" OnClick="btn_agregar_clte_obras_Click" TabIndex="2">
                                                                <i class="fas fa-plus" id="i_agregar_clte_obras" runat="server"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn btn-warning" ID="btn_editar_clte_obras" runat="server" ToolTip="EDITAR OBRA" OnClick="btn_editar_clte_obras_Click" TabIndex="3">
                                                                <i class="far fa-edit" id="i_editar_clte_obras" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                            <br />
                                                            <asp:CheckBox ID="chkb_desactivar_clte_obras" runat="server" AutoPostBack="true" Text="Limpiar" OnCheckedChanged="chkb_desactivar_clte_obras_CheckedChanged" TabIndex="4" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_clte_obras" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="6" PageSize="5" OnPageIndexChanging="gv_clte_obras_PageIndexChanging" OnRowDataBound="gv_clte_obras_RowDataBound" OnRowCommand="gv_clte_obras_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_ID" HeaderText="ID" SortExpression="clte_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="cod_clte" HeaderText="ID" SortExpression="cod_clte" Visible="true" />
                                                                <asp:BoundField DataField="razon_social" HeaderText="RAZÓN SOCIAL" SortExpression="razon_social" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_clteobra_estatus" runat="server" Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_infusr" runat="server" Text="Obras" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_clte_obrasf" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="5" OnRowDataBound="gv_clte_obrasf_RowDataBound" OnRowCommand="gv_clte_obrasf_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_obras_ID" HeaderText="ID" SortExpression="clte_obras_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="clave_obra" HeaderText="CLAVE" SortExpression="clave_obra" Visible="true" />
                                                                <asp:BoundField DataField="desc_obra" HeaderText="DESCRIPCIÓN" SortExpression="desc_obra" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_clteobra_estatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_clteobra_estatus_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_clte_obrasf" runat="server" Text="ver" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_obras_rpt" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="5" OnRowDataBound="gv_obras_rpt_RowDataBound" OnRowCommand="gv_obras_rpt_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_obra_rpt_ID" HeaderText="ID" SortExpression="clte_obra_rpt_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="nombre_archivo" HeaderText="# REPORTE" SortExpression="nombre_archivo" Visible="true" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_clteobrarpt_est" runat="server" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_clte_obrasf" runat="server" Text="ver" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_clte_obrasf" visible="false">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_clave_obra" runat="server" Text="*Clave de Obra"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_clave_obra" runat="server" placeholder="letras/números" ToolTip="Una clave de obra valida se conforma de dos letras A hasta Z, un guión (-), y dos números del 0 al 9, sin espacios" TabIndex="6"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                        ErrorMessage="Formato Invalido" ControlToValidate="txt_clte_clave_obra"
                                                                        ValidationExpression="[a-zA-Z]{2}[-][0-9]{2}" ForeColor="DarkRed">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_clave_obra" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_clave_obra" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_desc_obra" runat="server" Text="*Nombre de Obra"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_desc_obra" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="7" TextMode="MultiLine" BackColor="LightGray" ForeColor="#104D8D"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_desc_obra" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_desc_obra" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_tservicio" runat="server" Text="*Tipo de Servicio"></asp:Label>
                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_clte_tservicio" runat="server" TabIndex="8" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_tservicio" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_clte_tservicio" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_coordinador" runat="server" Text="*Coordinador"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_coordinador" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="9" BackColor="LightGray" ForeColor="#104D8D"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_coordinador" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_coordinador" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_clte_contobra" runat="server" Text="*Con atención:"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_clte_contobra" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="10" TextMode="MultiLine" BackColor="LightGray" ForeColor="#104D8D"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_clte_contobra" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clte_contobra" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_coment_obras" runat="server" Text="Comentarios"></asp:Label>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_coment_obras" runat="server" placeholder="letras/números" TextMode="MultiLine" Enabled="false" BackColor="LightGray" ForeColor="#104D8D" TabIndex="11"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_coment_obras" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_coment_obras" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group text-left">
                                                                    <div class="text-right">
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_clte_obras_rpt" runat="server" Text="Cargar Reportes" TabIndex="12" OnClick="btn_clte_obras_rpt_Click" />
                                                                        <asp:Button CssClass="btn btn-warning" ID="btn_guardar_clte_obras" runat="server" Text="GUARDAR" TabIndex="12" OnClick="btn_guardar_clte_obras_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_clte_obras_rpt" visible="false">
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="Label1" runat="server" Text="*Tipo de Reporte"></asp:Label>
                                                                <asp:DropDownList CssClass="form-control input-box" ID="DropDownList1" runat="server" TabIndex="7" BackColor="LightGray" ForeColor="#104D8D"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 center-block">

                                                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1"
                                                                ThrobberID="myThrobber"
                                                                ContextKeys="fred"
                                                                AllowedFileTypes="pdf"
                                                                MaximumNumberOfFiles="10"
                                                                runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" OnUploadCompleteAll="AjaxFileUpload1_UploadCompleteAll" OnUploadStart="AjaxFileUpload1_UploadStart" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_rppc" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12 ">
                                    <div class="row">
                                        <div class="panel panel-default" id="div_nav_obras_rpc" runat="server" visible="false">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-10 col-sm-10">
                                                        <div class="input-group" id="div_rppc" runat="server" visible="true">
                                                            <span class="input-group-addon">
                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_rppc" runat="server" Text="*BUSCAR OBRA:"></asp:Label>
                                                            </span>
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_rppc" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_buscar_rppc" runat="server" Text="Ir" TabIndex="2" OnClick="btn_buscar_rppc_Click" />
                                                            </span>
                                                            <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_rppc" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_rppc" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                        </div>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_buscar_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_rppc" ForeColor="white" Enabled="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2 col-sm-2">
                                                        <p class="text-right">

                                                            <span>
                                                                <asp:LinkButton CssClass="btn btn-warning" ID="btn_agregar_rppc" runat="server" ToolTip="AGREGAR MUESTRA" OnClick="btn_agregar_rppc_Click" TabIndex="3">
                                                                    <i class="fas fa-plus" id="i_agregar_rppc" runat="server"></i>
                                                                </asp:LinkButton>
                                                                <asp:LinkButton CssClass="btn btn-warning" ID="btn_editar_rppc" runat="server" ToolTip="EDITAR MUESTRA" OnClick="btn_editar_rppc_Click" TabIndex="4">
                                                                    <i class="far fa-edit" id="i_editar_rppc" runat="server"></i>
                                                                </asp:LinkButton>
                                                            </span>
                                                            <br />
                                                            <asp:CheckBox ID="chkb_desactivar_rppc" runat="server" AutoPostBack="true" Text="Limpiar" OnCheckedChanged="chkb_desactivar_rppc_CheckedChanged" TabIndex="5" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_obra_clte" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="5" OnRowCommand="gv_obra_clte_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:BoundField DataField="clte_obras_ID" HeaderText="ID" SortExpression="clte_obras_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="clave_obra" HeaderText="CLAVE" SortExpression="clave_obra" Visible="true" />
                                                                <asp:BoundField DataField="cod_clte" HeaderText="CÓDIGO CLIENTE" SortExpression="cod_clte" Visible="true" />
                                                                <asp:BoundField DataField="razon_social" HeaderText="CLIENTE" SortExpression="razon_social" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" CommandName="btn_recepcion" runat="server" Text="Recepción" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <p class="text-left">
                                                            <div class="input-group" id="div_rpc" runat="server" visible="false">
                                                                <span class="input-group-addon">
                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_rpc" runat="server" Text="*BUSCAR # MUESTRA:"></asp:Label>
                                                                </span>
                                                                <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_rpc" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="6"></asp:TextBox>
                                                                <span class="input-group-btn">
                                                                    <asp:Button CssClass="btn btn-warning" ID="btn_buscar_rpc" runat="server" Text="Ir" OnClick="btn_buscar_rpc_Click" TabIndex="7" />
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_rpc" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_rpc" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                                <asp:RequiredFieldValidator ID="rfv_buscar_rpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_rpc" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <asp:GridView CssClass="table" ID="gv_rppc" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" PageSize="5" ForeColor="#333333" GridLines="None" TabIndex="8" OnPageIndexChanging="gv_rppc_PageIndexChanging" OnRowDataBound="gv_rppc_RowDataBound" OnRowCommand="gv_rppc_RowCommand">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                 <asp:BoundField DataField="concreto_rpc_ID" HeaderText="ID" SortExpression="concreto_rpc_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                                <asp:BoundField DataField="concreto_est_muestra" HeaderText="# MUESTRA" SortExpression="concreto_est_muestra" Visible="true" />
                                                                <asp:BoundField DataField="fecha_colado" HeaderText="FECHA  DE COLADO" SortExpression="fecha_colado" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                                <asp:TemplateField HeaderText="ESTATUS">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_rppc_est" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_rppc_est_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Button CssClass="btn btn-warning" CommandName="btn_recepcion" runat="server" Text="Programación" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                                            <HeaderStyle BackColor="#104D8d" ForeColor="White" />
                                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_docf" visible="false">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_nmue_rppc" runat="server" Text="*No. de Muestra:"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="nmue_rppc" runat="server" placeholder="letras/números" TabIndex="9"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_nmue_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="nmue_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_fcol_rppc" runat="server" Text="*Colado"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="fcol_rppc" runat="server" TextMode="Date" TabIndex="10"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_fcol_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="fcol_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">

                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_frec_rppc" runat="server" Text="Recepción"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="frec_rppc" runat="server" TextMode="Date" TabIndex="11"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_frec_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="frec_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_entrega_rppc" runat="server" Text="Entrega"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="entrega_rppc" runat="server" placeholder="letras/números" TabIndex="12"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_entrega_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="entrega_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_recibe_rppc" runat="server" Text="Recibe"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="recibe_rppc" runat="server" placeholder="letras/números" TabIndex="13"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_recibe_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="recibe_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_r_rppc" runat="server" Text="f’c=kgf/cm²"></asp:Label>

                                                                <asp:TextBox CssClass="form-control input-box" ID="r_rppc" runat="server" placeholder="[0-9]" TabIndex="14"></asp:TextBox>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_r_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="r_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_tesp_rppc" runat="server" Text="Tipo de Especímen"></asp:Label>

                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_tesp_rppc" runat="server" AutoPostBack="true" BackColor="LightGray" ForeColor="#104D8D" TabIndex="15"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_tesp_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_tesp_rppc" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_tconc_rppc" runat="server" Text="Tipo de Concreto (N,RR,RT,UR)"></asp:Label>

                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_tconc_rppc" runat="server" AutoPostBack="true" BackColor="LightGray" ForeColor="#104D8D" TabIndex="16"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_tconc_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_tconc_rppc" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group text-left">

                                                                <asp:Label CssClass="control-label fuente_css02" ID="lbl_sit_rppc" runat="server" Text="Situación (Documento)"></asp:Label>

                                                                <asp:DropDownList CssClass="form-control input-box" ID="ddl_sit_rppc" runat="server" AutoPostBack="true" BackColor="LightGray" ForeColor="#104D8D" OnSelectedIndexChanged="ddl_sit_rppc_SelectedIndexChanged" TabIndex="17"></asp:DropDownList>
                                                                <div class="text-right">
                                                                    <asp:RequiredFieldValidator ID="rfv_sit_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="ddl_sit_rppc" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="div_doc" visible="false">
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_proce_rppc" runat="server" Text="*Procedencia:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_proce_rppc" runat="server" placeholder="letras/números" TabIndex="18"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_proce_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_proce_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_elem_rppc" runat="server" Text="*Elemento:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_elem_rppc" runat="server" placeholder="letras/números" TabIndex="19"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_elem_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_elem_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_dosi_rppc" runat="server" Text="*Dosificación:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_dosi_rppc" runat="server" placeholder="letras/números" TabIndex="20"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_dosi_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_dosi_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_resis_rppc" runat="server" Text="*Resistencia:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_resis_rppc" runat="server" placeholder="letras/números" TabIndex="21"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_resis_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_resis_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_clase_rppc" runat="server" Text="*Clase:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_clase_rppc" runat="server" placeholder="letras/números" TabIndex="22"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_clase_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_clase_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_rev_rrpc" runat="server" Text="*REV. cm:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_rev_rrpc" runat="server" placeholder="letras/números" TabIndex="23"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_rev_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_rev_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_tma_rrpc" runat="server" Text="*T.M.A. mm:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_tma_rrpc" runat="server" placeholder="letras/números" TabIndex="24"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_tma_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_tma_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_olla_rrpc" runat="server" Text="*OLLA:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_olla_rrpc" runat="server" placeholder="letras/números" TabIndex="25"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_olla_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_olla_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_remi_rppc" runat="server" Text="*Remisión:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_remi_rppc" runat="server" placeholder="letras/números" TabIndex="26"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_remi_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_remi_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_splata_rrpc" runat="server" Text="*Salida planta:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_splata_rrpc" runat="server" placeholder="letras/números" TextMode="Time" TabIndex="27"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_splata_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_splata_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_llobra_rrpc" runat="server" Text="*Llegada a obra:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_llobra_rrpc" runat="server" placeholder="letras/números" TextMode="Time" TabIndex="28"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_llobra_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_llobra_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_inic_rrpc" runat="server" Text="*Descarga Inicia:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_inic_rrpc" runat="server" placeholder="letras/números" TextMode="Time" TabIndex="29"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfvl_inic_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_inic_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_term_rrpc" runat="server" Text="*Descarga Termina:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_term_rrpc" runat="server" placeholder="letras/números" TextMode="Time" TabIndex="30"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_term_rrpc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_term_rrpc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_vol_rppc" runat="server" Text="*VOL m3:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_vol_rppc" runat="server" placeholder="letras/números" TabIndex="31"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_vol_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_vol_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_revb_rppc" runat="server" Text="*REV. cm:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_revb_rppc" runat="server" placeholder="letras/números" TabIndex="32"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_revb_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_revb_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="form-group text-left">

                                                                    <asp:Label CssClass="control-label fuente_css02" ID="lbl_loca_rppc" runat="server" Text="*Localización:"></asp:Label>

                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_loca_rppc" runat="server" placeholder="letras/números" TextMode="MultiLine" TabIndex="33"></asp:TextBox>
                                                                    <div class="text-right">
                                                                        <asp:RequiredFieldValidator ID="rfv_loca_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_loca_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_pfe" visible="false">
                                                    <div class="row">
                                                        <h4 class="text-center">Programación fechas de ensaye</h4>
                                                        <br />
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_fmaxe" runat="server" Text=""></asp:Label>
                                                        <div class="col-lg-6">

                                                            <div class="input-group">
                                                                <span class="input-group-addon text-left">
                                                                    <asp:CheckBox ID="chkb_1_rppc" runat="server" AutoPostBack="true" Text="1 Día : " OnCheckedChanged="chkb_1_rppc_CheckedChanged" TabIndex="34" />
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cant1_rppc" runat="server" TextMode="Number" TabIndex="35"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_f1_rppc" runat="server" TextMode="Date" TabIndex="36" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_f1_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cant1_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvf1_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cant1_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                            <div class="input-group">
                                                                <span class="input-group-addon">

                                                                    <asp:CheckBox ID="chkb_3_rppc" runat="server" AutoPostBack="true" Text="3 Días:" OnCheckedChanged="chkb_3_rppc_CheckedChanged" TabIndex="37" />
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cant3_rppc" runat="server" TextMode="Number" TabIndex="38"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_f3_rppc" runat="server" TextMode="Date" TabIndex="39" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_f3_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cant3_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvf3_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cant3_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                            <div class="input-group">
                                                                <span class="input-group-addon">

                                                                    <asp:CheckBox ID="chkb_7_rppc" runat="server" AutoPostBack="true" Text="7 Días:" OnCheckedChanged="chkb_7_rppc_CheckedChanged" TabIndex="40" />
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cant7_rppc" runat="server" TextMode="Number" TabIndex="41"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_f7_rppc" runat="server" TextMode="Date" TabIndex="42" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_f7_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cant7_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvf7_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cant7_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">

                                                            <div class="input-group">
                                                                <span class="input-group-addon">
                                                                    <asp:CheckBox ID="chkb_14_rppc" runat="server" AutoPostBack="true" Text="14 Días:" OnCheckedChanged="chkb_14_rppc_CheckedChanged" TabIndex="43" />
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cant14_rppc" runat="server" TextMode="Number" TabIndex="44"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_f14_rppc" runat="server" TextMode="Date" TabIndex="45" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_f14_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cant14_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvf14_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cant14_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                            <div class="input-group">
                                                                <span class="input-group-addon">

                                                                    <asp:CheckBox ID="chkb_28_rppc" runat="server" AutoPostBack="true" Text="28 Días:" OnCheckedChanged="chkb_28_rppc_CheckedChanged" TabIndex="46" />
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cant28_rppc" runat="server" TextMode="Number" TabIndex="47"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_f28_rppc" runat="server" TextMode="Date" TabIndex="48" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_f28_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cant28_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvf28_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cant28_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                            <div class="input-group">
                                                                <span class="input-group-addon">

                                                                    <asp:CheckBox ID="chkb_otro_rppc" runat="server" AutoPostBack="true" Text="Otro     : " OnCheckedChanged="chkb_otro_rppc_CheckedChanged" TabIndex="49" />
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cantotro_rppc" runat="server" TextMode="Number" TabIndex="50"></asp:TextBox>
                                                                </span>
                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_cantesp_rppc" runat="server" TextMode="Number" TabIndex="51"></asp:TextBox>
                                                                </span>

                                                                <span class="input-group-addon">
                                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_fotro_rppc" runat="server" TextMode="Date" TabIndex="52" Enabled="false"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                            <div class="text-right">
                                                                <asp:RequiredFieldValidator ID="rfv_cantotro_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cantotro_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator ID="rfv_cantesp_rppc" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_cantesp_rppc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvfotro_rppc" ErrorMessage="Solo se permite dos valores 1/2." ForeColor="DarkRed" ControlToValidate="txt_cantesp_rppc" MinimumValue="1" MaximumValue="2" runat="server" Type="Integer" Enabled="false"></asp:RangeValidator>
                                                            </div>
                                                            <br />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-right">
                                                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar_rppc" runat="server" Text="GUARDAR" TabIndex="53" Visible="false" OnClick="btn_guardar_rppc_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_concreto" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12 ">
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_ensaye" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-10">
                                <div class="col-lg-12 ">
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header encabezado001">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><i class="fa fa-window-close-o"></i></button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label CssClass="fuente_css02" ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-warning" data-dismiss="modal" aria-hidden="true">OK <i class="fa fa-check-circle-o"></i></button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="modal" id="myModal_pdf" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <asp:UpdatePanel ID="up_pdf" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body text-center">

                                <iframe id="iframe_pdf" src="" width="600" height="500" runat="server" visible="false"></iframe>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-success" data-dismiss="modal" aria-hidden="true">Ok</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>