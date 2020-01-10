<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="KaoHe.aspx.cs" Inherits="user_KaoHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var startdate = document.getElementById("startdate").value;
             if (startdate == "") {

                 alert("请选择开始日期!");
                 return false;
             }
             var jihua = document.getElementById("jihua").value;
             if (jihua == "") {

                 alert("请输入计划内容!");
                 return false;
             }
 

         }
         function checkdata1() {

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
         function check()
         {


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
         function checklength1(length) {
             var v = document.getElementById("jihua").value;
             if (v.length > 300) {
                 document.getElementById("jihua").value = "";
                 alert('输入文字不得超过200个字符');
             }
             return false;
         }
         function checklength2(length) {
             var v = document.getElementById("wancheng").value;
             if (v.length > 400) {
                 document.getElementById("wancheng").value = "";
                 alert('输入文字不得超过100个字符');
             }
             return false;
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
      <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;个人工作考核

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
       <div style="margin-left: 40px; text-align: center" id="div_cont">
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
          <table style="width:90%">
              <tr>
                  <td>
                      个人工作考核总得分月统计：
                  </td>
                  <td>
                     年份：<asp:TextBox ID="tb_nian" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>

                  </td>
                  <td>
                      月份：<asp:DropDownList ID="tb_yue" runat="server">
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
                      <asp:Button ID="Button2" runat="server" Text="统计"  OnClientClick=" return check()" OnClick="Button2_Click" />
                  </td>
                    <td >
                     总得分：<asp:TextBox ID="tb_all" runat="server" ReadOnly="true"></asp:TextBox>
                 </td>
        
              </tr>
               <tr>
              <td >
                  查看工作考核：
               <td >
              <td>开始时间：
               
                    <asp:TextBox ID="startime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
          
                </td>
                <td>结束时间：
                
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="查看" OnClick="Button1_Click" Width="100px" OnClientClick=" return checkdata1() " />
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
         <table style="width:90%">
              <tr height =" 40px">
                  <td> 
                   <font size="5" >
                  周计划
                    </font>
                   </td>
            </tr>
         
           </table>
         <asp:GridView ID="gvShow_zhou" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="4" OnPageIndexChanging="gvShow_zhou_PageIndexChanging"
                OnRowDataBound="gvShow_zhou_RowDataBound" OnRowCommand="gvShow_zhou_RowCommand" OnSorting="gvShow_zhou_Sorting" >

                <Columns>
                     <asp:BoundField DataField="z_time" HeaderText="填写日期" SortExpression="z_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="z_jihua" HeaderText="周计划" SortExpression="z_jihua"  ItemStyle-Width="20%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="20%" /></asp:BoundField>

                    <asp:BoundField DataField="z_mubiao" HeaderText="目标" SortExpression="z_mubiao" ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="z_zhanbi" HeaderText="占比" SortExpression="z_zhanbi" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="z_shishiqingkuang" HeaderText="实施情况" SortExpression="z_shishiqingkuang" ItemStyle-Width="15%" HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="15%" /></asp:BoundField>
                     <asp:BoundField DataField="z_jieguo" HeaderText="结果" SortExpression="z_jieguo" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="z_statue" HeaderText="状态"  ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                  <asp:BoundField DataField="z_pingyu" HeaderText="评语" SortExpression="z_pingyu" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                      <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="10%">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit_zhou" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="编辑" HeaderStyle-Width="5%"  ></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete_zhou" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("id") %>' Text="删除" HeaderStyle-Width="5%"></asp:LinkButton>
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
      
         <table style="width:90%">
   
                <tr height =" 40px">
                  <td> 
                   <font size="5" >
                  日计划
                 </font>
                
                    
                   </td>
            </tr>
         </table>
         <asp:GridView ID="gvShow_ri" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="5"
                 OnPageIndexChanging="gvShow_ri_PageIndexChanging"
                OnRowDataBound="gvShow_ri_RowDataBound" OnRowCommand="gvShow_ri_RowCommand" OnSorting="gvShow_ri_Sorting"
                    
              >

             

                <Columns>
                     <asp:BoundField DataField="r_time" HeaderText="填写日期" SortExpression="r_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="r_jihua" HeaderText="当日计划" SortExpression="r_jihua"  ItemStyle-Width="15%"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                   
                    <asp:BoundField DataField="r_mubiao" HeaderText="目标" SortExpression="r_mubiao" ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="r_gongshi" HeaderText="工时" SortExpression="r_gongshi" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="r_neirong" HeaderText="当天工作内容" SortExpression="r_neirong" ItemStyle-Width="15%" HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="15%" /></asp:BoundField>
                     <asp:BoundField DataField="r_jieguo" HeaderText="结果" SortExpression="r_jieguo" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="r_statue" HeaderText="状态"  ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="r_pingyu" HeaderText="评语" SortExpression="r_pingyu" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="r_defen" HeaderText="得分" SortExpression="r_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="10%">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit_ri" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="编辑" HeaderStyle-Width="5%"  ></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete_ri" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("id") %>' Text="删除" HeaderStyle-Width="5%"></asp:LinkButton>
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

         <table style="width:90%">
      
                <tr height =" 40px">
                  <td> 
                   <font size="5" >
                   请假/加班申请
                 </font>
                 
                    
                   </td>
            </tr>
         </table>
           
             <asp:GridView ID="gvShow_qing" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="4"     OnPageIndexChanging="gvShow_qing_PageIndexChanging"
                OnRowDataBound="gvShow_qing_RowDataBound" OnRowCommand="gvShow_qing_RowCommand" OnSorting="gvShow_qing_Sorting"
              
                    >

                <Columns>

                   
                    <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="True" ReadOnly="True" SortExpression="id" Visible="True" ItemStyle-Width="5%"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="q_time" HeaderText="填写日期" SortExpression="q_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                      <asp:BoundField DataField="q_shixiang" HeaderText="事项" SortExpression="q_shixiang" ItemStyle-Width="5%"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" ItemStyle-Width="20%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="20%" /></asp:BoundField>
                    <%--   <asp:HyperLinkField  DataNavigateUrlFields="ImageUrl" DataNavigateUrlFormatString="~/images/{0}"   HeaderText="请假凭证" HeaderStyle-Width="10%" Target="_blank" Text="查看凭证" /> --%> 
                   <asp:TemplateField HeaderText="请假凭证" HeaderStyle-Width="10%">
                        <ItemTemplate>
                    <asp:LinkButton ID="lbChaKan" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="ChaKan" Text="查看凭证" HeaderStyle-Width="10%" ></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="q_all" HeaderText="申请天数(加班小时)" SortExpression="q_all" ItemStyle-Width="5%"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                      <asp:BoundField DataField="q_statue" HeaderText="状态"  ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    
                    
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="10%">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit_qing" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="编辑" HeaderStyle-Width="5%" ></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete_qing" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("id") %>' Text="删除" HeaderStyle-Width="5%" ></asp:LinkButton>
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
           
          
           
           
           
           
           
           
             </div>
</asp:Content>


