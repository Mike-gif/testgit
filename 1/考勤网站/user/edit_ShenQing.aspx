<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="edit_ShenQing.aspx.cs" Inherits="user_edit_ShenQing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
      <script type="text/javascript">
          function checkdata() {


              var startdate = document.getElementById("startdate").value;
              if (startdate == "") {

                  alert("请选择开始日期!");
                  return false;
              }
              var end = document.getElementById("enddate").value;
              if (end == "") {

                  alert("请选择结束时间!");
                  return false;
              }

          }
          function checklength(length) {
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
        .buttonSubmit {
            border-style: none;
             border-color: inherit;
             border-width: 0px;
             cursor: pointer;
             width: 117px;
             text-align: center;
             line-height: 25px;
             color: #333;
             background: url(../images/button_allbg.gif) no-repeat left top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
     <div style="padding-left: 10px; padding-top: 15px">
           当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;个人申请申报修改

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style="margin-left: 200px; text-align: center">
        <table style="width: 450px;height:500px">
            <tr>
                <td colspan="4">
                    <h3>个人申请申报修改</h3>
                </td>
            </tr>
             <tr >
                       <td >
                            ID:
                        </td>
                        <td>
                            <asp:TextBox ID="_ID" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
            
           <tr>
                <td >
                    事项：
                </td>
                <td >
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
                </tr>
            <tr>
                  <td style="text-align: center; padding-left: 160px" colspan="2">
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
                <td>结束时间：
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>
                    <asp:TextBox ID="enddate" runat="server" Width="80px" ReadOnly="true" ></asp:TextBox>
                       <asp:DropDownList ID="time12_d1" runat="server">
          
                    </asp:DropDownList>
                    :
                    <asp:DropDownList ID="time12_d2" runat="server">
     
                    </asp:DropDownList>

                </td>

            </tr>
            <tr>
                <td colspan="2" style="text-align: center; padding-left: 160px" >
              
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
                <td >
                    缘由：
                </td>
                <td >
                    <asp:TextBox ID="thing" runat="server" TextMode="MultiLine" Height="100px" Width="250px" onkeyup= "checklength(this) "></asp:TextBox>
                </td>
                </tr>
          <tr>
                <td >
                    申请天数(填写数值,如：0.5)：
                </td>
                <td >
                    <asp:TextBox ID="tianall" runat="server"  onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton Height="25" ID="lbSubmitAdd" runat="server" Text="修 改" class="buttonSubmit"
                        OnClick="lbSubmitAdd_Click"></asp:LinkButton>
                </td>
            </tr>
            </table>
        </div>
</asp:Content>


