<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="ChuQinInfo.aspx.cs" Inherits="admin_ChuQinInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var end = document.getElementById("startime").value;
             if (end == "") {

                 alert("请选择出勤时间!");
                 return false;
             }
         
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;员工刷卡出勤记录

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
   <div style="margin-left: 40px; text-align: center">
        <table style="width: 650px; ">
            <tr>
                <td colspan="4">
                    <h3>员工刷卡出勤记录</h3>
                </td>
            </tr>
            <tr>
                <td>员工号：
                </td>
                <td>
                    <asp:TextBox ID="tb_number" runat="server"></asp:TextBox>
                     
                </td>
                <td>姓名：
                </td>
                <td>
                    <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    考勤位置：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource3" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [location] FROM [Location]"></asp:SqlDataSource>

                </td>
                <td>
                    班次：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_banci" runat="server" Width="150px">
                        <asp:ListItem>一班</asp:ListItem>
                        <asp:ListItem>二班</asp:ListItem>
                        <asp:ListItem>三班</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
            <tr>
                <td>
                    时间：
                </td>
                <td>
                     <asp:TextBox ID="startime" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
                </td>
                  <td style="text-align:center; padding-left:160px" colspan="2" >
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />

                    </asp:Calendar>
                        
                </td>
               
            </tr>
                <tr>
                <td colspan="2">
              <asp:Button ID="moning" runat="server" Text="上班考勤" OnClick="moning_Click" style="height: 21px" OnClientClick=" return checkdata() " />
                
                </td>
                <td colspan="2"> 
                  <asp:Button ID="afternoon" runat="server" Text="下班考勤" OnClick="afternoon_Click" OnClientClick=" return checkdata() " />
                </td>
            </tr>
            </table>
         <asp:Table ID="tb_result" runat="server" Width="650px" >

        </asp:Table>
       </div>
</asp:Content>


