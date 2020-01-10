<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Jinzhicard.aspx.cs" Inherits="admin_Jinzhicard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;添加禁止卡

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent">
    <div style="margin-left: 10px; text-align: center">
        <table style="width: 100%;">
            <tr>
                <td>员工卡号：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_number" runat="server" DataSourceID="SqlDataSource1" DataTextField="cardid1" DataValueField="cardid1" OnSelectedIndexChanged="ddl_number_SelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [cardid1] FROM [userinfo]"></asp:SqlDataSource>
                </td>
                <td>姓名：
                </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                  <td>
                      <asp:Button ID="Add_jinzhicard" runat="server" Text="添加禁止卡号" OnClick="Add_jinzhicard_Click" />
                </td>
            </tr>
            </table>
        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="jinzhiid"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting">

                <Columns>

                    <asp:BoundField DataField="jinzhiid" HeaderText="禁止卡卡号" SortExpression="jinzhiid" />
   
                      <asp:BoundField DataField="status" HeaderText="状态" SortExpression="status" />
                     <asp:BoundField DataField="nowtime" HeaderText="禁止卡添加时间" SortExpression="nowtime" />
                    
                    <asp:BoundField DataField="jinzhiid" HeaderText="jinzhiid" InsertVisible="False" ReadOnly="True" SortExpression="jinzhiid" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("jinzhiid") %>' Text="撤销"></asp:LinkButton>
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


