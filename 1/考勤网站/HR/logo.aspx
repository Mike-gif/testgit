<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="logo.aspx.cs" Inherits="HR_logo" %>

<asp:Content ID="head" runat="server" contentplaceholderid="_head">
     
     <script src="js/jquery-1.8.3.js" type="text/javascript"></script>
     <script src="../js/jquery-1.8.3.min.js" type="text/javascript"></script>

      <script type="text/javascript">
          $(document).ready(function () {
              $("#fup1").val("");
          });

          function checkdata() {
              if ($("#fup1").val() == "") {
                  alert("请选择文件");
                  $("#fup1").focus();
                  return false;
              }
              var file = document.getElementById("fup1");
              var fileValue = file.value.substring(file.value.lastIndexOf("."));
              if (fileValue.toLowerCase() != ".png") {
                  alert("请上传有效图片格式文件，.png格式");
                  return false;
              }
              var _file = document.getElementById("fup1");
              var _size = _file.files[0].size;
              if (_size > 1200000) {
                  alert("文件不能大于2M或小于0.8M!");
                  $("#fup1").focus();
                  return false;
              }

              return true;
          }



      </script>
     <style type="text/css">
         .photo {
             
             padding-left:100px
         }
     </style>
     </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="position">
    <div style="padding-left:10px;padding-top:15px">
       当前位置： 修改信息 &nbsp;&gt;&gt;&nbsp;修改网站logo
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="mainContent" ClientIDMode="Static">
    <div style=" margin-left:10px" class="photo">
    <h2>提交照片</h2>
        <asp:FileUpload ID="fup1" runat="server"  />
        <asp:Label ID="Label1" runat="server"></asp:Label><br />
        <asp:Button ID="Button1" runat="server" Text="上传"  Width="77px" Font-Size="14px"
         OnClientClick="return checkdata()"  OnClick="Button1_Click" />
    <div>
    <asp:Image ID="Image1" runat="server" Visible="False"  />
        </div>
        </div>
</asp:Content>




