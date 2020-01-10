<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="edit_YuanGongInf.aspx.cs" Inherits="admin_edit_YuanGongInf" %>

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
            var cardid1 = document.getElementById("u_cardid1").value;
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
    <style type="text/css">
        .buttonSubmit {
            cursor: pointer;
            width: 117px;
            height: 25px;
            border: 0px;
            text-align: center;
            line-height: 25px;
            color: #333;
            background: url(../images/button_allbg.gif) no-repeat left top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;员工信息修改

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 200px; text-align: center">
        <table style="width: 400px;">
            <tr>
                <td colspan="6">
                    <h3>修改员工信息</h3>
                </td>
            </tr>
             <tr >
                       <td >
                            ID:
                        </td>
                        <td>
                            <asp:TextBox ID="_ID" runat="server" Text="0" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
            <tr>
                <td>员工号：
                </td>
                <td>
                    <asp:TextBox ID="u_id" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>姓名：
                </td>
                <td>
                    <asp:TextBox ID="u_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>班次：
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
                </tr>
            <tr>
                <td>卡号2
                </td>
                <td>
                    <asp:TextBox ID="u_cardid2" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>卡号3
                </td>
                <td>
                    <asp:TextBox ID="u_cardid3" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>上级
                </td>
                <td>
                    <asp:DropDownList ID="u_shangji" runat="server"   Width="150px"></asp:DropDownList>


               


                </td>
                </tr>
            <tr>
                <td>考勤管理员
                </td>
                <td>
                    <asp:DropDownList ID="u_kaoqinadmin" runat="server"  Width="150px"></asp:DropDownList>
                   
                </td>
                </tr>
            <tr>
                <td>餐补标准(元)</td>
                <td>
                    <asp:TextBox ID="u_canbu" runat="server"></asp:TextBox></td>
            </tr>

            <tr>

                <td>车补标准(元)
                </td>
                <td>
                    <asp:TextBox ID="u_chebu" runat="server"></asp:TextBox>//023565345
                </td>
                </tr>
            <tr>

                <td>级别</td>
                <td>
                    <asp:TextBox ID="u_jibie" runat="server"></asp:TextBox></td>
                </tr>
            <tr>
                <td>状态</td>
                <td>
                     <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="在职" GroupName="stat" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="离职" GroupName="stat"/>
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
