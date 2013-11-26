<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="loja.login" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <!-- specific styles -->
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="conteudo">
        <h2>Identificação</h2>
        <hr />
        <asp:Panel runat="server" CssClass="logon" DefaultButton="btnLogin">
            <table>
                <tr>
                    <td>
                        <span>E-MAIL :</span>
                        <asp:TextBox ID="txtEmail" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>SENHA :</span>
                        <asp:TextBox ID="txtSenha" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                       <asp:Button ID="btnLogin" runat="server" Text="continuar" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
        <asp:Panel runat="server" CssClass="cadastro" DefaultButton="btnCadastro">
            <table>
                <tr>
                    <td>
                        <span>E-MAIL :</span>
                        <asp:TextBox ID="txtNovoEmail" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Button ID="btnCadastro" runat="server" Text="continuar" OnClick="btnCadastro_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br clear="all" />
    </div>
</asp:Content>