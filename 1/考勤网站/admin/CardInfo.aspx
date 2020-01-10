<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="CardInfo.aspx.cs" Inherits="admin_CardInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var start = document.getElementById("startime").value;
             if (start == "") {

                 alert("请选择开始时间!");
                 return false;
             }
             var end = document.getElementById("endtime").value;
             if (end == "") {

                 alert("请选择结束时间!");
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
                <td>开始时间：
                </td>
                <td>
                    <asp:TextBox ID="startime" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
                       

                </td>

                <td>结束时间：
                </td>
                <td>
                    <asp:TextBox ID="endtime" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>

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
                <td>
                    刷卡位置：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource3" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [location] FROM [Location]"></asp:SqlDataSource>

                </td>
                        <td colspan="2">
                            <asp:Button ID="Button" runat="server" Text="查询" OnClientClick=" return checkdata() " OnClick="Button_Click" Width="100px" />
                        </td>
                 </tr>

            </table>
        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                 Width="650px"  HorizontalAlign="Justify" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnSorting="gvShow_Sorting"  >
           <Columns>
               
                <asp:BoundField DataField="c_id" HeaderText="员工号"  SortExpression="number" />
                <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="c_time" HeaderText="刷卡时间" SortExpression="department" />
                <asp:BoundField DataField="c_addr" HeaderText="刷卡位置" SortExpression="IDcard" />
                <asp:BoundField DataField="c_status" HeaderText="进出状态" SortExpression="IDcard" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
              
                </Columns>
              
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="30px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
                
            </asp:GridView>
       </div>
</asp:Content>


