<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="School.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
            <br />
        </div>
        <asp:TextBox ID="txt_login_email" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_login_pwd" runat="server"></asp:TextBox>
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Account_type" Text="Admin" />
&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Account_type" Text="Student" />
        <br />
        <asp:Button ID="btn_login" runat="server" Text="Login" CausesValidation="False" OnClick="btn_login_Click" style="height: 29px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_error" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Create an account"></asp:Label>
        <br />
        <br />
        Full Name: <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_name" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        Age: <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_age" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        Mobile Number: <asp:TextBox ID="txt_mobile" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_mobile" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        Class: <asp:TextBox ID="txt_class" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_class" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        Profile Photo: <asp:FileUpload ID="photo_student" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please fill this field" ControlToValidate="photo_student" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:Label ID="lbl_error_photo_upload" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Email: <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_email" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        Password: <asp:TextBox ID="txt_pwd" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_pwd" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <br />
        Confirm Password: <asp:TextBox ID="txt_confirm_pwd" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please fill this field" ControlToValidate="txt_confirm_pwd" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_pwd" ControlToValidate="txt_confirm_pwd" ErrorMessage="Both password must be same" ForeColor="#CC0000"></asp:CompareValidator>
        <br />
        <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
    &nbsp;&nbsp;
        <asp:Label ID="lbl_register_result" runat="server" Text="Label"></asp:Label>
    </form>
    <p>
        &nbsp;</p>

</body>
</html>
