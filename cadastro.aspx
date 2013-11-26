<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cadastro.aspx.cs" Inherits="loja.cadastro" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <!-- specific styles -->
    <link href="css/login.css" rel="stylesheet" />

    <!-- specific scripts -->
    <script src="js/jquery.maskedinput-1.2.2.js"></script>
    <script src="js/mask.js"></script>
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="conteudo">
        <h2>Cadastro</h2>
        <hr />
        <table class="cadastro">
            <tr>
                <th>
                </th>
                <td>
                    <asp:RadioButtonList ID="radTipo" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="PF" Selected="true">Pessoa Física</asp:ListItem>
                        <asp:ListItem Value="PJ">Pessoa Jurídica</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    NOME* :
                </th>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="330px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblNome" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    SOBRENOME* :
                </th>
                <td>
                    <asp:TextBox ID="txtSobrenome" runat="server" Width="330px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblSobrenome" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    CPF* :
                </th>
                <td>
                    <asp:TextBox ID="txtCpf" runat="server" Width="140px" CssClass="_cpf" MaxLength="14"></asp:TextBox>
                    <asp:Label ID="lblCpf" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    RG :
                </th>
                <td>
                    <asp:TextBox ID="txtRg" runat="server" Width="140px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lblRg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    SEXO* :
                </th>
                <td>
                    <asp:RadioButtonList ID="radSexo" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M"> Masculino </asp:ListItem>
                        <asp:ListItem Value="F"> Feminino </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblSexo" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    NASCIMENTO* :
                </th>
                <td>
                    <asp:TextBox ID="txtNascimento" runat="server" CssClass="_data" Width="100px" MaxLength="10"></asp:TextBox>
                    <asp:Label ID="lblNascimento" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    TELEFONE 1* :
                </th>
                <td>
                    <asp:TextBox ID="txtTelefone1" runat="server" Width="150px" MaxLength="15"></asp:TextBox>
                    <asp:Label ID="lblTelefone1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    TELEFONE 2 :
                </th>
                <td>
                    <asp:TextBox ID="txtTelefone2" runat="server" Width="150px" MaxLength="15"></asp:TextBox>
                    <asp:Label ID="lblTelefone2" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    E-MAIL* :
                </th>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="330px" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lblEmail" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    SENHA* :
                </th>
                <td>
                    <asp:TextBox ID="txtSenha" runat="server" Width="230px" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblSenha" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    CEP* :
                </th>
                <td>
                    <asp:TextBox ID="txtCep" runat="server" CssClass="_cep" Width="100px" MaxLength="9"></asp:TextBox>
                    <asp:Label ID="lblCep" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    ENDEREÇO* :
                </th>
                <td>
                    <asp:TextBox ID="txtEndereco" runat="server" Width="330px" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lblEndereco" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    NÚMERO* :
                </th>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lblNumero" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    COMPLEMENTO :
                </th>
                <td>
                    <asp:TextBox ID="txtComplemento" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                    <asp:Label ID="lblComplemento" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    BAIRRO* :
                </th>
                <td>
                    <asp:TextBox ID="txtBairro" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblBairro" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    CIDADE* :
                </th>
                <td>
                    <asp:TextBox ID="txtCidade" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblCidade" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    ESTADO* :
                </th>
                <td>
                    <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblEstado" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    REFERÊNCIA :
                </th>
                <td>
                    <asp:TextBox ID="txtReferencia" runat="server" Width="400px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="lblReferencia" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:CheckBox ID="chkNews" runat="server" Checked="true" Text=" receber promoções/novidades por e-mail " />
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnContinuar" runat="server" Text="continuar" OnClick="btnContinuar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>