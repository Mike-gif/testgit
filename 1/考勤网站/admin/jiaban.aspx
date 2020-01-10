<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="jiaban.aspx.cs" Inherits="admin_jiaban" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
    <script type="text/javascript">
        function checkdata() {

           
            var end = document.getElementById("time1").value;
            if (end == "") {

                alert("请输入加班时间!");
                return false;
            }
            var start = document.getElementById("startime").value;
            if (start == "") {

                alert("请选择加班日期!");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;加班记录

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 40px; text-align: center">
        <table style="width: 650px;">
            <tr>
                <td colspan="4">
                    <h3>添加加班记录</h3>
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
                <td>加班时间（小时）：
                </td>
                <td>
                    <asp:TextBox ID="time1" runat="server"></asp:TextBox>
                </td>
                <td>加班日期：
                </td>
                <td>
                    <asp:TextBox ID="startime" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>

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

                </td>


            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click1" OnClientClick=" return checkdata() " Width="118px"/>
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
            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
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
                            <asp:CheckBox ID="cbCheck" name="cbCheck" runat="server" Text='<%# Eval("ID") %>' Width="18" Height="18" Style="overflow: hidden; text-align: center;" />
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:BoundField DataField="u_number" HeaderText="员工号" SortExpression="u_number" />
                    <asp:BoundField DataField="u_name" HeaderText="姓名" SortExpression="u_name" />
                    <asp:BoundField DataField="u_jiatime" HeaderText="加班时间(小时)" SortExpression="u_jiatime" />
                    <asp:BoundField DataField="u_jiadate" HeaderText="加班日期" SortExpression="u_jiadate" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作">
                        <ItemTemplate>
                           
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("ID") %>' Text="删除"></asp:LinkButton>
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


