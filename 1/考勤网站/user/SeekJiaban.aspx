<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="SeekJiaban.aspx.cs" Inherits="user_SeekJiaban" %>

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
     <div style="margin-left: 40px; text-align: center">
        <table style="width: 650px;">
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
               
            </tr>
            <tr>
                <td>
                    <asp:Button ID="jiaban" runat="server" Text="加班记录查询" OnClick="jiaban_Click" OnClientClick=" return checkdata() "  />
               
                </td>
                <td>
                     <asp:Button ID="chuchai" runat="server" Text="出差记录查询" OnClick="chuchai_Click" />
                   
                </td>
                <td>
                     <asp:Button ID="qingjia" runat="server" Text="请假记录查询" OnClick="qingjia_Click" />
                   
                </td>
                <td>
                    <asp:Button ID="shuaka" runat="server" Text="刷卡记录查询" OnClick="shuaka_Click" />
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
        </table>
           <asp:GridView ID="gvShow1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="650px" HorizontalAlign="Justify" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvShow1_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnSorting="gvShow1_Sorting"  >
           <Columns>
               
                 <asp:BoundField DataField="u_number" HeaderText="员工号" SortExpression="u_number" />
                    <asp:BoundField DataField="u_name" HeaderText="姓名" SortExpression="u_name" />
                    <asp:BoundField DataField="u_jiatime" HeaderText="加班时间(小时)" SortExpression="u_jiatime" />
                    <asp:BoundField DataField="u_jiadate" HeaderText="加班日期" SortExpression="u_jiadate" />                
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
           <asp:GridView ID="gvShow3" runat="server" AutoGenerateColumns="False" DataKeyNames="Q_ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="650px" HorizontalAlign="Justify" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvShow3_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnSorting="gvShow3_Sorting"  >
           <Columns>
               
                <asp:BoundField DataField="q_number" HeaderText="员工号" SortExpression="q_number" />
                    <asp:BoundField DataField="q_name" HeaderText="姓名" SortExpression="q_name" />
                    <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" />
                    <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" />    
                    <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" />    
                <asp:BoundField DataField="Q_ID" HeaderText="Q_ID" InsertVisible="False" ReadOnly="True" SortExpression="Q_ID" Visible="false" />
              
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
           <asp:GridView ID="gvShow2" runat="server" AutoGenerateColumns="False" DataKeyNames="C_ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="650px" HorizontalAlign="Justify" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvShow2_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnSorting="gvShow2_Sorting"  >
           <Columns>
               
                 <asp:BoundField DataField="c_number" HeaderText="员工号" SortExpression="c_number" />
                    <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="c_name" />
                    <asp:BoundField DataField="c_startdate" HeaderText="出差开始时间" SortExpression="c_startdate" />
                    <asp:BoundField DataField="c_enddate" HeaderText="出差结束时间" SortExpression="c_enddate" />    
                    <asp:BoundField DataField="c_things" HeaderText="具体描述" SortExpression="c_things" />    
                <asp:BoundField DataField="C_ID" HeaderText="C_ID" InsertVisible="False" ReadOnly="True" SortExpression="C_ID" Visible="false" />
              
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
            <asp:GridView ID="gvShow4" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                 Width="650px"  HorizontalAlign="Justify" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvShow4_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnSorting="gvShow4_Sorting"  >
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


