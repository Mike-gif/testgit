<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ManageChuQin.aspx.cs" Inherits="user_ManageChuQin" %>

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
        当前位置：下属考勤信息查询&nbsp;&gt;&gt;&nbsp;出勤记录
         </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style="margin-left: 10px; text-align: center">
        <table style="width: 100%;">
            <tr>
                <td>员工号：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_number" runat="server" DataSourceID="SqlDataSource1" DataTextField="number" DataValueField="number" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [number] FROM [userinfo] WHERE ([shangji] = @shangji and zaizhi='在职')">
                        <SelectParameters>
                            <asp:SessionParameter Name="shangji" SessionField="number" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>姓名：
                </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                  <td>
                    <h5 style="color: red">累计离岗时间=当日逐次出门至进门时间的累计</h5>
                </td>
            </tr>

            <tr>
                <td>考勤位置：
                </td>
                <td>
                                     <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource2" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [location] FROM [Location]"></asp:SqlDataSource>

                </td>
                <td>班次：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_banci" runat="server" Width="150px">
                        <asp:ListItem>班次1</asp:ListItem>
                        <asp:ListItem>班次2</asp:ListItem>
                        <asp:ListItem>班次3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <h5 style="color: red">累计在岗时间=最后一次刷卡时间（当日为当前时间）-最早刷卡时间-用餐时间</h5>
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
                    <h5 style="color: red">累计上岗时间=当日逐次进门至出门时间的累计</h5>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-left: 160px" colspan="5">
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
                    <asp:Button ID="afternoon" runat="server" Text="时间段考勤汇总" OnClick="afternoon_Click" OnClientClick=" return checkdata() " />
                </td>
              
            </tr>
        </table>
         <asp:Table ID="tb_result" runat="server" Width="100%" ForeColor="Black" >

        </asp:Table>
    </div>

</asp:Content>


