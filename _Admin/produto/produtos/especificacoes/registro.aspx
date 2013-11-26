<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="loja._Admin_produto_produtos_especificacaoes_registro" %>

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
            <a href="../listagem.aspx">Produtos</a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li>
            <a href="../registro.aspx?id=<%=Request["produto"]%>"><%=new loja.Admin.Produto().ConsultarProduto(Request["produto"]).Nome%></a>
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
                <span class="input-icon input-icon-right span4">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="tooltip-error span12" MaxLength="50"></asp:TextBox>
                    <% if (lblNome.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblNome" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlValor" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Valor%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span6">
                    <asp:TextBox ID="txtValor" runat="server" CssClass="tooltip-error span12" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    <% if (lblValor.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblValor" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlFiltro" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Filtro%> : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkFiltro" runat="server" class="ace-switch ace-switch-3" checked="checked" />
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