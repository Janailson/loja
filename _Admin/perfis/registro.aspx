<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="loja._Admin_lojas_registro" %>

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
            <a href="~/_Admin/" runat="server">Dashboard</a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li>
            <a href="listagem.aspx">Lojas</a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li class="active">Nova Loja</li>
    </ul><!--.breadcrumb-->
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">
            <i class="icon-remove"></i>
        </button>
        <strong><i class="icon-<%=icon%>"></i></strong>
        <asp:Label ID="labMsg" runat="server"></asp:Label>
        <br />
    </asp:Panel>

    <h3 class="header smaller lighter blue">
		<small>Geral</small>
	</h3>
    <div class="row-fluid form-horizontal">
        <asp:Panel ID="pnlFantasia" runat="server" CssClass="control-group">
			<label class="control-label">Fantasia : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:TextBox ID="txtFantasia" runat="server" CssClass="tooltip-error span12" MaxLength="50"></asp:TextBox>
                    <% if (lblFantasia.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblFantasia" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <asp:Panel ID="pnlRazaoSocial" runat="server" CssClass="control-group">
			<label class="control-label">Razão Social :</label>
			<div class="controls">
                <span class="input-icon input-icon-right span4">
                    <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="tooltip-error span12" MaxLength="100"></asp:TextBox>
                    <% if (lblRazaoSocial.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblRazaoSocial" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <asp:Panel ID="pnlCnpj" runat="server" CssClass="control-group">
			<label class="control-label">CNPJ : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span2">
                    <asp:TextBox ID="txtCnpj" runat="server" CssClass="tooltip-error span12 input-mask-cnpj" MaxLength="15"></asp:TextBox>
                    <% if (lblCnpj.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblCnpj" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <div class="control-group">
			<label class="control-label">Inscrição Estadual :</label>
			<div class="controls">
                <asp:TextBox ID="txtIe" runat="server" CssClass="span2" MaxLength="20"></asp:TextBox>
			</div>
		</div>
        <asp:Panel ID="pnlTelefone" runat="server" CssClass="control-group">
			<label class="control-label">Telefone : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="tooltip-error span12 ace-tooltip" MaxLength="15" title="Define o telefone que será exibido no site e também nos e-mails automáticos." data-placement="bottom"></asp:TextBox>
                    <% if (lblTelefone.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblTelefone" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <asp:Panel ID="pnlEmail" runat="server" CssClass="control-group">
			<label class="control-label">E-mail : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span4">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="tooltip-error span12 ace-tooltip" MaxLength="100" title="Define o e-mail que será exibido no site e também nos e-mails automáticos." data-placement="bottom"></asp:TextBox>
                    <% if (lblEmail.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblEmail" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <asp:Panel ID="pnlLogo" runat="server" CssClass="control-group">
            <label class="control-label">Logo : *</label>
			<div class="controls" style="width: 350px">
                <span class="input-icon input-icon-right span6">
				    <asp:FileUpload ID="uplLogo" runat="server" CssClass="span12 input-file" />
                </span>
                <asp:Label ID="lblLogo" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <asp:Panel ID="pnlCor" runat="server" CssClass="control-group">
			<label class="control-label">Cor : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span3">
                    <asp:DropDownList ID="ddlCor" runat="server" CssClass="tooltip-error span12">
                        <asp:ListItem>Padrão</asp:ListItem>
                    </asp:DropDownList>
                    <% if (lblCor.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblCor" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <div class="control-group">
			<label class="control-label">Chat :</label>
			<div class="controls">
                <asp:TextBox ID="txtChat" runat="server" CssClass="span5 limited" data-maxlength="200" Rows="2" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div>
        <div class="control-group">
			<label class="control-label">Status : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkStatus" runat="server" class="ace-switch ace-switch-3" checked="checked" />
					<span class="lbl"></span>
                </label>
			</div>
		</div>
        <div class="control-group">
            <div class="controls">
                <span class="help-block">* campo obrigatório</span>
            </div>
        </div>
    </div>

    <h3 class="header smaller lighter blue">
		<small>Idiomas</small>
	</h3>
    <div class="row-fluid form-horizontal">
        <div class="control-group">
			<label class="control-label">Multi-idioma : *</label>
			<div class="controls">
                <label>
					<input type="checkbox" id="chkMultiidioma" runat="server" class="ace-switch ace-switch-2" />
					<span class="lbl"></span>
                </label>
			</div>
		</div>
        <div class="control-group">
            <div class="controls">
                <span class="help-block">* campo obrigatório</span>
            </div>
        </div>
    </div>

    <h3 class="header smaller lighter blue">
		<small>Parcelamento</small>
	</h3>
    <div class="row-fluid form-horizontal">
        <div class="control-group">
			<label class="control-label">Parcela : *</label>
			<div class="controls">
                <asp:TextBox ID="txtParcela" runat="server" CssClass="spinner"></asp:TextBox>
				<div class="space-6"></div>
			</div>
		</div>
        <asp:Panel ID="pnlValorMinimo" runat="server" CssClass="control-group">
			<label class="control-label">Valor Mínimo : *</label>
			<div class="controls">
                <span class="input-icon input-icon-right span1">
                    <asp:TextBox ID="txtValorMinimo" runat="server" CssClass="tooltip-error span12" MaxLength="15">0</asp:TextBox>
                    <% if (lblValorMinimo.Visible) { %><i class="icon-remove-sign"></i><% } %>
                </span>
                <asp:Label ID="lblValorMinimo" runat="server" CssClass="help-inline" Visible="false"></asp:Label>
			</div>
		</asp:Panel>
        <div class="control-group">
            <div class="controls">
                <span class="help-block">* campo obrigatório</span>
            </div>
        </div>
    </div>

    <h3 class="header smaller lighter blue">
		<small>Redes Sociais</small>
	</h3>
    <div class="row-fluid form-horizontal">
        <div class="control-group">
			<label class="control-label">Facebook :</label>
			<div class="controls">
                <asp:TextBox ID="txtFacebook" runat="server" CssClass="span5 limited" data-maxlength="200" Rows="2" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div>
        <div class="control-group">
			<label class="control-label">Twitter :</label>
			<div class="controls">
                <asp:TextBox ID="txtTwitter" runat="server" CssClass="span5 limited" data-maxlength="200" Rows="2" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div>
        <div class="control-group">
			<label class="control-label">Google+ :</label>
			<div class="controls">
                <asp:TextBox ID="txtGooglePlus" runat="server" CssClass="span5 limited" data-maxlength="200" Rows="2" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div>
    </div>

    <div class="form-actions">
		<button class="btn btn-info" type="submit" id="btnSalvar" runat="server" onserverclick="btnSalvar_ServerClick">
			<i class="icon-save bigger-110"></i>
			salvar
		</button>

		&nbsp; &nbsp; &nbsp;
		<button class="btn" type="reset" onclick="window.location='listagem.aspx'">
			<i class="icon-reply bigger-110"></i>
			cancelar
		</button>
	</div>
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="script">
    <!--page specific plugin scripts-->
	<script src="../assets/js/fuelux/fuelux.spinner.min.js"></script>
    <script src="../assets/js/jquery.inputlimiter.1.3.1.min.js"></script>
    <script src="../assets/js/jquery.maskedinput.min.js"></script>
    <!--inline scripts related to this page-->
	<script type="text/javascript">
	    $(function () {
	        $.mask.definitions['~'] = '[+-]';
	        $('.input-mask-cnpj').mask('99.999.999/9999-99');

	        $('.ace-tooltip').tooltip();

	        $('.input-file').ace_file_input({
	            no_file: 'Sem arquivo...',
	            btn_choose: 'Escolha',
	            btn_change: 'Alterar',
	            droppable: false,
	            onchange: null,
	            thumbnail: true, //| true | large
	            whitelist: 'gif|png|jpg|jpeg'
	            //blacklist:'exe|php'
	            //onchange:''
	            //
	        });

	        $('textarea[class*=limited]').each(function () {
	            var limit = parseInt($(this).attr('data-maxlength')) || 100;
	            $(this).inputlimiter({
	                "limit": limit,
	                remText: '%n character%s remaining...',
	                limitText: 'max allowed : %n.'
	            });
	        });

	        $('.spinner').ace_spinner({ value: 1, min: 1, max: 18, step: 1, icon_up: 'icon-caret-up', icon_down: 'icon-caret-down' });
	    });
    </script>
</asp:Content>