<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ShenQing.aspx.cs" Inherits="user_ShenQing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var startdate = document.getElementById("startdate").value;
             if (startdate == "") {

                 alert("请选择开始日期!");
                 return false;
             }
             var end = document.getElementById("enddate").value;
             if (end == "")
             {

                 alert("请选择结束时间!");
                 return false;
             }
           
         }
         function checklength(length)
         {
             var v = document.getElementById("thing").value;
             if (v.length > 100) {
                 document.getElementById("thing").value = "";
                 alert('输入文字不得超过100个字符');
             }
             return false;
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
     <style type="text/css">
         .auto-style1 {
             height: 34px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
      <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;个人申请申报

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
      <div style="margin-left: 40px; text-align: center">
        <table style="width: 750px;">
            <tr>
                <td colspan="4">
                    <h3>添加请假记录</h3>
                </td>
            </tr>
           <tr>
                <td colspan="2">
                    事项：
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_shixiang" runat="server" Width="150px">
                        <asp:ListItem>因公外出</asp:ListItem>
                        <asp:ListItem>年假</asp:ListItem>
                        <asp:ListItem>事假</asp:ListItem>
                        <asp:ListItem>病假</asp:ListItem>
                        <asp:ListItem>临时假</asp:ListItem>
                        <asp:ListItem>加班</asp:ListItem>
                         <asp:ListItem>异常申报</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
           
            <tr>
                <td>开始时间：
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
                    <asp:TextBox ID="startdate" runat="server" Width="80px" ReadOnly="true"></asp:TextBox>
                    <asp:DropDownList ID="time11_d1" runat="server">
          
                    </asp:DropDownList>
                    :
                    <asp:DropDownList ID="time11_d2" runat="server">
     
                    </asp:DropDownList>
                       
                </td>
                <td>结束时间：
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>
                    <asp:TextBox ID="enddate" runat="server" Width="80px" ReadOnly="true" ></asp:TextBox>
                       <asp:DropDownList ID="time12_d1" runat="server">
          
                    </asp:DropDownList>
                    :
                    <asp:DropDownList ID="time12_d2" runat="server" >
     
                    </asp:DropDownList>

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
                <td colspan="2" class="auto-style1">
                    缘由：
                </td>
                <td colspan="2" class="auto-style1">
                    <asp:TextBox ID="thing" runat="server" TextMode="MultiLine" onkeyup= "checklength(this) " Height="100px" style="margin-left: 0px" Width="250px" ></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td colspan="2">
                    申请天数(请假(天计算)、加班(小时计算)必填,填写数值,如0.5)：
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tianall" runat="server"  onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>(天、小时)
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClientClick=" return checkdata() " Width="118px" OnClick="Button1_Click"/>
                </td>
            </tr>
            </table>
           <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="Q_ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting">

                <Columns>

                   

                    <asp:BoundField DataField="q_number" HeaderText="员工号" SortExpression="q_number" />
                    <asp:BoundField DataField="q_name" HeaderText="姓名" SortExpression="q_name" />
                      <asp:BoundField DataField="q_shixiang" HeaderText="事项" SortExpression="q_shixiang" />
                    <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" />
                    <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" />
                    <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" />
                    <asp:BoundField DataField="q_all" HeaderText="申请天数(加班小时)" SortExpression="q_all" />
                      <asp:BoundField DataField="q_statue" HeaderText="状态" SortExpression="q_statue" />
                    
                    <asp:BoundField DataField="Q_ID" HeaderText="Q_ID" InsertVisible="False" ReadOnly="True" SortExpression="Q_ID" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Q_ID") %>'
                                CommandName="Edit" Text="编辑" ></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("Q_ID") %>' Text="删除"></asp:LinkButton>
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
            <!--end 常规表格-->
          </div>
</asp:Content>


