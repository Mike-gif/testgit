<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admin_password.aspx.cs" Inherits="admin_admin_password" %>

 <asp:Content ID="head" runat="server" contentplaceholderid="_head">
    
     <link href="../css/style.css" rel="stylesheet" />
     <style type="text/css">
         table {
             margin: 5px 3px 2px 117px;
             font-family: arial, "微软雅黑";
             text-align:center;
             font-size:14px;
         }
       
         
         </style>
     <script type="text/javascript">
         function check() {


             var password1 = document.getElementById("password1").value;
             if (password1 == "") {
                 alert("请输入初始密码!");
                 return false;
             }
             var password2 = document.getElementById("password2").value;
             if (password2 == "") {
                 alert("请输入新密码!");
                 return false;
             }
             var password3 = document.getElementById("password3").value;
             if (password3 == "") {
                 alert("请再次确认密码!");
                 return false;
             }
         }




</script>
     </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="position">
    <div style="padding-left:10px;padding-top:15px">
       当前位置： 个人信息 &nbsp;&gt;&gt;&nbsp;修改密码
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
 <div style="margin-left: 40px; text-align: center;margin-top:30px">
        <table style="width: 650px; ">
            <tr>
                <td>初始密码：</td>
                <td>
                    <asp:TextBox ID="password1" runat="server" TextMode="Password" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>输入新密码：</td>
                <td>
                    <asp:TextBox ID="password2" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
             <tr>
                <td>再次确认新密码：</td>
                <td>
                    <asp:TextBox ID="password3" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="提交"  OnClientClick="return check();" OnClick="Button1_Click" Width="80px" /></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="取消" Width="80px" PostBackUrl="~/admin/admin_password.aspx"/></td>
            </tr>
        </table>
    </div>
        

</asp:Content>





