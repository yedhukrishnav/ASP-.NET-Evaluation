<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_home.aspx.cs" Inherits="School.admin_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ADMIN HOME"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" style="margin-bottom: 0px" Text="Logout" />
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="margin-right: 0px">
            <Columns>
                <asp:BoundField DataField="register_no" HeaderText="Register Number" />
                <asp:BoundField DataField="st_name" HeaderText="Name" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_set_marks" OnClick="btn_set_marks_Click" CommandArgument='<%# Eval("register_no")%>' runat="server" CausesValidation="False">Set Marks</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p>
            <asp:Button ID="btn_view_all_results" runat="server" OnClick="btn_view_all_results_Click" Text="View All Reults" />
        </p>
        <p>
            &nbsp;</p>
         <p>
            <asp:Label ID="Label2" runat="server" Text="Enter Marks of the Four Subjects"></asp:Label>
        </p>
        <p>
          Student Name: <asp:TextBox ID="txt_student_name" runat="server"></asp:TextBox>
        &nbsp;</p>
        <p>
            Maths<asp:TextBox ID="txt_maths_marks" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_maths_marks" ErrorMessage="Enter marks within the set range" ForeColor="#CC0000" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            </p>
        <p>
            English: <asp:TextBox ID="txt_english_marks" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_english_marks" ErrorMessage="Enter marks within the set range" ForeColor="#CC0000" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            </p>
        <p>
            JAVA<asp:TextBox ID="txt_java_marks" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_java_marks" ErrorMessage="Enter marks within the set range" ForeColor="#CC0000" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            </p>
        <p>
            C++<asp:TextBox ID="txt_cpp_marks" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_cpp_marks" ErrorMessage="Enter marks within the set range" ForeColor="#CC0000" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        </p>
        <p>
            <asp:Button ID="btn_add_marks" runat="server" Text="Add Marks" OnClick="btn_add_marks_Click"  />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_marks_error" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Upload Study Materials"></asp:Label>
        </p>
        <p>
            Material Name:<asp:TextBox ID="txt_material_name" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:FileUpload ID="file_study_materials" runat="server" />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_material_name" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btn_materials_upload" runat="server" OnClick="btn_materials_upload_Click" Text="upload" />
        &nbsp;&nbsp;
            <asp:Label ID="lbl_mat_error" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
