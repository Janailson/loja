<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="loja._Admin_produto_produtos_registro" %>

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
            <a href="listagem.aspx"><%=Migalha.Produtos%></a>
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
                <asp:Image ID="imgNome" runat="server" style="margin-left: 10px" />
                <asp:Label ID="lblNome" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
            <% multidioma("Nome"); %>
		</asp:Panel>

        <asp:Panel ID="pnlMarca" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Marca%> : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
                    <% if (lblMarca.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblMarca" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlFornecedor" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Fornecedor%> :</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:DropDownList ID="ddlFornecedor" runat="server"></asp:DropDownList>
                    <% if (lblFornecedor.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblFornecedor" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlDestaque" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Destaque%> : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkDestaque" runat="server" class="ace-switch ace-switch-3" />
					<span class="lbl"></span>
                </label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlLancamento" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Lancamento%> : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkLancamento" runat="server" class="ace-switch ace-switch-3" />
					<span class="lbl"></span>
                </label>
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

        <asp:Panel ID="pnlManual" runat="server" CssClass="control-group">
            <label class="control-label"><%=Idioma.Manual%> :</label>
            <div class="controls">
                <span class="input-icon input-icon-right span4">
                    <asp:FileUpload ID="uplManual" runat="server" CssClass="input-file tooltip-error span12" />
                    <% if (lblManual.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblManual" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
                <br clear="all" />
                <asp:Label ID="labManual" runat="server"></asp:Label>
            </div>
            <asp:HiddenField ID="hidManual" runat="server" />
        </asp:Panel>

        <asp:Panel ID="pnlVideo" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Video%> :</label>
			<div class="controls">
                <span class="input-icon input-icon-right span4">
                    <asp:TextBox ID="txtVideo" runat="server" CssClass="tooltip-error span12" Rows="3" TextMode="MultiLine"></asp:TextBox>
                    <% if (lblVideo.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblVideo" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>

        <asp:Panel ID="pnlDetalhe" runat="server" CssClass="control-group">
			<label class="control-label"><%=Idioma.Detalhes%> : *</label>
            <% editortexto("Detalhe"); %>
		</asp:Panel>
    </div>

    <asp:Panel ID="pnl" runat="server" Visible="false">
        <h3 class="header smaller lighter blue">
		    <small><%=Idioma.Vitrines%></small>
	    </h3>
        <div class="row-fluid form-horizontal">
            <div class="control-group">
                <button class="btn btn-mini btn-primary" onclick="window.location='vitrines/registro.aspx?produto=<%=Request["id"]%>'; return false;">
			        <i class="icon-plus-sign"></i>
			        adicionar vitrine
		        </button>
                <button class="btn btn-mini btn-danger">
                    <i class="icon-remove"></i>
                    remover selecionado(s)
                </button>
            </div>
        </div>

        <h3 class="header smaller lighter blue">
		    <small><%=Idioma.Caracteristicas%></small>
	    </h3>

        <h3 class="header smaller lighter blue">
		    <small><%=Idioma.Especificacoes%></small>
	    </h3>

        <h3 class="header smaller lighter blue">
		    <small><%=Idioma.Comentarios%></small>
	    </h3>
    </asp:Panel>

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
    <script src="../../assets/js/bootbox.min.js"></script>

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
	            whitelist: 'gif|png|jpg|jpeg'
	            //blacklist:'exe|php'
	            //onchange:''
	            //
	        });

	        $('._modal').click(function () {
	            var src = "";

	            // link
	            if ($(this).attr('href'))
	                src = $(this).attr('href');

	            var _width = ($(this).attr('relw') != null) ? $(this).attr('relw') : 620;
	            var _height = ($(this).attr('relh') != null) ? $(this).attr('relh') : 420;

	            var form = $('<iframe src="' + src + '" width="' + _width + '" height="' + _height + '" frameBorder="0"></iframe>');

	            var div = bootbox.dialog(form, {
				    "label": "<i class='icon-remove'></i> Close",
				    "class": "btn-small"
				},
				{
				    // prompts need a few extra options
				    "onEscape": function () { div.modal("hide"); }
				});

	            return false;
	        });
	    });
	</script>
</asp:Content>