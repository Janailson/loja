<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editor.aspx.cs" Inherits="loja._Admin_produto_produtos_editor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <FCKeditorV2:FCKeditor ID="txtTexto" runat="server" BasePath="~/_Admin/fckeditor/" Height="350px" ToolbarSet="Editado" Width="600px"></FCKeditorV2:FCKeditor>
    </div>
    <p><asp:Button ID="btnSalvar" runat="server" Text="salvar" OnClick="btnSalvar_Click" /></p>
    </form>
</body>

</html>