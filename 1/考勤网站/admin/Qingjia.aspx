<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Qingjia.aspx.cs" Inherits="admin_Qingjia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">
         function checkdata() {


             var startdate = document.getElementById("tb_nian").value;
             if (startdate == "") {

                 alert("请填写年份!");
                 return false;
             }
            
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="position">
      <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;查看请假记录

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
     <div style="margin-left: 40px; text-align: center">
        <table style="width:90%;">
             <tr>
                  <td>
                     年份：<asp:TextBox ID="tb_nian" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false" Width="100px"></asp:TextBox>

                  </td>
                  <td>
                      月份：<asp:DropDownList ID="tb_yue" runat="server" Width="100px">
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
                    班次：
                    <asp:DropDownList ID="ddr_banci" runat="server" Width="150px">
                        <asp:ListItem>班次1</asp:ListItem>
                        <asp:ListItem>班次2</asp:ListItem>
                        <asp:ListItem>班次3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 
                  <td>
                      <asp:Button ID="bnt_defen" runat="server" Text="统计"  OnClientClick=" return checkdata()" OnClick="bnt_defen_Click" Width="87px"  />
                  </td>
                   <td>
                       <asp:Button ID="btn_excel" runat="server" Text="导出到excel" OnClick="btn_excel_Click" OnClientClick=" return checkdata()" />
                   </td>
        
              </tr>
         </table> 
         <asp:Table ID="tb_result" runat="server" Width="90%" ForeColor="Black" >

        </asp:Table>
        </div>
         
</asp:Content>


