<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ChuQin.aspx.cs" Inherits="user_ChuQin" %>
<%@ Register Assembly="EeekSoft.Web.PopupWin" Namespace="EeekSoft.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
        <script type="text/javascript">
            function checkdata() {

                var start = document.getElementById("startime").value;
                if (start == "") {

                    alert("请输入开始时间!");
                    return false;
                }
                var end = document.getElementById("endtime").value;
                if (end == "") {

                    alert("请输入截止日期!");
                    return false;
                }
            }

      </script>
  
   
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人考勤信息查询&nbsp;&gt;&gt;&nbsp;出勤记录
         </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style="margin-left: 10px; text-align: center">
        <table style="width:90%">
               <tr>
                   <td>
                       姓名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       工号：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       级别：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       部门：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       上级：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       入职：<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                   </td>
                   
               </tr>
           </table>
        <table style="width: 90%;">
            <tr>
                <td>
                    考勤位置：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource1" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=KaoQin;Integrated Security=True" SelectCommand="SELECT [location] FROM [Location]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>

                </td>
                <td>
                    班次：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_banci" runat="server" Width="150px">
                        <asp:ListItem>班次1</asp:ListItem>
                        <asp:ListItem>班次2</asp:ListItem>
                        <asp:ListItem>班次3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <h5 style="color:red">累计在岗时间=最后一次刷卡时间（当日为当前时间）-最早刷卡时间-用餐时间</h5>
                </td>
                </tr>
               <tr>
                <td>开始时间：
                </td>
                <td>
                    <asp:TextBox ID="startime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
          
                </td>

                <td>结束时间：
                </td>
                <td>
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>

                </td>
                <td>
                    <h5 style="color:red">累计上岗时间=当日逐次进门至出门时间的累计</h5>
                </td>
            </tr>
            <tr>
                <td style="text-align:center; padding-left:160px" colspan="5" >
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
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar2_SelectionChanged">
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
                    <asp:Button ID="moning" runat="server" Text="当日考勤明细" OnClick="moning_Click" />
                </td>
                <td colspan="2"> 
                    <asp:Button ID="afternoon" runat="server" Text="时间段考勤汇总" OnClick="afternoon_Click" OnClientClick=" return checkdata() "/>
                </td>
                <td>
                    <asp:Button ID="cardall" runat="server" Text="时间段刷卡记录 " OnClick="cardall_Click"/>
                </td>
            </tr>
            </table>
        
   
        <asp:Table ID="tb_result" runat="server" Width="90%" ForeColor="Black" >

        </asp:Table>
       
        <cc1:PopupWin ID="PopupWin1" runat="server" 
            DockMode="BottomRight" DragDrop="False"  LinkTarget="_blank"
             Title="消息提示" HideAfter="15000" ColorStyle="Red" Width="200px" Height="200px"    ShowLink="false" Visible="false"  />
        &nbsp;
        </div>

</asp:Content>


