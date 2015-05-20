<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; padding-top: 10%; padding-left: 10%;">
            <div style="text-align: left;">
                <span>Teste UpLoad de Arquivo</span>
                <div>
                    <asp:FileUpload runat="server" ID="fUpload" />
                </div>
                <div>
                    <asp:Button runat="server" ID="btUpload" Text="Upload" OnClick="btUpload_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
