<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="edit_ManegeKaoHe.aspx.cs" Inherits="user_edit_ManegeKaoHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
      <script type="text/javascript">
       
          function checklength1(length) {
              var v = document.getElementById("jihua").value;
              if (v.length > 300) {
                  document.getElementById("jihua").value = "";
                  alert('输入文字不得超过300个字符');
              }
              return false;
          }
          function checklength2(length) {
              var v = document.getElementById("wancheng").value;
              if (v.length > 400) {
                  document.getElementById("wancheng").value = "";
                  alert('输入文字不超过400个字符');
              }
              return false;
          }

          function checklength3(pingyu) {
              var v = document.getElementById("pingyu").value;
              if (v.length > 200) {
                  document.getElementById("jihua").value = "";
                  alert('输入文字不超过200个字符');
              }
              return false;
          }
          function checklength4(length) {
              var v = document.getElementById("defen").value;
              if (v.length > 100) {
                  document.getElementById("wancheng").value = "";
                  alert('输入文字不超过100个字符');
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
           当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;下属工作考核审阅

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style="margin-left: 200px; text-align: center">
        <table style="width: 450px;height:500px">
            <tr>
                <td colspan="2">
                    <h3>下属工作考核审阅</h3>
                </td>
            </tr>
            <tr >
                       <td >
                            ID：
                        </td>
                        <td>
                            <asp:TextBox ID="_ID" runat="server" ReadOnly="true" ></asp:TextBox>
                        </td>
                    </tr>
        
                 <tr >
                       <td >
                            姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="_name" runat="server" ReadOnly="true" ></asp:TextBox>
                        </td>
                    </tr>
            <tr>
                <td>
                    日期：
                </td>
                
                <td>
                    <asp:TextBox ID="startdate" runat="server" ReadOnly="true"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                 <td>
                    计划：
                </td>
                <td>
                    <asp:TextBox ID="jihua" runat="server" TextMode="MultiLine" Width="320px" Height="80px"  onkeyup= "checklength1(this) " ></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td>
                    完成情况：
                </td>
                <td>
                    <asp:TextBox ID="wancheng" runat="server" TextMode="MultiLine" Width="320px" Height="80px" onkeyup= "checklength2(this) " ></asp:TextBox>
                </td>
            </tr>
    <tr>
        <td>
            评语：
        </td>
        <td>
            <asp:TextBox ID="pingyu" runat="server" TextMode="MultiLine" Width="320px" Height="80px"  onkeyup= "checklength3(this) "></asp:TextBox>

        </td>

    </tr>
            <tr>
                <td>
                    得分：
                </td>
                <td>
                    <asp:TextBox ID="defen" runat="server" TextMode="MultiLine" Width="320px" Height="80px" onkeyup= "checklength4(this)" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    状态：
                </td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="未批阅" GroupName="stat" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="已批阅" GroupName="stat"/>
                </td>
            </tr>
           
            <tr>
                 <td colspan="2">
                    <asp:LinkButton Height="25" ID="lbSubmitAdd" runat="server" Text="修 改" class="buttonSubmit"
                        OnClick="lbSubmitAdd_Click" ></asp:LinkButton>
                </td>
            </tr>
            </table>
        </div>
</asp:Content>


