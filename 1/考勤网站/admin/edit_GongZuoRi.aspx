<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="edit_GongZuoRi.aspx.cs" Inherits="admin_edit_GongZuoRi" %>

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
        当前位置：下属信息管理&nbsp;&gt;&gt;&nbsp;工作日修改

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
         <div style="margin-left: 40px; text-align: center;">
        <table style="width: 90%;">
            <tr>
                <td colspan="4">
                    <h3>修改工作日</h3>
                </td>
            </tr>
            <tr>
                <td>
                 年份：
                    <asp:TextBox ID="id" runat="server" Visible="false"></asp:TextBox>
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
                      <asp:TextBox ID="TextBox1" runat="server" Height="180px" TextMode="MultiLine" Width="200px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="修改" Height="25px" OnClick="Button1_Click" Width="110px" OnClientClick=" return checkdata() " />
                </td>
                <td colspan="2"> 
                    <asp:Button ID="Button2" runat="server" Text="取消" PostBackUrl="~/admin/GongZuoRi.aspx" Width="110px" Height="25px"  />
                </td>
            </tr>
            </table>
             </div>
</asp:Content>


