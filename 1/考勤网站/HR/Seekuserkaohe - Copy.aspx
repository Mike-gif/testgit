<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="Seekuserkaohe - Copy.aspx.cs" Inherits="HR_Seekuserkaohe" %>

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
        当前位置：员工信息管理&nbsp;&gt;&gt;&nbsp;查看工作考核
         </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
      <div style="margin-left: 10px; text-align: center">
        <table style="width: 100%;">
                  <tr>
                <td>
                    下属：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="name" DataValueField="name" ></asp:DropDownList>
                    
                </td>
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
                    <asp:Button ID="Button1" runat="server" Text="查看" OnClick="Button1_Click" Width="60px" OnClientClick=" return checkdata() " />
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
           <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="k_id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="false" GridLines="Horizontal"
                 HorizontalAlign="Justify" AllowPaging="True" PageSize="35" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound"   Width="100%"  >

                <Columns>

                    <asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="7%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="7%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="k_time" HeaderText="日期" SortExpression="k_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="k_jihua " HeaderText="计划" SortExpression="k_jihua "  ItemStyle-Width="25%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="25%" /></asp:BoundField>
                    <asp:BoundField DataField="k_wancheng" HeaderText="完成情况" SortExpression="k_wancheng" ItemStyle-Width="23%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="23%" /></asp:BoundField>
                    <asp:BoundField DataField="k_pingyu" HeaderText="评语" SortExpression="k_pingyu" ItemStyle-Width="20%" 
                        HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                    <asp:BoundField DataField="k_defen" HeaderText="得分" SortExpression="k_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="k_statue" HeaderText="状态" SortExpression="k_statue" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    
                    <asp:BoundField DataField="k_id" HeaderText="k_id" InsertVisible="False" ReadOnly="True" SortExpression="k_id" Visible="false" />
                
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="10px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" Height="1px" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            

            </asp:GridView>
             <table style="width:80%" id="defen" runat="server">
              <tr>
                  <td>
                     年份：<asp:TextBox ID="tb_nian" runat="server"  Width="100px"></asp:TextBox>

                  </td>
                  <td>
                      月份：<asp:DropDownList ID="tb_yue" runat="server" Width="100px">
                          <asp:ListItem>01</asp:ListItem>
                          <asp:ListItem>02</asp:ListItem>
                          <asp:ListItem>03</asp:ListItem>
                          <asp:ListItem>04</asp:ListItem>
                          <asp:ListItem>05</asp:ListItem>
                          <asp:ListItem>06</asp:ListItem>
                          <asp:ListItem>07</asp:ListItem>
                          <asp:ListItem>08</asp:ListItem>
                          <asp:ListItem>09</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList>
                  </td>
                 
                  <td>
                      <asp:Button ID="bnt_defen" runat="server" Text="统计"  OnClick="bnt_defen_Click" Width="87px"  />
                  </td>
                   <td>
                       &nbsp;</td>
        
              </tr>
             
               

          </table>
           <%-- 查询考核总分--%>
        <asp:Table ID="tb_result" runat="server" Width="80%"  >

        </asp:Table>
          </div>
</asp:Content>


