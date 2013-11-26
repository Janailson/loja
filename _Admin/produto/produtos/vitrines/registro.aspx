<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="loja._Admin_produto_produtos_vitrines_registro" %>

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
        <asp:Panel ID="pnlTamanho" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Tamanho%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:DropDownList ID="ddlTamanho" runat="server"></asp:DropDownList>
                    <% if (lblTamanho.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblTamanho" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlPeso" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Peso%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtPeso" runat="server" CssClass="tooltip-error span12" MaxLength="50">0</asp:TextBox>
                    <% if (lblPeso.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblPeso" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlAltura" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Altura%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtAltura" runat="server" CssClass="tooltip-error span12" MaxLength="50">0</asp:TextBox>
                    <% if (lblAltura.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblAltura" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlLargura" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Largura%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtLargura" runat="server" CssClass="tooltip-error span12" MaxLength="50">0</asp:TextBox>
                    <% if (lblLargura.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblLargura" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlProfundidade" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Profundidade%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtProfundidade" runat="server" CssClass="tooltip-error span12" MaxLength="50">0</asp:TextBox>
                    <% if (lblProfundidade.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblProfundidade" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlEstoque" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Estoque%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtEstoque" runat="server" CssClass="tooltip-error span12" MaxLength="50">0</asp:TextBox>
                    <% if (lblEstoque.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblEstoque" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
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