<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="Income.aspx.cs" Inherits="user_Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;薪酬明细
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent">
     <div style="margin-left: 10px; text-align: center">
        <table>
            <tr>
                <td>
                 全勤奖：</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                 特殊岗位津贴：</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    首席师津贴：</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    保密补贴：</td>
                <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                </tr>
              <tr>
                <td>
                 电话补贴：</td>
                <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                 交通补贴：</td>
                <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    加班交通补贴：</td>
                <td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    餐补：</td>
                <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                </tr>
              <tr>
                <td>
                 基本工资：</td>
                <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td>
                 绩效工资：</td>
                <td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                <td>
                   业绩提成：</td>
                <td><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                <td>
                   代缴代扣：</td>
                <td><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
                </tr>
              <tr>
                <td>
                 社保：</td>
                <td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
                <td>
                 住房公积金：</td>
                <td><asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
                <td>
                   工会：</td>
                <td><asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
                <td>
                   所得税：</td>
                <td><asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>
                    实发：</td>
                <td><asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </td>
            </tr>
            </table>
         </div>
</asp:Content>


