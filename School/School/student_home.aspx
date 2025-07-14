<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_home.aspx.cs" Inherits="School.student_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Your Profile"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" Text="Logout" />
            <br />
            <br />
            <asp:Image ID="img_profile" runat="server" Height="201px" Width="220px" />
            <br />
            <br />
            <asp:Button ID="btn_scoreboard" runat="server" OnClick="btn_scoreboard_Click" Text="Show Scoreboard" />
&nbsp;&nbsp;
            <asp:Button ID="btn_materials" runat="server" OnClick="btn_materials_Click" Text="Materials " />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="exam_id" HeaderText="Exam ID" />
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
            <asp:Label ID="Label2" runat="server" Text="Update Your Details"></asp:Label>
            <br />
            <br />
            Name: <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
            <br />
            Age: <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
            <br />
            Mobile: <asp:TextBox ID="txt_mobile" runat="server"></asp:TextBox>
            <br />
            Class: <asp:TextBox ID="txt_class" runat="server"></asp:TextBox>
            <br />
            Photo: 
            <asp:FileUpload ID="img_profile_update" runat="server" />
&nbsp;&nbsp;
            <asp:Label ID="lbl_profile_update" runat="server" Text="Label"></asp:Label>
            <br />
            Email: <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
            <br />
            Old Password: <asp:TextBox ID="txt_old_password" runat="server"></asp:TextBox>
            <br />
            New Password: <asp:TextBox ID="txt_new_password" runat="server"></asp:TextBox>
            &nbsp;
            <br />
            Confirm Password: <asp:TextBox ID="txt_confirm_password" runat="server"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txt_new_password" ControlToValidate="txt_confirm_password" ErrorMessage="Should match new password" ForeColor="#CC0000"></asp:CompareValidator>
            <br />
        </div>
        <asp:Button ID="btn_update_changes" runat="server" OnClick="btn_update_changes_Click" Text="Update Changes" />
    &nbsp;&nbsp;
        <asp:Label ID="update_error_lbl" runat="server" Text="label"></asp:Label>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
