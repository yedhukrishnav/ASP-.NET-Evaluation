<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="material_list.aspx.cs" Inherits="School.material_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Study Material List"></asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" Text="Logout" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="mat_id" HeaderText="Material ID" />
                <asp:BoundField DataField="mat_name" HeaderText="Material Name" />
                <asp:BoundField DataField="mat_path" HeaderText="Material Path" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_download" OnClick="btn_download_Click" CommandArgument='<%# Eval("mat_id")%>' runat="server">Download</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbl_download_status" runat="server" Text="Label"></asp:Label>
        <br />
    </form>
</body>
</html>
