<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ManegeKaoHe - Copy.aspx.cs" Inherits="user_ManegeKaoHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
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
          function checkdata1() {

              var start = document.getElementById("adddate").value;
              if (start == "") {

                  alert("请输入时间!");
                  return false;
              }
             
          }
          function checklength1(length) {
              var v = document.getElementById("jihua").value;
              if (v.length > 300) {
                  document.getElementById("jihua").value = "";
                  alert('输入文字不超过300个字符');
              }
              return false;
          }
          function checklength2(length)
          {
              var v = document.getElementById("wancheng").value;
              if (v.length > 400) {
                  document.getElementById("wancheng").value = "";
                  alert('输入文字不超过400个字符');
              }
              return false;
          }
          function check() {


              var startnian = document.getElementById("tb_nian").value;
              if (startnian == "") {

                  alert("请输入年份!");
                  return false;
              }
          }
          function LimitNum() {
              var result = false;
              if ((event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46)) //大小键盘的数字key都是一样的
              {
                  result = true;
              }
              return result;
          }
      </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position" >
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：下属信息管理&nbsp;&gt;&gt;&nbsp;管理工作考核

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 40px;text-align:center">
        <table>
            <tr>
                <td>
                    <asp:linkbutton ID="seek" runat="server" OnClick="seek_Click"  >批阅下属考核表</asp:linkbutton>
                </td>
                 <td>
                     <asp:LinkButton ID="addtianjia" runat="server" OnClick="addtianjia_Click" >添加下属考核表</asp:LinkButton>
                </td>
                <td>
                <asp:LinkButton ID="seek_fen" runat="server" OnClick="seek_fen_Click">工作考核总得分统计</asp:LinkButton>
                    </td>
            </tr>
        </table>
        <table style="width: 100%;" runat="server" id="seektab">
            <tr>
                <td>
                    下属：
                
                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="name" DataValueField="name" ></asp:DropDownList>
                    
                </td>
                <td>开始时间：
               
                    <asp:TextBox ID="startime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
          
                </td>
                <td>结束时间：
                
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="查看" OnClick="Button1_Click" Width="100px" OnClientClick=" return checkdata() " />
                </td>
               
            </tr>
            <tr>
                   
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
                       入职：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
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
            <table style="width: 90%;" id="addkaohe" runat="server">
            
            <tr>
                 <td>
                    下属：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_name2" runat="server" ></asp:DropDownList>
                    
                </td>
                </tr>
                <tr>
                <td>
                    日期：
                </td>
                
           
                <td>
                    <asp:TextBox ID="adddate" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">打开日历</asp:LinkButton>
                </td>
                </tr>
            <tr>
                 <td>
                    计划：
                </td>
                <td style="width:80%">
                    <asp:TextBox ID="jihua" runat="server" TextMode="MultiLine" Height="80px" onkeyup= "checklength1(this) " Width="321px"></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td>
                    完成情况：
                </td>
                <td style="width:80%">
                    <asp:TextBox ID="wancheng" runat="server" TextMode="MultiLine" Height="80px" onkeyup= "checklength2(this) " Width="318px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-left: 160px" colspan="6">
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar3_SelectionChanged" >
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
                <td colspan="2" style="padding-left:20%">
                    <asp:Button ID="Button2" runat="server" Text="添加"  OnClientClick=" return checkdata1() " Width="109px" OnClick="Button2_Click" />
                </td>
            </tr>
            </table>
           <table style="width:80%" id="defen" runat="server">
              <tr>
                  <td>
                     年份：<asp:TextBox ID="tb_nian" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false" Width="100px"></asp:TextBox>

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
                      <asp:Button ID="bnt_defen" runat="server" Text="统计"  OnClientClick=" return check()" OnClick="bnt_defen_Click" Width="87px"  />
                  </td>
                   <td>
                       <asp:Button ID="btn_excel" runat="server" Text="导出到excel" OnClick="btn_excel_Click" OnClientClick=" return check()" />
                   </td>
        
              </tr>
             
               

          </table>
      <%--  批阅考核表--%>
        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="k_id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                 HorizontalAlign="Justify" AllowPaging="True" PageSize="35" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting"  Width="100%"  >

                <Columns>

                   

                    <%--<asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="7%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="7%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>--%>
                     <asp:BoundField DataField="k_time" HeaderText="日期" SortExpression="k_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="k_jihua" HeaderText="计划" SortExpression="k_jihua"  ItemStyle-Width="25%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="25%" /></asp:BoundField>
                    <asp:BoundField DataField="k_wancheng" HeaderText="完成情况" SortExpression="k_wancheng" ItemStyle-Width="23%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="23%" /></asp:BoundField>
                    <asp:BoundField DataField="k_pingyu" HeaderText="评语" SortExpression="k_pingyu" ItemStyle-Width="20%" 
                        HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                    <asp:BoundField DataField="k_defen" HeaderText="得分" SortExpression="k_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="k_statue" HeaderText="状态" SortExpression="k_statue" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    
                    <asp:BoundField DataField="k_id" HeaderText="k_id" InsertVisible="False" ReadOnly="True" SortExpression="k_id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="5%">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("k_id") %>'
                                CommandName="Edit" Text="审阅"  ></asp:LinkButton>   
                        </ItemTemplate>
                    </asp:TemplateField>
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
     <%--   添加考核表--%>
          <asp:GridView ID="gvShow1" runat="server" AutoGenerateColumns="False" DataKeyNames="k_id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow1_PageIndexChanging"
                OnRowDataBound="gvShow1_RowDataBound" OnRowCommand="gvShow1_RowCommand" OnSorting="gvShow1_Sorting" >

                <Columns>

                   
                    <asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="k_time" HeaderText="日期" SortExpression="k_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="k_jihua" HeaderText="计划" SortExpression="k_jihua"  ItemStyle-Width="25%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="25%" /></asp:BoundField>

                    <asp:BoundField DataField="k_wancheng" HeaderText="完成情况" SortExpression="k_wancheng" ItemStyle-Width="20%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="20%" /></asp:BoundField>

                    <asp:BoundField DataField="k_pingyu" HeaderText="评语" SortExpression="k_pingyu" ItemStyle-Width="15%" 
                        HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                    <asp:BoundField DataField="k_defen" HeaderText="得分" SortExpression="k_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="k_statue" HeaderText="状态" SortExpression="k_statue" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    
                    <asp:BoundField DataField="k_id" HeaderText="k_id" InsertVisible="False" ReadOnly="True" SortExpression="k_id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="5%">
                        <ItemTemplate>
                            
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Del"
                                CommandArgument='<%# Eval("k_id") %>' Text="删除" HeaderStyle-Width="5%"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="25px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
       <%-- 查询考核总分--%>
        <asp:Table ID="tb_result" runat="server" Width="80%"  >

        </asp:Table>
    </div>
</asp:Content>
