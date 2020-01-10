<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="userpassword.aspx.cs" Inherits="HR_userpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;重置员工登陆密码

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent">
    <div style="margin-left: 40px; text-align: center">
        <table style="width: 90%; height: 110px;">
           <tr>
               <td>员工号：

               </td>
               <td>
                   <asp:DropDownList ID="ddl_number" runat="server" DataSourceID="SqlDataSource1" DataTextField="number" DataValueField="name"  Width="150px" OnSelectedIndexChanged="ddl_number_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [number], [name] FROM [userinfo]"></asp:SqlDataSource>
               </td>
               <td>
                   姓名：
               </td>
               <td>
                   <asp:TextBox ID="tb_name" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="Button1" runat="server" Text="重置" Width="100px" OnClick="Button1_Click"/>
               </td>
           </tr>
            </table>
        </div>
</asp:Content>


