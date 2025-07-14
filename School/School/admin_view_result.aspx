<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_view_result.aspx.cs" Inherits="School.admin_view_result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="All Result"></asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" Text="Logout" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="exam_id" HeaderText="Exam ID" />
                <asp:BoundField DataField="st_name" HeaderText="Student Name" />
                <asp:BoundField DataField="math_marks" HeaderText="Maths Marks" />
                <asp:BoundField DataField="english_marks" HeaderText="English Marks" />
                <asp:BoundField DataField="java_marks" HeaderText="Java Marks" />
                <asp:BoundField DataField="cpp_marks" HeaderText="CPP Marks" />
                <asp:BoundField DataField="total_marks" HeaderText="Total Marks" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
