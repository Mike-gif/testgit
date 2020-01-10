<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="BuTie.aspx.cs" Inherits="HR_BuTie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;补贴津贴配置

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent">
    <div style="margin-left: 40px; text-align: center">
           <table >
            <tr>
                <td colspan="2">
                    补贴津贴配置
                </td>
            </tr>
            <tr>
                <td>
                    全勤奖
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td>

                    一般通讯补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                 <td>
                    高级通讯补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                 <td>
                    见习首席师津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                 <td>
                    1级首席师津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    2级首席师津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    3级首席师津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    一般涉密津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    技术涉密津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    军工涉密津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    一般交通补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    加班交通补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    私车公用交通补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    高级交通补贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td>
                    特殊岗位津贴(月)
                </td>
                <td>
                    <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                </td>
                 </tr>
            <tr>
                <td >
                    <asp:Button ID="Button4" runat="server" Text="确定" Width="90px" />

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="取消" Width="90px" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>


