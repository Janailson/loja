﻿<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="listagem.aspx.cs" Inherits="loja._Admin_lojas_perfis_listagem" %>

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
            <a href="~/_Admin/lojas/listagem.aspx" runat="server">Lojas</a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li>
            <a href="../registro.aspx?id=<%=Request["loja"]%>"><%=new loja.Admin.Loja().ConsultarLoja(Request["loja"]).Fantasia%></a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li class="active">Perfis</li>
    </ul><!--.breadcrumb-->
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="page-header position-relative" style="padding: 50px 0">
        <button class="btn btn-primary" onclick="window.location='registro.aspx?loja=<%=Request["loja"]%>'; return false;">
			<i class="icon-plus-sign bigger-125"></i>
			<%=Idioma.Novo%>
		</button>
        <button class="btn btn-danger" id="btnExcluir" runat="server" onserverclick="btnExcluir_ServerClick">
			<i class="icon-trash bigger-125"></i>
			<%=Idioma.Excluir%>
		</button>
    </div><!--/.page-header-->
    
    <div class="row-fluid">
        <!--PAGE CONTENT BEGINS HERE-->
        <div class="row-fluid">
            <table id="table_report" class="table table-striped table-bordered table-hover">
                <thead>
                    <tr>
                        <th class="center" style="width: 30px">
                            <label>
                                <input type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </th>
                        <th>Nome</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptListagem" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="center">
                                    <label>
                                        <input type="checkbox" name="chkExcluir" value="<%# Eval("IDPerfil") %>" />
                                        <span class="lbl"></span>
                                    </label>
                                </td>
                                <td>
                                    <a href="registro.aspx?loja=<%=Request["loja"]%>&id=<%# Eval("IDPerfil") %>"><%# Eval("Nome") %></a>
                                </td>
                                <td class="td-actions">
                                    <div class="hidden-phone visible-desktop btn-group">
										<button class="btn btn-mini btn-info" onclick="window.location='registro.aspx?id=<%# Eval("IDPerfil") %>'; return false;">
											<i class="icon-edit bigger-120"></i>
										</button>
									</div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <!--PAGE CONTENT ENDS HERE-->
    </div><!--/row-->
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="script">
    <!--page specific plugin scripts-->
    <script src="<%=ConfigurationManager.AppSettings["Url"]%>/_Admin/assets/js/jquery.dataTables.min.js"></script>
	<script src="<%=ConfigurationManager.AppSettings["Url"]%>/_Admin/assets/js/jquery.dataTables.bootstrap.js"></script>

    <!--inline scripts related to this page-->
    <script type="text/javascript">
        $(function () {
            var oTable1 = $('#table_report').dataTable({
                "aoColumns": [
			      { "bSortable": false },
			      null, 
                  { "bSortable": false }
                ]
            });


            $('table th input:checkbox').on('click', function () {
                var that = this;
                $(this).closest('table').find('tr > td:first-child input:checkbox')
                .each(function () {
                    this.checked = that.checked;
                    $(this).closest('tr').toggleClass('selected');
                });

            });

            $('[data-rel=tooltip]').tooltip();
        });
	</script>
</asp:Content>