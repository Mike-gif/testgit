<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="chuchai.aspx.cs" Inherits="admin_chuchai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var startdate = document.getElementById("startdate").value;
             if (startdate == "") {

                 alert("请选择开始日期!");
                 return false;
             }
             var start = document.getElementById("starttime").value;
             if (start == "") {

                 alert("请输入开始时间!");
                 return false;
             }
             var enddate = document.getElementById("enddate").value;
             if (enddate == "") {

                 alert("请选择结束日期!");
                 return false;
             }
             var endtime = document.getElementById("endtime").value;
             if (endtime == "") {

                 alert("请输入结束时间!");
                 return false;
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
      <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;出差记录

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
     <div style="margin-left: 40px; text-align: center">
        <table style="width: 700px;">
            <tr>
                <td colspan="4">
                    <h3>添加出差记录</h3>
                </td>
            </tr>
            <tr>
                <td>员工号：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="number" DataValueField="name" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [name], [number] FROM [userinfo]"></asp:SqlDataSource>
                </td>
                <td>姓名：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="number" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [name], [number] FROM [userinfo]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>开始时间：
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
                    <asp:TextBox ID="startdate" runat="server" Width="80px" ReadOnly="true"></asp:TextBox>
                    <asp:TextBox ID="starttime" runat="server" Width="60px"></asp:TextBox>
                       
                </td>
                <td>结束时间：
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>
                    <asp:TextBox ID="enddate" runat="server" Width="80px" ReadOnly="true" ></asp:TextBox>
                    <asp:TextBox ID="endtime" runat="server" Width="60px"></asp:TextBox>
                    

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
                    具体描述：
                </td>
                <td colspan="2">
                    <asp:TextBox ID="thing" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClientClick=" return checkdata() " Width="118px" OnClick="Button1_Click"/>
                </td>
            </tr>
            </table>
          <table border="0" align="right" cellpadding="0" cellspacing="0" >
            <tr>

                <td width="52">
                    <table width="88%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="STYLE1">
                                <div align="center">
                                    <img src="../images/11.gif" width="14" height="14" />
                                </div>
                            </td>
                            <td class="STYLE1">
                                <div align="center">
                                    <asp:LinkButton ID="lbDelete" CommandName="delOne" runat="server" Style="text-decoration: none"
                                        OnCommand="lbDelete_Command">删除</asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <style type="text/css">
            #gvShow td {
                text-align: center;
            }
        </style>
        <script type="text/javascript">
            function checkAll() {
                var checklist = document.getElementsByTagName("input");

                if (document.getElementById("ckAll").checked == true) {
                    for (var i = 0; i < checklist.length; i++) {
                        if (checklist[i].type == "checkbox") {
                            checklist[i].checked = true;
                        }
                    }
                } else {
                    for (var i = 0; i < checklist.length; i++) {
                        if (checklist[i].type == "checkbox") {
                            checklist[i].checked = false;
                        }
                    }
                }
            }
        </script>
        <div style="margin-left: 10px">
            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="C_ID"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting">

                <Columns>

                    <asp:TemplateField>

                        <HeaderTemplate>
                            <input type="checkbox" id="ckAll" onclick="checkAll();" />全选
                        </HeaderTemplate>

                        <ItemTemplate>
                            <asp:CheckBox ID="cbCheck" name="cbCheck" runat="server" Text='<%# Eval("C_ID") %>' Width="18" Height="18" Style="overflow: hidden; text-align: center;" />
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:BoundField DataField="c_number" HeaderText="员工号" SortExpression="c_number" />
                    <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="c_name" />
                    <asp:BoundField DataField="c_startdate" HeaderText="出差开始时间" SortExpression="c_startdate" />
                    <asp:BoundField DataField="c_enddate" HeaderText="出差结束时间" SortExpression="c_enddate" />
                    <asp:BoundField DataField="c_things" HeaderText="具体描述" SortExpression="c_things" />
                    <asp:BoundField DataField="C_ID" HeaderText="C_ID" InsertVisible="False" ReadOnly="True" SortExpression="C_ID" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作">
                        <ItemTemplate>
                           
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("C_ID") %>' Text="删除"></asp:LinkButton>
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
         </div>
</asp:Content>


