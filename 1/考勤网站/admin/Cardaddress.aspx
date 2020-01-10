<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Cardaddress.aspx.cs" Inherits="admin_Cardaddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
     <script type="text/javascript">

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
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;设置读卡器位置

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent"  ClientIDMode="Static">
    <div style="margin-left: 10px; text-align: center">
        <table style="width:70%;text-align: center">
              <tr>
                <td>进门地址：
                </td>
                <td>
                    <asp:TextBox ID="tb_jin" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>
                    </td>
                    </tr>
             <tr>
                <td>出门地址：
                </td>
                <td>
                    <asp:TextBox ID="tb_chu" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>
                    </td>
                    </tr>
             <tr>
                <td>
                    <asp:Button ID="setaddr" runat="server" Text="设置" Width="100px" OnClick="setaddr_Click" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="取消" Width="100px" OnClick="Button2_Click" />
                    </td>
                    </tr>
            </table>
        </div>
</asp:Content>


