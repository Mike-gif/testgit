<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="ChangeName.aspx.cs" Inherits="admin_ChangeName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
  
     
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：修改信息&nbsp;&gt;&gt;&nbsp;修改软件名称
         </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style="margin-left: 10px; text-align: center">
        <table style="width: 100%;">
            <tr>
                <td>
                    软件名称：
                    <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="修改" Width="120px" OnClick="Button1_Click" />
                </td>
                </tr>
            </table>
        </div>
</asp:Content>


