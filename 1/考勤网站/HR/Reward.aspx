<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="Reward.aspx.cs" Inherits="HR_Reward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
      <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;奖罚配置

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent">
      <div style="margin-left: 40px; text-align: center">
       
        <table >
            <tr>
                <td>项目
                </td>
                <td>
                    员工状态
                </td>
                <td>
                    绩效分
                </td>
                <td>员工状态
                </td>
                 <td>绩效分
                </td>
                <td>
                    奖罚款
                </td>
            </tr>
              <tr>
                <td>
                    警告
                </td>
                <td>
                    试用
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>正式
                </td>
                 <td>
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    记过
                </td>
                <td>
                    试用
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>正式
                </td>
                 <td>
                     <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    除名
                </td>
                <td>
                    试用
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>正式
                </td>
                 <td>
                     <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    自动离职
                </td>
                <td>
                    试用旷工(天)
                </td>
                <td >
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                <td>正式旷工(天)
                </td>
                 <td>
                     <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    自动离职
                </td>
                <td>
                    试用离岗(天)
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
                <td>正式离岗(天)
                </td>
                 <td>
                     <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    月度之星
                </td>
                <td>
                    绩效前
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </td>
                <td>候选
                </td>
                 <td>
                     <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    年度之星(优秀员工)
                </td>
                <td>
                    绩效前
                </td>
                <td>
                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                </td>
                <td>候选
                </td>
                 <td>
                     <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="确定" Width="100px" />

                </td>
                <td colspan="3">
                    <asp:Button ID="Button2" runat="server" Text="取消" Width="100px" />
                </td>
            </tr>
            </table>
          </div>
</asp:Content>


