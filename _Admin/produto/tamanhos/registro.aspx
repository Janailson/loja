<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="loja._Admin_produto_tamanhos_registro" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="../assets/css/jquery-ui-1.10.3.custom.min.css" />
	<link rel="stylesheet" href="../assets/css/chosen.css" />
	<link rel="stylesheet" href="../assets/css/datepicker.css" />
	<link rel="stylesheet" href="../assets/css/bootstrap-timepicker.css" />
	<link rel="stylesheet" href="../assets/css/daterangepicker.css" />
	<link rel="stylesheet" href="../assets/css/colorpicker.css" />
</asp:Content>

<asp:Content ID="migalha" runat="server" ContentPlaceHolderID="migalha">
    <ul class="breadcrumb">
        <li>
            <i class="icon-dashboard"></i>
            <a href="~/_Admin/" runat="server"><%=Migalha.Dashboard%></a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li>
            <a href="listagem.aspx"><%=Migalha.Tamanhos%></a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li class="active"><%=migalha%></li>
    </ul><!--.breadcrumb-->
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ID="pnlMsg" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">
            <i class="icon-remove"></i>
        </button>
        <strong><i class="icon-<%=icon%>"></i></strong>
        <asp:Label ID="labMsg" runat="server"></asp:Label>
        <br />
    </asp:Panel>
    
    <h3 class="header smaller lighter blue">
		<small><%=Idioma.Geral%></small>
	</h3>
    <div class="row-fluid form-horizontal">
        <asp:Panel ID="pnlNome" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Nome%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="tooltip-error span12" MaxLength="50"></asp:TextBox>
                    <% if (lblNome.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Image ID="imgBandeira" runat="server" style="margin-left: 10px" />
                <asp:Label ID="lblNome" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
            <% multidioma("Nome"); %>
		</asp:Panel>

        <asp:Panel ID="pnlStatus" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Status%> : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkStatus" runat="server" class="ace-switch ace-switch-3" checked="checked" />
					<span class="lbl"></span>
                </label>
			</div>
		</asp:Panel>
    </div>

    <div class="form-actions">
		<button class="btn btn-info" type="submit" id="btnSalvar" runat="server" onserverclick="btnSalvar_ServerClick">
			<i class="icon-save bigger-110"></i>
			<%=Idioma.Salvar%>
		</button>

		&nbsp; &nbsp; &nbsp;
		<button class="btn" type="reset" onclick="window.location='listagem.aspx'">
			<i class="icon-reply bigger-110"></i>
			<%=Idioma.Cancelar%>
		</button>
	</div>
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="script">
    <!--page specific plugin scripts-->

    <!--inline scripts related to this page-->
	<script type="text/javascript">
	    $(function () {
	        $('.input-file').ace_file_input({
	            no_file: 'No File ...',
	            btn_choose: 'Choose',
	            btn_change: 'Change',
	            droppable: false,
	            onchange: null,
	            thumbnail: false, //| true | large
	            whitelist:'gif|png|jpg|jpeg'
	            //blacklist:'exe|php'
	            //onchange:''
	            //
	        });
	    });
	</script>
</asp:Content>