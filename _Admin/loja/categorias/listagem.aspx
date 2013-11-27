<%@ Page Language="C#" MasterPageFile="~/_Admin/MasterPage.master" AutoEventWireup="true" CodeFile="listagem.aspx.cs" Inherits="loja._Admin_loja_categorias_listagem" %>

<asp:Content ID="migalha" runat="server" ContentPlaceHolderID="migalha">
    <ul class="breadcrumb">
        <li>
            <i class="icon-dashboard"></i>
            <a href="~/_Admin/" runat="server"><%=Migalha.Dashboard%></a>
            <span class="divider">
                <i class="icon-angle-right"></i>
            </span>
        </li>
        <li class="active"><%=Migalha.Categorias%></li>
    </ul><!--.breadcrumb-->
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="page-header position-relative" style="padding: 50px 0">
        <button class="btn btn-danger" id="btnExcluir" runat="server">
			<i class="icon-trash bigger-125"></i>
			<%=Idioma.Excluir%>
		</button>
    </div><!--/.page-header-->
    
    <div class="row-fluid">
        <!--PAGE CONTENT BEGINS HERE-->
        <div class="row-fluid">
            <table id="table_bug_report" class="table table-striped table-bordered">
                <tbody>
                    <tr>
                        <td class="center" style="width: 30px">
                        </td>
                        <td>
                            - Root
                        </td>
                        <td>
                            <button class="btn btn-minier btn-info" onclick="window.location='registro.aspx?parentId=0'; return false;">
                                [+] adicionar
                            </button>
                        </td>
                    </tr>
                    <% MontarCategorias(0, 10); %>
                </tbody>
            </table>
        </div>
        <!--PAGE CONTENT ENDS HERE-->
    </div><!--/row-->
</asp:Content>