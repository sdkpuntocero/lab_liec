<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pnl_recursos_humanos.aspx.cs" Inherits="lab_liec.pnl_recursos_humanos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

    <link href="styles/style_liec.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>

    <link rel="shortcut icon" href="img/ico_liec.png" type="image/png" />
    <title>/ RH </title>
</head>
<body>
    <script>
        function CheckOne(obj) {
            var grid = obj.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="up_gastos_bienvenida" runat="server" UpdateMode="Conditional">
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
                <asp:UpdatePanel ID="up_gastos_menu" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-lg-2">
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
                                                    <asp:LinkButton CssClass="fuente_css02" ID="lkb_usr_admin" runat="server" OnClick="lkb_usr_admin_Click" ToolTip="Usuarios">
                                                        
                                                        <asp:Label CssClass="buttonClass" ID="lbl_usr_admin" runat="server" Text="Usuarios"></asp:Label>
                                                        <i class="fas fa-user-cog" id="i_usr_admin" runat="server" ></i>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton CssClass="fuente_css02" ID="lkb_usr_med" runat="server" OnClick="lkb_usr_med_Click">
                                                     
                                                        <asp:Label CssClass="buttonClass" ID="lbl_usr_med" runat="server" Text="Médicos"></asp:Label>
                                                           <i class="fas fa-user-md" id="i_usr_med" runat="server"></i>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton CssClass="fuente_css02" ID="lkb_usr_banc" runat="server" OnClick="lkb_usr_banc_Click">
                                                        
                                                        <asp:Label CssClass="buttonClass" ID="lbl_usr_banc" runat="server" Text="Bancarios"></asp:Label>
                                                        <i class="fas fa-money-check-alt" id="i_usr_banc" runat="server"></i>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton CssClass="fuente_css02" ID="LinkButton1" runat="server">
                                            
                                                        <asp:Label CssClass="buttonClass" ID="Label1" runat="server" Text="Escolares"></asp:Label>
                                                                    <i class="fas fa-user-graduate" id="i2" runat="server"></i>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton CssClass="fuente_css02" ID="lkb_usr_cap" runat="server" OnClick="lkb_usr_cap_Click">
                                    
                                                        <asp:Label CssClass="buttonClass" ID="lbl_usr_cap" runat="server" Text="Capacitación"></asp:Label>
                                                                            <i class="fas fa-user-graduate" id="i_usr_cap" runat="server"></i>
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
                                <!--/.nav-collapse -->
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="up_usrs" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <br />
                        <div class="col-lg-9">
                            <div class="col-lg-12 ">
                                <div class="panel panel-default" id="pnl_usrs" runat="server" visible="false">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <div class="col-md-9 col-sm-9">
                                                <div class="input-group" id="div_busc_usr" runat="server" visible="false">
                                                    <span class="input-group-addon">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_usr" runat="server" Text="*Buscar Usuario:"></asp:Label>
                                                    </span>
                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_usr" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn btn01" ID="btn_buscar_usr" runat="server" Text="ACEPTAR" OnClick="btn_buscar_usr_Click" TabIndex="2" />
                                                    </span>
                                                </div>
                                                <div class="text-right">
                                                    <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_usr" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_usr" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                    <asp:RequiredFieldValidator ID="rfv_buscar_usr" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_usr" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <p class="text-right">
                                                    USUARIOS
                                                        <span>
                                                            <asp:LinkButton CssClass="btn btn02" ID="btn_usr_agregar" runat="server" ToolTip="AGREGAR USUARIO" OnClick="btn_usr_agregar_Click" TabIndex="3">
                                                                <i class="fas fa-plus" id="i_usr_agregar" runat="server"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn btn02" ID="btn_usr_editar" runat="server" ToolTip="EDITAR USUARIO" OnClick="btn_usr_editar_Click" TabIndex="4">
                                                                <i class="far fa-edit" id="i_usr_editar" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    <br />
                                                    <asp:CheckBox ID="chkb_usr_desact" runat="server" AutoPostBack="true" Text=" Limpiar" OnCheckedChanged="chkb_usr_desact_CheckedChanged" TabIndex="5" />
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <asp:GridView CssClass="table" ID="gv_usrs" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="5" PageSize="5" OnRowDataBound="gv_usrs_RowDataBound" OnRowCommand="gv_usrs_RowCommand" OnPageIndexChanging="gv_usrs_PageIndexChanging">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>

                                                        <asp:BoundField DataField="usuario_ID" HeaderText="ID" SortExpression="usuario_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                        <asp:BoundField DataField="cod_usr" HeaderText="ID" SortExpression="cod_usr" Visible="true" />
                                                        <asp:BoundField DataField="nom_comp" HeaderText="NOMBRE COMPLETO" SortExpression="nom_comp" />
                                                        <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                        <asp:TemplateField HeaderText="ESTATUS">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddl_usr_estatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_usr_estatus_SelectedIndexChanged">
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
                                        <div runat="server" id="div_usr_f">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_area" runat="server" Text="Áreas"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_area" runat="server" TabIndex="6"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_area" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_area" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_perfil" runat="server" Text="Perfil"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_perfil" runat="server" TabIndex="7"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_perfil" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_perfil" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_responsable" runat="server" Text="Responsable"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_responsable" runat="server" TabIndex="8"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_responsable" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_responsable" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_genero" runat="server" Text="Género"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_genero" runat="server" TabIndex="9"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_genero" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_genero" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_nombres" runat="server" Text="*Nombre"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_nombres" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="10"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_nombres" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_nombres" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_apaterno" runat="server" Text="*Apellido Materno"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_apaterno" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="11"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_apaterno" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_apaterno" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_amaterno" runat="server" Text="*Apellido Materno"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_amaterno" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="12"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_amaterno" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_amaterno" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_fnac" runat="server" Text="Cumpleaños"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_fnac" runat="server" placeholder="letras/números" ToolTip="letras/números" TextMode="Date" TabIndex="13"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_fnac" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_fnac" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_fing" runat="server" Text="Ingreso"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_fing" runat="server" placeholder="letras/números" ToolTip="letras/números" TextMode="Date" TabIndex="14"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_fing" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_fing" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_estciv" runat="server" Text="Estado Civil"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_estciv" runat="server" TabIndex="15"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_estciv" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_estciv" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_hijos" runat="server" Text="Hijos"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_hijos" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="16" Text="0" TextMode="Number"></asp:TextBox>
                                                        <ajaxToolkit:MaskedEditExtender ID="mee_usr_hijos" runat="server" TargetControlID="txt_usr_hijos" Mask="99" />
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_hijos" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_hijos" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_nss" runat="server" Text="NSS"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_nss" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="17"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_nss" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_nss" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_curp" runat="server" Text="CURP"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_curp" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="18"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_curp" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_curp" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_licencia" runat="server" Text="Licencia"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_licencia" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="19"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_licencia" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_licencia" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_rfc" runat="server" Text="RFC"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_rfc" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="20"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_rfc" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_rfc" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbk_usr_tel" runat="server" Text="Teléfono"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_tel" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9, una x y enseguida 5 0, demas un / y enseguida 5 0" TabIndex="21"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RegularExpressionValidator ID="rfv_usr_tel" runat="server"
                                                                ErrorMessage="Formato Invalido" ControlToValidate="txt_usr_tel"
                                                                ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbk_usr_telalt" runat="server" Text="Teléfono Alterno"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_telalt" runat="server" MaxLength="30" placeholder="000-000-00000000x00000/00000" TextMode="Phone" ToolTip="Un número de teléfono válido consiste en un código de lada de 3 dígitos, un guión (-),un código de área de 3 dígitos, un guión (-) y el número telefónico con valores del 0 al 9, una x y enseguida 5 0, demas un / y enseguida 5 0" TabIndex="22"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RegularExpressionValidator ID="rfv_usr_telalt" runat="server"
                                                                ErrorMessage="Formato Invalido" ControlToValidate="txt_usr_telalt"
                                                                ValidationExpression="[0-9]{3}[-][0-9]{3}[-][0-9]{8}[x][0-9]{5}[/][0-9]{5}" ForeColor="DarkRed">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_email" runat="server" Text="Correo electrónico"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_email" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="23"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_emailalt" runat="server" Text="Correo electrónico Alterno"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_emailalt" runat="server" placeholder="xxxx@xxxx.xxx" TextMode="Email" ToolTip="xxxx@xxxx.xxx" TabIndex="24"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_callenum" runat="server" Text="*Calle ý número"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_callenum" runat="server" placeholder="letras/numeros" ToolTip="letras/numeros" TextMode="MultiLine" TabIndex="25"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_callenum" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_callenum" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_cp" runat="server" Text="*Código Postal"></asp:Label>
                                                        <div class="input-group">
                                                            <asp:TextBox CssClass="form-control input-box" ID="txt_usr_cp" runat="server" placeholder="5[0-9]" MaxLength="5" ToolTip="Un código postal valido consiste en 5 numeros con valores del 0-9" TabIndex="26"></asp:TextBox>
                                                            <ajaxToolkit:MaskedEditExtender ID="mee_usr_cp" runat="server" TargetControlID="txt_usr_cp" Mask="99999" />
                                                            <span class="input-group-btn">
                                                                <asp:Button CssClass="btn btn02" ID="btn_usr_cp" runat="server" Text="VALIDAR" TabIndex="27" OnClick="btn_usr_cp_Click" />
                                                            </span>
                                                        </div>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_cp" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_cp" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">

                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_col" runat="server" Text="*Colonia"></asp:Label>

                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_col" runat="server" TabIndex="28"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_col_usr" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_col" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">

                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_municipio" runat="server" Text="Municipio"></asp:Label>

                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_municipio" runat="server" placeholder="letras/numeros" Enabled="false"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">

                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_estado" runat="server" Text="Estado"></asp:Label>

                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_estado" runat="server" placeholder="letras/numeros" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_coment" runat="server" Text="Comentarios"></asp:Label>

                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_coment" runat="server" placeholder="letras/números" TextMode="MultiLine" Enabled="false" TabIndex="29"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_coment" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_coment" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_cod" runat="server" Text="Usuario"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_cod" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="30" Enabled="false"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_cod" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_cod" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_clave" runat="server" Text="Contraseña"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_clave" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="31" Enabled="false" TextMode="Password"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_clave" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_clave" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_emailcorp" runat="server" Text="Correo corporativo"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_emailcorp" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="32" Enabled="false"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_emailcorp" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_emailcorp" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="text-right">
                                                        <asp:Button CssClass="btn btn02" ID="btn_usr_guardar" runat="server" Text="GUARDAR" TabIndex="33" OnClick="btn_usr_guardar_Click" />
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
                <asp:UpdatePanel ID="up_usr_med" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-lg-9">
                            <div class="col-lg-12 ">
                                <div class="panel panel-default" id="pnl_usr_med" runat="server" visible="false">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <div class="col-md-9 col-sm-9">
                                                <div class="input-group" id="div_busc_usr_med" runat="server" visible="false">
                                                    <span class="input-group-addon">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_buscar_usr_med" runat="server" Text="*Buscar Usuario:"></asp:Label>
                                                    </span>
                                                    <asp:TextBox CssClass="form-control input-box" ID="txt_buscar_usr_med" runat="server" placeholder="letras/números" TextMode="Search" TabIndex="1"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn btn01" ID="btn_buscar_usr_med" runat="server" Text="ACEPTAR" OnClick="btn_buscar_usr_med_Click" TabIndex="2" />
                                                    </span>
                                                </div>
                                                <div class="text-right">
                                                    <ajaxToolkit:AutoCompleteExtender ID="ace_buscar_usr_med" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="txt_buscar_usr_med" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                    <asp:RequiredFieldValidator ID="rfv_buscar_usr_med" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txt_buscar_usr_med" ForeColor="white" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <p class="text-right">
                                                    Médicos
                                                        <span>
                                                            <asp:LinkButton CssClass="btn btn02" ID="btn_usr_med_agregar" runat="server" ToolTip="AGREGAR DATOS" OnClick="btn_usr_med_agregar_Click" TabIndex="3">
                                                                <i class="fas fa-plus" id="i_usr_med_agregar" runat="server"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn btn02" ID="btn_usr_med_editar" runat="server" ToolTip="EDITAR DATOS" OnClick="btn_usr_med_editar_Click" TabIndex="4">
                                                                <i class="far fa-edit" id="i_usr_med_editar" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    <br />
                                                    <asp:CheckBox ID="chkb_usr_med_desact" runat="server" AutoPostBack="true" Text=" Limpiar" TabIndex="5" OnCheckedChanged="chkb_usr_med_desact_CheckedChanged" />
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <asp:GridView CssClass="table" ID="gv_usr_med" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" TabIndex="5" PageSize="5" OnRowDataBound="gv_user_med_RowDataBound" OnRowCommand="gv_user_med_RowCommand" OnPageIndexChanging="gv_user_med_PageIndexChanging">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundField DataField="usuario_ID" HeaderText="ID" SortExpression="usuario_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                        <asp:BoundField DataField="cod_usr" HeaderText="ID" SortExpression="cod_usr" Visible="true" />
                                                        <asp:BoundField DataField="nom_comp" HeaderText="NOMBRE COMPLETO" SortExpression="nom_comp" />
                                                        <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                        <asp:TemplateField HeaderText="ESTATUS">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddl_usr_med_estatus" runat="server" AutoPostBack="true" Enabled="false">
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
                                        <div runat="server" id="div_usr_medf" visible="false">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_estatura" runat="server" Text="Estatura"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_med_estatura" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="6"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_estatura" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_med_estatura" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_peso" runat="server" Text="Peso"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_med_peso" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="7"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_peso" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_med_peso" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_tiposangre" runat="server" Text="Tipo de Sangre"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_med_tiposangre" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="8"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_tiposangre" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_med_tiposangre" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_falergia" runat="server" Text="¿Alergias?"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control input-box" ID="ddl_usr_med_falergia" runat="server" TabIndex="9" OnSelectedIndexChanged="ddl_usr_med_falergia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_falergia" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_usr_med_falergia" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_alergia" runat="server" Text="Alergia"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_med_alergia" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="10" Enabled="false"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_alergia" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_med_alergia" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group text-left">
                                                        <asp:Label CssClass="control-label fuente_css02" ID="lbl_usr_med_tratamiento" runat="server" Text="Tratamiento"></asp:Label>
                                                        <asp:TextBox CssClass="form-control input-box" ID="txt_usr_med_tratamiento" runat="server" placeholder="letras/números" ToolTip="letras/números" TabIndex="11" Enabled="false"></asp:TextBox>
                                                        <div class="text-right">
                                                            <asp:RequiredFieldValidator ID="rfv_usr_med_tratamiento" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usr_med_tratamiento" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="text-right">
                                                        <asp:Button CssClass="btn btn02" ID="btn_usr_med_guardar" runat="server" Text="GUARDAR" TabIndex="12" OnClick="btn_usr_med_guardar_Click" />
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
                <asp:UpdatePanel ID="up_usr_banc" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-lg-10">
                            <div class="col-lg-12 ">
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="up_usr_cap" runat="server" UpdateMode="Conditional">
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
                                <button class="btn btn01" data-dismiss="modal" aria-hidden="true">OK <i class="fa fa-check-circle-o"></i></button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
