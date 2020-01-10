<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="GongZuoRi.aspx.cs" Inherits="admin_GongZuoRi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
       <script type="text/javascript">
           function checkdata() {


               var id = document.getElementById("TextBox1").value;
               if (id == "") {

                   alert("请选择工作日!");
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
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
       <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;工作日设置

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static" >
     <div style="margin-left: 40px; text-align: center;">
        <table style="width: 650px;">
            <tr>
                <td colspan="4">
                    <h3>添加每月工作日</h3>
                </td>
            </tr>
            <tr>
                <td>
                 年份：
                </td>
                <td><asp:TextBox ID="nianfen" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled"></asp:TextBox></td>
                <td>
                       月份：
                    
                 
                </td>
                <td>   <asp:DropDownList ID="DropDownList1" runat="server" Width="148" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="01">一月</asp:ListItem>
                        <asp:ListItem Value="02">二月</asp:ListItem>
                        <asp:ListItem Value="03">三月</asp:ListItem>
                        <asp:ListItem Value="04">四月</asp:ListItem>
                        <asp:ListItem Value="05">五月</asp:ListItem>
                        <asp:ListItem Value="06">六月</asp:ListItem>
                        <asp:ListItem Value="07">七月</asp:ListItem>
                        <asp:ListItem Value="08">八月</asp:ListItem>
                        <asp:ListItem Value="09">九月</asp:ListItem>
                        <asp:ListItem Value="10">十月</asp:ListItem>
                        <asp:ListItem Value="11">十一月</asp:ListItem>
                        <asp:ListItem Value="12">十二月</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:center">
                  选择工作日：</td>
                <td>
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
                <td>
                    工作日：
                  
                </td>
                <td>
                      <asp:TextBox ID="TextBox1" runat="server" Height="180px" TextMode="MultiLine" Width="200px"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="添加" Height="25px" OnClick="Button1_Click" Width="110px" OnClientClick=" return checkdata() " />
                </td>
                <td colspan="2"> 
                    <asp:Button ID="Button2" runat="server" Text="取消" PostBackUrl="~/admin/GongZuoRi.aspx" OnClick="Button2_Click" Width="110px" Height="25px"  />
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
                Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvShow_PageIndexChanging"
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
                         
                    
                      <asp:BoundField DataField="YearMon" HeaderText="工作年月"  SortExpression="YearMon" />
                     <asp:BoundField DataField="gongzuodate" HeaderText="工作日" SortExpression="gongzuodate" />
               
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




