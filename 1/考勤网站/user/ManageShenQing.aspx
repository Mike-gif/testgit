<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ManageShenQing.aspx.cs" Inherits="user_ManageShenQing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：下属信息管理&nbsp;&gt;&gt;&nbsp;管理事项申报

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent">
    <div style="margin-left: 40px; text-align: center">
        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
            Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvShow_PageIndexChanging"
            OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting">

            <Columns>


                 <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="True" ReadOnly="True" SortExpression="id" Visible="True"  ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="q_number" HeaderText="员工号" SortExpression="q_number" />
                <asp:BoundField DataField="q_name" HeaderText="姓名" SortExpression="q_name" />
                <asp:BoundField DataField="q_shixiang" HeaderText="事项" SortExpression="q_shixiang" />
                <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" />
                <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" />
                <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" />
                 <asp:TemplateField HeaderText="请假凭证" >
                        <ItemTemplate>
                    <asp:LinkButton ID="lbChaKan" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="ChaKan" Text="查看凭证"  ></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="q_all" HeaderText="申请天数(加班小时)" SortExpression="q_all" />
                <asp:BoundField DataField="q_statue" HeaderText="状态"  />
                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />

                <asp:TemplateField HeaderText="详细操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>' CommandName="Edit" Text="同意"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("id") %>' Text="不同意"></asp:LinkButton>
                        <asp:LinkButton ID="lbxiugai" runat="server" CausesValidation="False" CommandName="Xiugai"
                            CommandArgument='<%# Eval("id") %>' Text="重新修改"></asp:LinkButton>
                     

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


