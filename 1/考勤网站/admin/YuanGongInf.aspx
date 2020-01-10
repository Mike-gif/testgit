<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="YuanGongInf.aspx.cs" Inherits="admin_YuanGongInf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
      <script type="text/javascript">
          function checkdata() {


              var id = document.getElementById("u_id").value;
              if (id == "") {

                  alert("请输入员工号!");
                  return false;
              }
              var name = document.getElementById("u_name").value;
              if (name == "") {

                  alert("请输入员工姓名!");
                  return false;
              }
              var cardid1= document.getElementById("u_cardid1").value;
              if (cardid1 == "") {

                  alert("请输入卡号1!");
                  return false;
              }
              var jibie = document.getElementById("u_jibie").value;
              if (jibie == "") {

                  alert("请输入级别!");
                  return false;
              }

          }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;员工信息管理

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 40px; text-align: center">
        <table style="width: 90%;">
            <tr>
                <td colspan="6">
                    <h3>添加员工信息</h3>
                </td>
            </tr>
            <tr>
                <td>员工号：
                </td>
                <td>
                    <asp:TextBox ID="u_id" runat="server"></asp:TextBox>
                </td>
                <td>姓名：
                </td>
                <td>
                    <asp:TextBox ID="u_name" runat="server"></asp:TextBox>
                </td>
                <td>
                    班次：
                </td>
                <td>
                    <asp:DropDownList ID="u_ddl_banci" runat="server" DataSourceID="SqlDataSource1" DataTextField="banci" DataValueField="banci" Width="150px"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [banci] FROM [KaoQinCanShu]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>卡号1
                </td>
                <td>
                    <asp:TextBox ID="u_cardid1" runat="server"></asp:TextBox>
                </td>
                <td>
                    卡号2
                </td>
                <td>
                    <asp:TextBox ID="u_cardid2" runat="server"></asp:TextBox>
                </td>
                <td>
                   卡号3
                </td>
                <td>
                    <asp:TextBox ID="u_cardid3" runat="server"></asp:TextBox>
                </td>
            </tr>
         
            <tr>
                <td>
                    上级
                </td>
                <td>
                     <asp:DropDownList ID="u_shangji" runat="server" DataSourceID="SqlDataSource2" DataTextField="number" DataValueField="name" Width="75px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [name], [number] FROM [userinfo]"></asp:SqlDataSource>
                    <asp:TextBox ID="u_shangjiname" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>

                </td>
                <td>
                    考勤管理员
                </td>
                <td>
                   <asp:DropDownList ID="u_kaoqinadmin" runat="server" DataSourceID="SqlDataSource4" DataTextField="number" DataValueField="name" Width="75px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT [name], [number] FROM [userinfo]"></asp:SqlDataSource>
                    <asp:TextBox ID="u_kaoqinadminname" runat="server" ReadOnly="True" Width="75px"></asp:TextBox>
                    
                </td>
                <td>餐补标准(元)</td>
                <td>
                    <asp:TextBox ID="u_canbu" runat="server"></asp:TextBox></td>
            </tr>
            
             <tr>
               
                <td>
                    车补标准(元)
                </td>
                <td>
                    <asp:TextBox ID="u_chebu" runat="server"></asp:TextBox>
                </td>
          
           
                <td>级别</td>
                <td>
                    <asp:TextBox ID="u_jibie" runat="server"></asp:TextBox></td>
                <td>状态</td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="在职" GroupName="stat" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="离职" GroupName="stat"/>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="Button1" runat="server" Text="添加" Width="80px" OnClick="Button1_Click" OnClientClick=" return checkdata() "/>
                </td>
            </tr>
        </table>
        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                <td width="52">
                                                    <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="../images/11.gif" width="14" height="14" /></div>
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
                #gvShow td
                {
                    text-align: center;
                }
            </style>
            <script type="text/javascript" >
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
            <div >
            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting"  >
                
                <Columns>
               
                    <asp:TemplateField >
                      
                        <HeaderTemplate>
                             <input type="checkbox" id="ckAll" onclick="checkAll();" />全选
                        </HeaderTemplate>
                        
                        <ItemTemplate>
                            <asp:CheckBox ID="cbCheck" name="cbCheck" runat="server" Text='<%# Eval("id") %>'  Width="18" Height="18" Style="overflow: hidden; text-align: center;" />
                        </ItemTemplate>
                            
                    </asp:TemplateField>
                         
                    
                      <asp:BoundField DataField="number" HeaderText="员工号"  SortExpression="number" />
                     <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                      <asp:BoundField DataField="cardid1" HeaderText="卡号1" SortExpression="cardid1" />
                    <asp:BoundField DataField="cardid2" HeaderText="卡号2" SortExpression="cardid2" />
                    <asp:BoundField DataField="cardid3" HeaderText="卡号3" SortExpression="cardid3" />
                    <asp:BoundField DataField="Banci" HeaderText="班次" SortExpression="Banci" />
                    <asp:BoundField DataField="shangji" HeaderText="上级" SortExpression="shangji" />
                    <asp:BoundField DataField="kaoqinadmin" HeaderText="考勤管理员" SortExpression="kaoqinadmin" />
                     <asp:BoundField DataField="canbu" HeaderText="餐补" SortExpression="canbu" />
                    <asp:BoundField DataField="chebu" HeaderText="车补" SortExpression="chebu" />
                     <asp:BoundField DataField="jibie" HeaderText="级别" SortExpression="jibie" />
                    <asp:BoundField DataField="zaizhi" HeaderText="状态" SortExpression="zaizhi" />
                      <asp:BoundField DataField="password" HeaderText="密码" SortExpression="password"  Visible="false"/>
                      <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                      <asp:TemplateField HeaderText="详细操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("id") %>' Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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
            <!--end 常规表格-->
                </div>
    </div>
</asp:Content>


